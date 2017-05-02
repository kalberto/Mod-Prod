using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    [SerializeField] private float m_BaseDamage = 10.0f;
    [SerializeField] private float m_ProjectileSpeed = 500.0f;
    [SerializeField] private float m_TimeAlive = 5.0f;
    private Vector3 m_FatherSpeed;

    private Rigidbody m_Rigidbody;

    public Rigidbody Rigidbody { get { return m_Rigidbody; } set { m_Rigidbody = value; } }

    public float BaseDamage
    {
        get
        {
            return m_BaseDamage;
        }

        set
        {
            m_BaseDamage = value;
        }
    }

    public float TimeAlive
    {
        get
        {
            return m_TimeAlive;
        }

        set
        {
            m_TimeAlive = value;
        }
    }

    public Vector3 FatherSpeed
    {
        get
        {
            return m_FatherSpeed;
        }

        set
        {
            m_FatherSpeed = value;
        }
    }

    // Use this for initialization
    void Start () {
        Rigidbody = GetComponent<Rigidbody>();
        //m_Rigidbody.velocity = m_FatherSpeed;
        m_Rigidbody.AddForce(transform.forward*m_ProjectileSpeed);
    }
	
	// Update is called once per frame
	void Update () {        
        //m_Rigidbody.velocity = transform.forward * m_ProjectileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            if (other.tag == "Meteor")
            {
                Meteor meteor = other.GetComponent<Meteor>();
                meteor.TakeDamage(m_BaseDamage);
            }
            Destroy(gameObject);
        }        
    }
}
