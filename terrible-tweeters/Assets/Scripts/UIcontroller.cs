using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    // DO NOT FORGET TO KEEP THE EVENT SYSTEM GAME OBJECT IN THE CANVAS OR THE BUTTON WILL NOT WORK!
    
    
    private Button m_RestartButton;
    
    private void Start()
    {
        // Debug.Log("starting ui controller");
        SetUpButtons();
    }

    private void SetUpButtons()
    {
        // Debug.Log("setting up buttons");
        m_RestartButton = UiButtons.Instance.restartButton;
        m_RestartButton.onClick.AddListener(RestartLevel);
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        // Debug.Log($"restarting {scene.name}");
        SceneManager.LoadScene(scene.name);
    }
}
