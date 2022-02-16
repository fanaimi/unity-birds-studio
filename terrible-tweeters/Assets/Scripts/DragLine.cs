using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{

    private LineRenderer m_LineRend;
    private Bird m_Bird;


    // Start is called before the first frame update
    void Start()
    {
        m_LineRend = GetComponent<LineRenderer>();
        m_Bird = FindObjectOfType<Bird>();
        Vector3 lineStartPos = new Vector3(
            m_Bird.transform.position.x,
            m_Bird.transform.position.y,
            -.1f
        );
        m_LineRend.SetPosition(0, lineStartPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Bird.m_IsDragging)
        {
            m_LineRend.enabled = true;
            m_LineRend.SetPosition(1, m_Bird.transform.position);
        }
        else
        {
            m_LineRend.enabled = false;
        }
    }
}
