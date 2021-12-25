using GleyInternetAvailability;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InternetAvailabilityTest : MonoBehaviour
{
    //make public references for text field
    public TextMeshProUGUI result,loading;
    public Button checkConnection,goOffline;
    public static bool gameOffline=true;
    //create public method for button
    void Start()
    {
        loading.gameObject.SetActive(false);
        checkConnection.gameObject.SetActive(false);
        goOffline.gameObject.SetActive(false);
        CheckConnection();
    }
    public void CheckConnection()
    {
        
        GleyInternetAvailability.Network.IsAvailable(CompleteMethod);
    }

    //this method will be automatically called when check is complete
    private void CompleteMethod(ConnectionResult connectionResult)
    {
        //if connection result is "Working" user has Internet access not just his card enabled
        if(connectionResult == ConnectionResult.Working)
        {
            result.text = "Network connection is available";
            //GameObject.Find("GameManager").GetComponent<GameManager>().gameNetworkStatus=GameManager.GameNetworkStatus.online;
            MenuPlayFabManager.networkTestFinished=true;
            gameOffline=false;
            Invoke(nameof(GoToMenu),0.5f);
        }
        else
        {
            checkConnection.gameObject.SetActive(true);
            goOffline.gameObject.SetActive(true);
            result.text = "Network is not reachable";
        }

        //this will tell you more details about the connection
        //message.text = connectionResult.ToString();
    }
    public void CheckConnectionAgain()
    {
        loading.gameObject.SetActive(false);
        checkConnection.gameObject.SetActive(false);
        goOffline.gameObject.SetActive(false);
        CheckConnection();

    }
    public void GoToMenu()
    {
        this.gameObject.SetActive(false);
    }
    public void GoOffline()
    {
        //GameObject.Find("GameManager").GetComponent<GameManager>().gameNetworkStatus=GameManager.GameNetworkStatus.offline;
        MenuPlayFabManager.networkTestFinished=false;
        gameOffline=true;
        SceneManager.LoadScene(1);
    }
}
