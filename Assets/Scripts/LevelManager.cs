using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text text;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        int currentScneneIndex = SceneManager.GetActiveScene().buildIndex;
        int levelScene = currentScneneIndex + 1;
        text.text = "Level " + levelScene;
    }
}
