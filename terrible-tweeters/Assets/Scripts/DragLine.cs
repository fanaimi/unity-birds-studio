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
    }

    // Update is called once per frame
    void Update()
    {
        m_LineRend.SetPosition(1, m_Bird.transform.position);
    }
}
