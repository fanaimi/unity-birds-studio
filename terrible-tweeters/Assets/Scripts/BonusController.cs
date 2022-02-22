using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestroy", 4f);       
    }


    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("qwe");
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.UpdateLives(3);
            Destroy(gameObject);
        }
    }


}
