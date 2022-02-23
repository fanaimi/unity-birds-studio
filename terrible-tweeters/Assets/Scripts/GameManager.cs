using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private float m_score;
    
    public bool isAlive;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
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
        DontDestroyOnLoad(gameObject);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_score = 0;
        UIcontroller.Instance.ShowScore(m_score);
        AudioManager.Instance.Play("game");
        HideGameOver();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float scoreToAdd)
    {
        m_score += scoreToAdd;
        UIcontroller.Instance.ShowScore(m_score);
    }


    public void ShowGameOver()
    {
        Debug.Log("showing game over");
        isAlive = false;
        GameOverController.Instance.gameObject.SetActive(true);
    } // showGameOver
    
    
    public void HideGameOver()
    {
        // Debug.Log("hiding game over");

        GameOverController.Instance.gameObject.SetActive(false);
        // reloading current scene
        SceneManager.LoadScene("Level1");
    } // sHideGameOver
    
    
    
}
