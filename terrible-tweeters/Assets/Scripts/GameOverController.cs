using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{

    private static GameOverController _instance;
    public static GameOverController Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }


        // we want audioManager to persist through different scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // HideGameOver();
    }

    public void OnRestartPressed()
    {
        Debug.Log("OnRestartPressed - restart button pressed");
        GameManager.Instance.HideGameOver();
    }


}
