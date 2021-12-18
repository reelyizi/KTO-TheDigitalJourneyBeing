using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using TMPro;
using System;
public class MenuPlayFabManager : MonoBehaviour
{
    public GameObject containerTemplate, Table;
    public Color32 yellow, blue;
    public InputField nameInput;
    public Text nameInputText;
    public TextMeshProUGUI welcomeText;
    public static string currentName;
    public static string playFabUserID;
    public GameObject nameWindow, uiWindow, startButton, leaderboardPanel;
    void Awake()
    {
        nameWindow.SetActive(false);
        uiWindow.SetActive(false);
        Login();

    }
    void Update()
    {
        if (nameInputText.text == "")
        {
            startButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            startButton.GetComponent<Button>().interactable = true;
        }
    }
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = DeviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        playFabUserID = result.PlayFabId;
        Debug.Log("Successful login/account create! "+playFabUserID+"  "+result.InfoResultPayload.PlayerProfile.PlayerId+result.InfoResultPayload.PlayerProfile.DisplayName);
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }
        if (name == null)
        {
            //nameWindowsu aktif et
            nameWindow.SetActive(true);
            uiWindow.SetActive(false);
        }
        else
        {
            currentName = name;
            welcomeText.text = "Welcome " + currentName;
            nameWindow.SetActive(false);
            uiWindow.SetActive(true);
            GameManager.isGameStart = true;
            //okey

        }
    }
    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInputText.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
        currentName = nameInputText.text;
        welcomeText.text = "Welcome " + currentName;
        nameWindow.SetActive(false);
        uiWindow.SetActive(true);
        GameManager.isGameStart = true;
    }
    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
    public void LoadScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
    
    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }
    void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        leaderboardPanel.SetActive(true);
        GameObject[] containerTemplates = GameObject.FindGameObjectsWithTag("Container");
        foreach (GameObject go in containerTemplates)
        {
            Destroy(go);
        }
        containerTemplate.SetActive(false);
        if (result.Leaderboard.Count < 10)
        {
            for (int i = 0; i < 10; i++)
            {
                if (result.Leaderboard.Count > i)
                {
                    GameObject newGo = Instantiate(containerTemplate, Table.transform);
                    newGo.transform.SetParent(Table.transform);
                    newGo.tag = "Container";
                    newGo.SetActive(true);
                    TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
                    /*if (playFabUserID == result.Leaderboard[i].PlayFabId)
                    {
                        if (result.Leaderboard[i].DisplayName.Equals(null))
                        {
                            texts.text = (result.Leaderboard[i].Position + 1) + ". " + result.Leaderboard[i].PlayFabId + " " + result.Leaderboard[i].StatValue;
                            Debug.Log((result.Leaderboard[i].Position + 1) + " " + result.Leaderboard[i].PlayFabId + " " + result.Leaderboard[i].StatValue);
                            texts.color = yellow;
                        }
                        else
                        {
                            texts.text = (result.Leaderboard[i].Position + 1) + ". " + result.Leaderboard[i].DisplayName + " " + result.Leaderboard[i].StatValue;
                            Debug.Log((result.Leaderboard[i].Position + 1) + " " + result.Leaderboard[i].DisplayName + " " + result.Leaderboard[i].StatValue);
                            texts.color = yellow;
                        }

                    }
                    else
                    {
                        if (result.Leaderboard[i].DisplayName.Equals(null))
                        {
                            texts.text = (result.Leaderboard[i].Position + 1) + ". " + result.Leaderboard[i].PlayFabId + " " + result.Leaderboard[i].StatValue;
                            Debug.Log((result.Leaderboard[i].Position + 1) + " " + result.Leaderboard[i].PlayFabId + " " + result.Leaderboard[i].StatValue);
                            texts.color = blue;
                        }
                        else
                        {
                            texts.text = (result.Leaderboard[i].Position + 1) + ". " + result.Leaderboard[i].DisplayName + " " + result.Leaderboard[i].StatValue;
                            Debug.Log((result.Leaderboard[i].Position + 1) + " " + result.Leaderboard[i].PlayFabId + " " + result.Leaderboard[i].StatValue);
                            texts.color = blue;
                        }

                    }*/
                }
                else
                {
                    GameObject newGo = Instantiate(containerTemplate, Table.transform);
                    newGo.transform.SetParent(Table.transform);
                    newGo.tag = "Container";
                    newGo.SetActive(true);
                    TextMeshProUGUI texts = newGo.GetComponentInChildren<TextMeshProUGUI>();
                    texts.text = (i + 1) + ".";
                }
            }
        }
        else
        {
            foreach (var item in result.Leaderboard)
            {
                GameObject newGo = Instantiate(containerTemplate, Table.transform);
                newGo.transform.SetParent(Table.transform);
                newGo.tag = "Container";
                newGo.SetActive(true);
                TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
                if (currentName == item.DisplayName)
                {
                    texts[0].text = (item.Position + 1).ToString();
                    texts[1].text = item.DisplayName;
                    texts[2].text = item.StatValue.ToString();
                    /*texts.text = (item.Position + 1) + ". " + item.DisplayName + " " + item.StatValue;
                    Debug.Log((item.Position + 1) + " " + item.DisplayName + " " + item.StatValue);
                    texts.color = yellow;*/
                    texts[0].color = yellow;
                    texts[1].color = yellow;
                    texts[2].color = yellow;

                }
                else
                {
                    texts[0].text = (item.Position + 1).ToString();
                    texts[1].text = item.DisplayName;
                    texts[2].text = item.StatValue.ToString();
                    /*
                    texts.text = (item.Position + 1) + ". " + item.DisplayName + " " + item.StatValue;
                    Debug.Log((item.Position + 1) + " " + item.PlayFabId + " " + item.StatValue);
                    texts.color = blue;*/
                    texts[0].color = blue;
                    texts[1].color = blue;
                    texts[2].color = blue;
                }

            }
        }
    }
    public void GameObjectActivate(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void GameObjectDeActivate(GameObject obj)
    {
        obj.SetActive(false);
    }

    public static string DeviceUniqueIdentifier
    {
        get
        {
            var deviceId = "";


#if UNITY_EDITOR
            deviceId = SystemInfo.deviceUniqueIdentifier + "-editor";
#elif UNITY_ANDROID

                AndroidJavaClass up = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = up.GetStatic<AndroidJavaObject> ("currentActivity");
                AndroidJavaObject contentResolver = currentActivity.Call<AndroidJavaObject> ("getContentResolver");
                AndroidJavaClass secure = new AndroidJavaClass ("android.provider.Settings$Secure");
                deviceId = secure.CallStatic<string> ("getString", contentResolver, "android_id");
#elif UNITY_WEBGL
                if (!PlayerPrefs.HasKey("UniqueIdentifier"))
                    PlayerPrefs.SetString("UniqueIdentifier", System.Guid.NewGuid().ToString());
                deviceId = PlayerPrefs.GetString("UniqueIdentifier");
#else
                deviceId = SystemInfo.deviceUniqueIdentifier;
#endif
            return deviceId;
        }
    }
}
