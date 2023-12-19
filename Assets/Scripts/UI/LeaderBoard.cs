using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderBoardKey = "ca06c234e4013f92c018675b676afb30f4cf492bc3cce1d5cbbbbb48799b769b";

    private void Start()
    {
        GetLeaderBoard();
    }
    public void GetLeaderBoard()
    {
        
        LeaderboardCreator.GetLeaderboard(publicLeaderBoardKey, ((msg) =>
        {
            Debug.Log(msg.Length);
            for (int i =0; i< names.Count; i++)
            {
               // if(i < msg.Length){
                    names[i].text = msg[i].Username;
                    scores[i].text = msg[i].Score.ToString();
              /*  }
                else
                {
                    names[i].gameObject.SetActive(false);
                    scores[i].gameObject.SetActive(false);
                }*/
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        Leaderboards.DemoSceneLeaderboard.UploadNewEntry(username, score);
        //LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, score);
        /*
        LeaderboardCreator.UploadNewEntry(publicLeaderBoardKey, username, score, ((msg) =>
        {
            //if(System.Array.IndexOf())
            GetLeaderBoard();
        }));*/
        GetLeaderBoard();
    }
    private void Callback(bool success)
    {
       // if (success)
           // Load();
    }

    private void ErrorCallback(string error)
    {
        Debug.LogError(error);
    }
}
