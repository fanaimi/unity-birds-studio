using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] string m_nextLevelName;
    
    
    private static GameManager _instance;
    public Monster[] m_monsters;
    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        Debug.Log("awakening");
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
        Debug.Log("enabled");
        m_monsters = FindObjectsOfType<Monster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MonstersAreAllDead())
        {
            // DO NOT FORGET TO ADD SCENES FOR ALL OUR LEVELS TO FILE > BUILD SETTINGS
            SceneManager.LoadScene(m_nextLevelName);
            Debug.Log($"Go to level {m_nextLevelName}");
            // GoToNextLevel();
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
        
    } // GoToNextLevel

}
