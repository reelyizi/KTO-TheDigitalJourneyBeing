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
    public InputField nameInputDesktop;
    public WebGLNativeInputField nameInputAndroid;
    public TextMeshProUGUI welcomeText;
    public static string currentName;
    public GameObject nameWindow, uiWindow;
    public bool isAndroid;
    void Awake()
    {
        isAndroid = false;
        nameWindow.SetActive(false);
        uiWindow.SetActive(false);
        Login();

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
        Debug.Log("Successful login/account create!");
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
        if (!isAndroid)
        {
            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = nameInputDesktop.text
            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
            currentName = nameInputDesktop.text;
            welcomeText.text = "Welcome " + currentName;
            nameWindow.SetActive(false);
            uiWindow.SetActive(true);
            GameManager.isGameStart = true;
        }
        else
        {
            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = nameInputAndroid.text
            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
            currentName = nameInputAndroid.text;
            welcomeText.text = "Welcome " + currentName;
            nameWindow.SetActive(false);
            uiWindow.SetActive(true);
            GameManager.isGameStart = true;
        }

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

    public void forAndroid()
    {
        isAndroid = true;
        nameInputAndroid.gameObject.SetActive(true);
        nameInputDesktop.gameObject.SetActive(false);
    }
    public void forDesktop()
    {
        isAndroid = false;
        nameInputAndroid.gameObject.SetActive(false);
        nameInputDesktop.gameObject.SetActive(true);
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
