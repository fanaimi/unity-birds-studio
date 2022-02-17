using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{

    private LineRenderer m_LineRend;
    private Nuat m_Nuat;


    // Start is called before the first frame update
    void Start()
    {
        m_LineRend = GetComponent<LineRenderer>();
        m_Nuat = FindObjectOfType<Nuat>();
        Vector3 lineStartPos = new Vector3(
            m_Nuat.transform.position.x,
            m_Nuat.transform.position.y,
            -.1f
        );
        m_LineRend.SetPosition(0, lineStartPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Nuat.m_IsDragging)
        {
            m_LineRend.enabled = true;
            m_LineRend.SetPosition(1, m_Nuat.transform.position);
        }
        else
        {
            m_LineRend.enabled = false;
        }
    }
}
