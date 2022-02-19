using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    
    
    
    private Button m_RestartButton;
    
    /*private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }*/

    private void OnEnable()
    {
        Debug.Log("enabled");
        SetUpButtons();
    }

    private void SetUpButtons()
    {
        Debug.Log("setting up buttons");
        m_RestartButton = UiButtons.Instance.restartButton;
        m_RestartButton.onClick.AddListener(RestartLevel);
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log($"restarting {scene.name}");
        SceneManager.LoadScene(scene.name);
    }
}
