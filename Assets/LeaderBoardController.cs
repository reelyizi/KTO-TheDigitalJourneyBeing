using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    [SerializeField] private Transform entryContainer,entryTemplate;
    [SerializeField] private TMP_InputField nameText,coinText;
    private List<Transform> highScoreEntriesEntryList;
    private List<GameObject> templates;

    
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        entryTemplate.gameObject.SetActive(false);
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            AddHighscoreEntry(10, "Engin");
            AddHighscoreEntry(10, "Semih");
            AddHighscoreEntry(10, "Batuhan");
            AddHighscoreEntry(10, "Bora");
            AddHighscoreEntry(10, "Can");
            AddHighscoreEntry(10, "Çağatay");
            AddHighscoreEntry(10, "Oğuz");
            AddHighscoreEntry(10, "Şahin");
            AddHighscoreEntry(10, "Ahmet");
            AddHighscoreEntry(10, "Veli");
            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        // Sort entry list by Score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highScoreEntriesEntryList=new List<Transform>();
        templates=new List<GameObject>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highScoreEntriesEntryList);
        }
    }
    void Start()
    {
    }
    public void AddValue()
    {
        AddHighscoreEntry(int.Parse(coinText.text),nameText.text);
        // Sort entry list by Score
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        highScoreEntriesEntryList=new List<Transform>();
        if(templates.Count>0)
        {
            ClearTable();
        }
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highScoreEntriesEntryList);
        }
    }
    private void ClearTable()
    {
        for(int i=0;i<templates.Count;i++)
        {
            Destroy(templates[i].gameObject);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        if(transformList.Count>9)
            return;
        Transform entryTransform=Instantiate(entryTemplate,container);
        entryTransform.gameObject.SetActive(true);

        int rank=transformList.Count+1;
        int score=highscoreEntry.score;
        string name=highscoreEntry.name;
        entryTransform.GetChild(0).GetComponent<TextMeshProUGUI>().text=rank.ToString();
        entryTransform.GetChild(1).GetComponent<TextMeshProUGUI>().text=name;
        entryTransform.GetChild(2).GetComponent<TextMeshProUGUI>().text=score.ToString();

        transformList.Add(entryTransform);
        templates.Add(entryTransform.gameObject);
    }
        public void AddHighscoreEntry(int score,string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        
        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) {
            // There's no stored table, initialize
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }
        int check=0,index=0;
        for(int i=0;i<highscores.highscoreEntryList.Count;i++)
        {
            if(highscores.highscoreEntryList[i].name==name)
            {
                check=1;
                index=i;
            }
        }
        if(check==1)
        {
            //Update 
            highscores.highscoreEntryList[index].score=score;
        }
        else
        {
            // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);
        }
        

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable] 
    private class HighscoreEntry {
        public int score;
        public string name;
    }
}
