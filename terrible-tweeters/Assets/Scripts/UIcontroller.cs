using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    // DO NOT FORGET TO KEEP THE EVENT SYSTEM GAME OBJECT IN THE CANVAS OR THE BUTTON WILL NOT WORK!

    // [SerializeField] 
    private List<GameObject> m_LifeIcons;
    
    private Button m_RestartButton;

    private static UIcontroller _instance;
    public static UIcontroller Instance { get { return _instance; } }

    [SerializeField] private TMP_Text m_currentLevelTxt;
    [SerializeField] private TMP_Text m_currentScoreTxt;
    [SerializeField] private TMP_Text m_timeLeftTxt;
    private void Awake()
    {
        // Debug.Log("awakening");
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        
    }
    
    private void Start()
    {
        // Debug.Log("starting ui controller");
        SetUpButtons();
        ShowLivesLeft(3);
        ShowLevel();
        ShowScore(GameManager.Instance.m_score);
    }

    private void ShowLevel()
    {
        m_currentLevelTxt.text = LevelManager.Instance.m_currentLevel.ToString();
    }


    private void SetUpButtons()
    {
        // Debug.Log("setting up buttons");
        m_RestartButton = UiButtons.Instance.restartButton;
        m_RestartButton.onClick.AddListener(RestartLevel);
        // m_RestartButton.;
    }

    public void RestartLevel()
    {
        AudioManager.Instance.PlayOnce("scream");
        Scene scene = SceneManager.GetActiveScene();
        // Debug.Log($"restarting {scene.name}");
        SceneManager.LoadScene(scene.name);
    }

    public void ShowLivesLeft(int numOfLives)
    {
        foreach (GameObject LifeIcon in LivesHolder.Instance.LifeIcons)
        {
            if (LifeIcon)
            {
                LifeIcon.SetActive(false);
            }
        }
        
        // Debug.Log($"showing lives left: {numOfLives}");
        for (int i = 0; i < numOfLives; i++)
        {
            if (LivesHolder.Instance.LifeIcons[i])
            {
                LivesHolder.Instance.LifeIcons[i].SetActive(true);
            }
        }
    }


    public void ShowScore(float scoreToDisplay)
    {
        int scoreInt = Mathf.RoundToInt(scoreToDisplay);
        m_currentScoreTxt.text = scoreInt.ToString();
    }


    public void ShowTimeLeft(float timeLeft)
    {
        int time = Mathf.RoundToInt(timeLeft);
        m_timeLeftTxt.text = time.ToString();
    }


}
