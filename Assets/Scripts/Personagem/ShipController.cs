using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The ship needs a Rigibody
[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour {


    // Private properties ALL PRIVAT  
    [SerializeField] private float m_BaseSpees = 35.0f;
    [SerializeField] private float m_TurnSpeed = 80.0f;
    [SerializeField] private float m_Acceleration = 40.0f;
    [SerializeField] private float m_TimeBetweenShots = 0.3333f;  // Allow 3 shots per second
    private float m_Timestamp;
    private float m_IncreaseSpeed;
    private Vector3 m_currentSpeed;
    private Vector3 m_currentSideSpeed;
    private Rigidbody m_Rigidbody;
    private Gun LeftGun;
    private Gun RightGun;
    private bool RightFire;
    private bool hasGun;

    public float RollInput { get; private set; }
    public float AccelerationInput { get; private set; }

    public Rigidbody Rigidbody { get { return m_Rigidbody; } set { m_Rigidbody = value; }}


    //Maximo que a nave pode ir no eixo X - valor positivo
    public float m_MaxX;


    // Use this for initialization
    void Start () {
        Rigidbody = GetComponent<Rigidbody>();
        if(m_BaseSpees > 0)
        {
            m_IncreaseSpeed = (m_BaseSpees + m_Acceleration) / m_BaseSpees;
        }
        else
        {
            m_IncreaseSpeed = 0;
        }
        
        try
        {
            LeftGun = transform.GetChild(0).GetChild(0).GetComponent<Gun>();
            RightGun = transform.GetChild(0).GetChild(1).GetComponent<Gun>();
            RightFire = true;
            hasGun = true;
        }
        catch
        {
            hasGun = false;
        }
        
    }

    public void Move(float p_rollInput, float p_accelerationInput)
    {
        AccelerationInput = p_accelerationInput;
        RollInput = p_rollInput;

        CalculateForwardSpeed();

        CalculateRotation();

        m_Rigidbody.velocity = m_currentSpeed + m_currentSideSpeed;
    }

    public void Fire(bool fire)
    {
        if (hasGun && fire)
        {
            HandleFire();
        }
    }

    private void CalculateForwardSpeed()
    {        
        m_currentSpeed = (Vector3.forward * m_BaseSpees + Vector3.forward * m_Acceleration * AccelerationInput);
    }

    private void CalculateRotation()
    {
        Vector3 rotation = new Vector3(0, 0, -45.0f * RollInput);
        transform.rotation = Quaternion.Euler(rotation);
        m_currentSideSpeed = Vector3.right * RollInput * m_TurnSpeed*CheckMaxX();
    }

    private void HandleFire()
    {
        if (Time.time >= m_Timestamp)
        {
            m_Timestamp = Time.time + m_TimeBetweenShots;
            if (RightFire)
            {
                RightGun.Shoot();
                RightFire = false;
            }
            else
            {
                LeftGun.Shoot();
                RightFire = true;
            }
        }
    }

    private float CheckMaxX()
    {
        Vector3 maxPosition = transform.position;
        float speed = 1;
        if (RollInput < 0)
        {
            if(maxPosition.x < -m_MaxX)
            {
                maxPosition.x = -m_MaxX;
                speed = 0;
            }            
        }
        if (RollInput > 0)
        {
            if (maxPosition.x > m_MaxX)
            {
                maxPosition.x = m_MaxX;
                speed = 0;
            }            
        }

        return speed;
    }

    public float ReturnIncreaseSpeed()
    {
        return m_IncreaseSpeed;
    }

    // Update is called once per frame
    void Update () {
    }

    private void FixedUpdate()
    {
        var pos = transform.position;
        pos.y = -42.0f;
        transform.position = pos;
    }
}
