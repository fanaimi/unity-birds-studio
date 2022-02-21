using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        GameOverController.Instance.HideGameOver();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
    public void Restart()
    {
        GameOverController.Instance.HideGameOver();
        isAlive = true;
        SceneManager.LoadScene("Level1");   
    }
    
}
