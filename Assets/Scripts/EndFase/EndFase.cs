using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFase : MonoBehaviour {

    [SerializeField] private GameObject m_EndGame;

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

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndGame()
    {
        Time.timeScale = 0;
        m_EndGame.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Corner")
        {
            if (other.tag == "Player")
            {
                EndGame();
            }
            else
            {
                Destroy(other);
            }
        }
    }
}
