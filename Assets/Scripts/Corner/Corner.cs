using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Corner")
        {
            if(other.tag == "Player")
            {
                //VOCE GANHOU, PARABENS
            }
            else
            {
                Destroy(other);
            }
        }
    }
}
