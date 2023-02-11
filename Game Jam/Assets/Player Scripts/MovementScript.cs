using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;
    public float m_Speed = 5f;

    void Start()
    {

        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }
}