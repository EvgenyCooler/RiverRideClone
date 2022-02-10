using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [SerializeField] private string levelSceneName = "LevelScene";
    void Start()
    {
        SceneManager.LoadSceneAsync(levelSceneName, LoadSceneMode.Single);        
    }

}
