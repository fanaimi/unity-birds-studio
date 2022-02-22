using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    // [SerializeField] string m_nextLevelName;
    [SerializeField] public int m_currentLevel;
    [SerializeField] public GameObject m_AjPrefab;
    
    
    public Monster[] m_monsters;
    
    public int m_CurrentlLives;
    
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }
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
        
        // if we want this to survive throughout different levels and scenes
        // DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        GameManager.Instance.isAlive = true;
    }


    private void Start()
    {
        // Debug.Log("enabled");
        m_monsters = FindObjectsOfType<Monster>();
        UpdateLives(3);
        GameManager.Instance.isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
        {
            // Debug.Log($"Go to level {m_nextLevelName}");
            GoToNextLevel();
        }
    } // Update
    
    private bool MonstersAreAllDead()
    {
        foreach (Monster aMonster in m_monsters)
        {
            // checking if the game object is ACTIVE
            if (aMonster && aMonster.gameObject.activeSelf)
            {
                return false;
            }
        }
        // they are all dead
        return true;
    } // MonstersAreAllDead
    
    private void GoToNextLevel()
    {
        // DO NOT FORGET TO ADD SCENES FOR ALL OUR LEVELS TO FILE > BUILD SETTINGS
        SceneManager.LoadScene($"Level{m_currentLevel+1}");
    } // GoToNextLevel

    public void UpdateLives(int numOfLives)
    {
        m_CurrentlLives = numOfLives;
        UIcontroller.Instance.ShowLivesLeft(m_CurrentlLives);
    }
    
    public void DecreaseLives()
    {
        if (m_CurrentlLives >= 1)
        {
            m_CurrentlLives -=1;
            UIcontroller.Instance.ShowLivesLeft(m_CurrentlLives);
        }
        else
        {
            GameManager.Instance.isAlive = false;
            GameManager.Instance.ShowGameOver();
        }

    }

}
