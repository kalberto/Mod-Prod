using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShipController))]
public class ShipUserControl : MonoBehaviour {

    //Private 
    [SerializeField] private float m_Life;
    [SerializeField] private int m_Score;

    // these max angles are only used on mobile, due to the way pitch and roll input are handled
    public float maxRollAngle = 80;
    public float maxPitchAngle = 80;

    private ShipController m_Ship;
    [SerializeField] private GameObject m_MainMenu;
    [SerializeField] private GameObject m_EndGame;
    private bool m_isPaused = false;
    private bool m_Won = false;

    private ParticleController m_Stars;

    public bool IsPaused
    {
        get
        {
            return m_isPaused;
        }

        set
        {
            m_isPaused = value;
        }
    }

    //Canvas Score and Life
    public Text m_TextScore;
    public Text m_TextLife;
    private bool m_HasCanvas;

    private void Awake()
    {
        //star time
        Time.timeScale = 1;
        // Set up the reference to the aeroplane controller.
        m_Ship = GetComponent<ShipController>();
        m_Stars = GetComponent<ParticleController>();

        UpdateTextLife();
        UpdateTextScore();
    }

    //REVISAR-----------------------------------------------------------------------------
    private void FixedUpdate()
    {
        // Read input for the pitch, yaw, roll and throttle of the aeroplane.
        float roll = Input.GetAxis("Horizontal");
        float throttle = Input.GetAxis("Vertical");
        bool fire = Input.GetButton("Fire1");        
        
        // Pass the input to the aeroplane
        m_Ship.Move(roll, throttle);
        m_Stars.Move(GetComponent<ShipController>().ReturnIncreaseSpeed()*throttle);
        m_Ship.Fire(fire);
        
    }

    private void Update()
    {
        if (!m_Won)
        {
            bool pause = Input.GetButtonDown("Cancel");
            if (pause)
            {
                if (!IsPaused)
                {
                    Time.timeScale = 0;
                    m_MainMenu.SetActive(true);
                    IsPaused = true;
                }
                else
                {
                    Time.timeScale = 1;
                    m_MainMenu.SetActive(false);
                    IsPaused = false;
                }

            }
        }       
    }

    public void UpdateScore(int p_value)
    {
        m_Score += p_value;
        UpdateTextScore();
    }

    private void UpdateTextScore()
    {
        try
        {
            m_TextScore.text = "Score: " + m_Score;
        }
        catch
        {
            Debug.Log("Nenhum Texto de Score para mudar");
        }       
    }

    private void UpdateTextLife()
    {
        try
        {
            m_TextLife.text = "Life: " + m_Life;
        }
        catch
        {
            Debug.Log("Nenhum Texto de Life para mudar");
        }
    }

    private void TakeDamage(float p_damage)
    {
        if((m_Life - p_damage) <= 0)
        {
            m_Life = 0.0f;
            Die();
        }
        else
        {
            m_Life -= p_damage;
        }
        UpdateTextLife();
    }


    //Implementar
    private void Die()
    {
        EndFase end = m_EndGame.GetComponent<EndFase>();
        end.EndGame();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Meteor")
        {
            Meteor meteor = collision.transform.GetComponent<Meteor>();
            TakeDamage(meteor.m_BaseDamage*meteor.Size);
            Destroy(meteor);
        }
    }
}