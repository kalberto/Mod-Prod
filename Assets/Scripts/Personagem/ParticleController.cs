using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleController : MonoBehaviour {


    [SerializeField] private ParticleSystem m_Stars;

    //Porcentagem
    [SerializeField] private float m_IncreaseSpeedBy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AlterSpeed(float p_value)
    {
        float value = p_value;
        if(value > 0)
        {
            value += 1;
        }
        else
        {
            value = 1;
        }
        var main = m_Stars.main;
        main.simulationSpeed = value;
    }

    public void Move(float throttle)
    {
        Vector3 pos = m_Stars.transform.position;
        pos.z = transform.position.z;
        m_Stars.transform.position = pos;
        AlterSpeed(throttle);
    }
}
