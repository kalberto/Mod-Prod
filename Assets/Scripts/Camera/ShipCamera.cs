using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCamera : MonoBehaviour
{

    private GameObject m_Player;

    public GameObject Player
    {
        get
        {
            return m_Player;
        }

        set
        {
            m_Player = value;
        }
    }

    public Vector3 m_Offset;

    //Maximo que a camera pode ir no eixo X - valor positivo
    public float m_MaxX;

    public float Speed = 5.0f;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        transform.position = CheckMaxX();
    }

    private Vector3 CheckMaxX()
    {
        Vector3 maxPos = Player.transform.position + m_Offset;
        if (maxPos.x < -m_MaxX)
        {
            maxPos.x = -m_MaxX;
        }
        if (maxPos.x > m_MaxX)
        {
            maxPos.x = m_MaxX;
        }        

        Vector3 nextPos = Vector3.Lerp(transform.position, maxPos, Time.deltaTime * Speed);

        return nextPos;
    }

}
