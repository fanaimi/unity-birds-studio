using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private SpriteRenderer m_spriteRend;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_spriteRend = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_rb.isKinematic = true;
    }


    private void OnMouseDown()
    {
        // Debug.Log("mouse down");
        m_spriteRend.color = Color.red;
    } // OnMouseDown
    
    
    private void OnMouseUp()
    {
        // Debug.Log("mouse up");
        m_spriteRend.color = Color.white;
    } // OnMouseUp
    
    private void OnMouseDrag()
    {
        
    } // OnMouseDrag
    
    
    // Update is called once per frame
    void Update()
    {
        
    } // Update

}
