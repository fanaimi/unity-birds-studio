using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuat : MonoBehaviour
{
    private Rigidbody2D m_rb;
    private SpriteRenderer m_spriteRend;
    private Vector2 m_startPos;

    [SerializeField] private float m_speed = 1000f;
    [SerializeField] private float m_maxDragDistance = 3.5f;

    private float m_NuatRespawnDelay = 1.3f;
    
    // public property than can only be modified internally
    public bool m_IsDragging { get; private set; }
    
    


    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_spriteRend = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_rb.isKinematic = true;
        m_startPos = m_rb.position; // vector2
    }

/*
    private void OnMouseDown()
    {
        // Debug.Log("mouse down");
        m_spriteRend.color = Color.red;
        m_IsDragging = true;
    }  // OnMouseDown
    
    
    private void OnMouseUp()
    {
        // Debug.Log("mouse up");
        m_spriteRend.color = Color.white;
        Vector2 m_currentPos = m_rb.position;

        Vector2 m_direction = m_startPos - m_currentPos;
        m_direction.Normalize();
        m_rb.isKinematic = false;
        m_rb.AddForce(m_direction * m_speed);
        m_IsDragging = false;
    } // OnMouseUp
    
    private void OnMouseDrag()
    {
        Vector3 m_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 m_desiredPos = m_mousePos;
     
        // transform.position = new Vector3(m_mousePos.x, m_mousePos.y, transform.position.z);

        
        // this is to make sure the player is not dragged too much at the beginning
        float m_distance = Vector2.Distance(m_desiredPos, m_startPos);
        if (m_distance > m_maxDragDistance)
        {
            Vector2 direction = m_desiredPos - m_startPos;
            direction.Normalize();

            // setting a point on the direction at a certain distance
            m_desiredPos = m_startPos + (direction * m_maxDragDistance);
        }

        // this is to prevent the Nuat to be dragged to the right
        if (m_desiredPos.x > m_startPos.x)
        {
            m_desiredPos.x = m_startPos.x;
        }

        m_rb.position = m_desiredPos;

    } // OnMouseDrag
*/    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 1)
            return;
        var touch = Input.GetTouch(0);

        if (GameManager.Instance.isAlive && touch.phase == TouchPhase.Began)
        {
            /*Debug.Log("touch down");
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            Debug.Log(ray);
           Debug.DrawLine(ray.origin, ray.direction * 100, Color.yellow, 3f);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    Debug.Log("Hitting : " + hit.transform.name);
                }

                Debug.Log("Raycasting");
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("touched player");
                    m_spriteRend.color = Color.red;
                    Debug.Log("touched player");
                    m_IsDragging = true;
                }
            }*/
            
            m_spriteRend.color = Color.red;
            m_IsDragging = true;
            
        }
        else if (GameManager.Instance.isAlive && touch.phase == TouchPhase.Moved)
        {
            if (true) // m_IsDragging)
            {
                Vector3 m_mousePos = Camera.main.ScreenToWorldPoint(touch.position);

                Vector2 m_desiredPos = m_mousePos;

                // transform.position = new Vector3(m_mousePos.x, m_mousePos.y, transform.position.z);


                // this is to make sure the player is not dragged too much at the beginning
                float m_distance = Vector2.Distance(m_desiredPos, m_startPos);
                if (m_distance > m_maxDragDistance)
                {
                    Vector2 direction = m_desiredPos - m_startPos;
                    direction.Normalize();

                    // setting a point on the direction at a certain distance
                    m_desiredPos = m_startPos + (direction * m_maxDragDistance);
                }

                // this is to prevent the Nuat to be dragged to the right
                if (m_desiredPos.x > m_startPos.x)
                {
                    m_desiredPos.x = m_startPos.x;
                }

                m_rb.position = m_desiredPos;
            }
        }
        else if (GameManager.Instance.isAlive && touch.phase == TouchPhase.Ended)
        {
            if (true) // m_IsDragging)
            {
                AudioManager.Instance.PlayOnce("swoosh");
                // Debug.Log("mouse up");
                m_spriteRend.color = Color.white;
                Vector2 m_currentPos = m_rb.position;

                Vector2 m_direction = m_startPos - m_currentPos;
                m_direction.Normalize();
                m_rb.isKinematic = false;
                m_rb.AddForce(m_direction * m_speed);
                m_IsDragging = false;
                LevelManager.Instance.DecreaseLives();
            }
        }

    } // Update


   


    private void OnCollisionEnter2D(Collision2D collision)
    {
            StartCoroutine(ResetNuat());
       
    } // OnCollisionEnter2D



    private IEnumerator ResetNuat()
    {
        yield return new WaitForSeconds(m_NuatRespawnDelay);

        if (GameManager.Instance.CanPlay())
        {
            m_rb.isKinematic = true;
            m_rb.velocity = Vector2.zero;
            m_rb.position = m_startPos; // vector2
        }
        else
        {
            GameManager.Instance.ShowGameOver();
        }
    }



}
