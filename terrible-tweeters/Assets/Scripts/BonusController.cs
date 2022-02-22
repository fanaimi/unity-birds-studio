using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    
    
    [SerializeField] private GameObject m_heartPrefab;
    
    
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
        if (other.CompareTag("Player"))
        {
            LevelManager.Instance.UpdateLives(3);
            GameObject heart = Instantiate(m_heartPrefab, transform.position, transform.rotation);
            Destroy(heart, 1f);
            Destroy(gameObject);
        }
    }


}
