using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// makes sure we select this and not any of its childrem
[SelectionBase]
public class Monster : MonoBehaviour
{
    [SerializeField] private Sprite m_deadSprite;
    [SerializeField] private ParticleSystem m_monsterDeathParticleSystem;

    private bool m_hasDied;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine( Die() );
        }

    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        // don't die multiple times
        if (m_hasDied) return false;
        
        Nuat nuat = collision.gameObject.GetComponent<Nuat>();
        if (nuat != null)
        {
            return true;
        }
       
        // if something falls on the monster from above
        // contacts is an array of objects hit by the object 
        // normal.y => 0 means horizontal (from right), -1 vertical (from above)
        if (collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }

        return false;
        

    } // ShouldDieFromCollision


    private IEnumerator Die()
    {
        m_hasDied = true;
        GetComponent<SpriteRenderer>().sprite = m_deadSprite;
        m_monsterDeathParticleSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }

}
