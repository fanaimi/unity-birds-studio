using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (ShouldDieFromCollision(collision))
        {
            Die();
        }

    }

    private bool ShouldDieFromCollision(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
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


    private void Die()
    {
        gameObject.SetActive(false);
    }

}
