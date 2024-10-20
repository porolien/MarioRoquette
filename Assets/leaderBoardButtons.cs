using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class leaderBoardButtons : MonoBehaviour
{
    public void goToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void retry()
    {
        StartCoroutine( FindObjectOfType<PlayerController>().Retry());
    }

    private void Awake()
    {

        /*transform.Find("New/LeftPanel/LeaderboardControlMenu/LeaderboardControlMenu/ReturnToMenu").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        transform.Find("New/LeftPanel/LeaderboardControlMenu/LeaderboardControlMenu/ReturnToMenu").gameObject.GetComponent<Button>().onClick.AddListener(goToMenu);

        transform.Find("New/LeftPanel/LeaderboardControlMenu/LeaderboardControlMenu/RetryButton").gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        transform.Find("New/LeftPanel/LeaderboardControlMenu/LeaderboardControlMenu/RetryButton").gameObject.GetComponent<Button>().onClick.AddListener(retry);*/
    }

}
