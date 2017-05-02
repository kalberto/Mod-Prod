using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Meteor : MonoBehaviour {

    [SerializeField] private float m_Life;
    [SerializeField] private int m_Size;
    [SerializeField] private int m_Score;
    [SerializeField] private float m_StarForceMultiplier = 1;
    [SerializeField] public float m_BaseDamage = 30;
    private bool m_hasDied = false;

    public int Size
    {
        get
        {
            return m_Size;
        }

        set
        {
            m_Size = value;
        }
    }

    public int Score
    {
        get
        {
            return m_Score;
        }

        set
        {
            m_Score = value;
        }
    }

    // Use this for initialization
    void Start () {
        if (m_StarForceMultiplier <= 0)
        {
            m_StarForceMultiplier = 1;
        }
        CheckSize();
        float force = 12000;
        Vector3 randTorque = new Vector3(Random.Range(-force * m_Size, force * m_Size), Random.Range(-force * m_Size, force * m_Size), Random.Range(-force * m_Size, force * m_Size));
        Vector3 randForce = new Vector3(Random.Range(-force * m_Size, force * m_Size), Random.Range(-force * m_Size, force * m_Size), Random.Range(-force * m_Size, force * m_Size));
        GetComponent<Rigidbody>().AddTorque(randTorque * m_StarForceMultiplier);
        GetComponent<Rigidbody>().AddForce(randForce * m_StarForceMultiplier*2);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void TakeDamage(float p_damage)
    {
        if ((m_Life - p_damage) <= 0)
        {
            m_Life = 0.0f;
            Die();
        }
        else
        {
            m_Life -= p_damage;
        }

        if(m_Life == 0)
        {
            Die();
        }
    }

    //Implementar
    private void Die()
    {
        if (!m_hasDied)
        {
            transform.parent.GetComponent<MeteorManager>().HandleDeath(this);
            Destroy(gameObject);
            m_hasDied = true;
        }        
    }

    private void CheckSize()
    {
        if (m_Size > 5)
        {
            m_Size = 5;
        }
        if (m_Size < 1)
        {
            m_Size = 1;
        }
    }
}
