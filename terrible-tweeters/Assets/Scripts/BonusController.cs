using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    
    
    [SerializeField] private GameObject m_heartPrefab;
    private float m_bonusScore = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("bling");
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
            GameManager.Instance.AddScore(m_bonusScore);
            AudioManager.Instance.Play("heart");
            LevelManager.Instance.UpdateLives(3);
            GameObject heart = Instantiate(m_heartPrefab, transform.position, transform.rotation);
            Destroy(heart, 1f);
            Destroy(gameObject);
        }
    }


}
