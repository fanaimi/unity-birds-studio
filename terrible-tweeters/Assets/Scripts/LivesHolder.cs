using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesHolder : MonoBehaviour
{
    private static LivesHolder _instance;
    public static LivesHolder Instance { get { return _instance; } }


    
    [SerializeField] 
    public List<GameObject> LifeIcons;
    
    
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

}
