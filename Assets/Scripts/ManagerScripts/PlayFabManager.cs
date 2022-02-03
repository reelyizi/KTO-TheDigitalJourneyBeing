using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;
using PlayFab;
using TMPro;
using System;
public class PlayFabManager : MonoBehaviour
{

    public GameObject containerTemplate, Table;
    private string currentName;
    private string playFabuserID;
    public Color32 yellow, blue;
    void Start()
    {
        currentName = MenuPlayFabManager.currentName;
        playFabuserID = MenuPlayFabManager.playFabUserID;
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
    public void SendLeaderboard(int score)
    {
        //int score=int.Parse(scoreText.text);
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>{
                new StatisticUpdate{
                    StatisticName="Score",
                    Value=score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdate, OnError);

    }
    void OnUpdate(UpdatePlayerStatisticsResult result)
    {
        
    }
    public void GetLeaderBoardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Score",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderBoardGet, OnError);
    }
    void OnLeaderBoardGet(GetLeaderboardAroundPlayerResult result)
    {
        
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
                    if (currentName == result.Leaderboard[i].DisplayName)
                    {
                        Debug.LogWarning("Sıralamaya Gelen Skor: "+result.Leaderboard[i].StatValue.ToString());
                        if (result.Leaderboard[i].DisplayName.Equals(null))
                        {
                            texts[0].text = (result.Leaderboard[i].Position + 1) + ".";
                            texts[1].text = result.Leaderboard[i].PlayFabId;
                            texts[2].text = result.Leaderboard[i].StatValue.ToString();
                            texts[0].color = yellow;
                            texts[1].color = yellow;
                            texts[2].color = yellow;
                        }
                        else
                        {
                            texts[0].text = (result.Leaderboard[i].Position + 1) + ".";
                            texts[1].text = result.Leaderboard[i].DisplayName;
                            texts[2].text = result.Leaderboard[i].StatValue.ToString();
                            texts[0].color = yellow;
                            texts[1].color = yellow;
                            texts[2].color = yellow;
                        }

                    }
                    else
                    {
                        if (result.Leaderboard[i].DisplayName.Equals(null))
                        {
                            texts[0].text = (result.Leaderboard[i].Position + 1) + ".";
                            texts[1].text = result.Leaderboard[i].PlayFabId;
                            texts[2].text = result.Leaderboard[i].StatValue.ToString();
                            texts[0].color = blue;
                            texts[1].color = blue;
                            texts[2].color = blue;
                        }
                        else
                        {
                            texts[0].text = (result.Leaderboard[i].Position + 1) + ".";
                            texts[1].text = result.Leaderboard[i].DisplayName;
                            texts[2].text = result.Leaderboard[i].StatValue.ToString();
                            texts[0].color = blue;
                            texts[1].color = blue;
                            texts[2].color = blue;
                        }

                    }
                }
                else
                {
                    GameObject newGo = Instantiate(containerTemplate, Table.transform);
                    newGo.transform.SetParent(Table.transform);
                    newGo.tag = "Container";
                    newGo.SetActive(true);
                    TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
                    texts[0].text = (i + 1) + ".";
                    texts[1].text = "--------------";
                    texts[2].text = "-------";
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
                    texts[0].text = (item.Position + 1) + ".";
                    texts[1].text = item.DisplayName;
                    texts[2].text = item.StatValue.ToString();
                    texts[0].color = yellow;
                    texts[1].color = yellow;
                    texts[2].color = yellow;
                    //Debug.Log((item.Position + 1) + " " + item.DisplayName + " " + item.StatValue);
                }
                else
                {
                     texts[0].text = (item.Position + 1) + ".";
                    texts[1].text = item.DisplayName;
                    texts[2].text = item.StatValue.ToString();
                    texts[0].color = blue;
                    texts[1].color = blue;
                    texts[2].color = blue;
                    //Debug.Log((item.Position + 1) + " " + item.PlayFabId + " " + item.StatValue);
                }

            }
        }
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
                    TextMeshProUGUI texts = newGo.GetComponentInChildren<TextMeshProUGUI>();
                    if (playFabuserID == result.Leaderboard[i].PlayFabId)
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

                    }
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
                TextMeshProUGUI texts = newGo.GetComponentInChildren<TextMeshProUGUI>();
                if (currentName == item.DisplayName)
                {
                    texts.text = (item.Position + 1) + ". " + item.DisplayName + " " + item.StatValue;
                    Debug.Log((item.Position + 1) + " " + item.DisplayName + " " + item.StatValue);
                    texts.color = yellow;
                }
                else
                {
                    texts.text = (item.Position + 1) + ". " + item.DisplayName + " " + item.StatValue;
                    Debug.Log((item.Position + 1) + " " + item.PlayFabId + " " + item.StatValue);
                    texts.color = blue;
                }

            }
        }
    }

}
