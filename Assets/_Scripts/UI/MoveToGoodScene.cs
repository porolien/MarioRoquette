using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToGoodScene : MonoBehaviour
{
    public void MoveToLevel(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
    }
}
