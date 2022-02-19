using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiButtons : MonoBehaviour
{
    
    
    private static UiButtons _instance;
    public static UiButtons Instance { get { return _instance; } }

    public Button restartButton;
    
    
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
}
