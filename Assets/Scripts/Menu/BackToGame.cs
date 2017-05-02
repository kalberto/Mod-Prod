using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGame : MonoBehaviour {

    private GameObject m_Player;
    public void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void UnPause()
    {
        m_Player.GetComponent<ShipUserControl>().IsPaused = false;
        Time.timeScale = 1;
    }
}
