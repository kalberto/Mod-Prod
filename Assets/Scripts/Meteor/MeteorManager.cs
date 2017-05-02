using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour {

    [SerializeField] GameObject m_MeteorSmall;
    [SerializeField] GameObject m_MeteorMedium;
    [SerializeField] GameObject m_MeteorLarge;
    [SerializeField] GameObject m_MeteorExtraLarge;
    [SerializeField] GameObject m_MeteorSuperDuper;
    private GameObject m_Player;

    // Use this for initialization
    void Start () {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleDeath(Meteor p_meteor)
    {
        m_Player.GetComponent<ShipUserControl>().UpdateScore(p_meteor.Score);
        if(p_meteor.Size == 1)
        {
        }
        else
        {
            int meteorToInstantiateSize = Random.Range((int)1,(int)(p_meteor.Size-1));
            int numberOfMeteors = (p_meteor.Size - 1) / meteorToInstantiateSize;
            int leftOver = (p_meteor.Size -1) - numberOfMeteors * meteorToInstantiateSize;
            Vector3 meteorPosition = p_meteor.transform.position;
            Quaternion meteorRotation = p_meteor.transform.rotation;

            for (int i = 1; i <= numberOfMeteors; i++)
            {
                InstantiateMeteor(meteorToInstantiateSize, meteorPosition, meteorRotation);
            }
            if(leftOver == 1)
            {
                InstantiateMeteor(leftOver, meteorPosition, meteorRotation);
            }
        }
    }

    //Handle Meteor Instantiation
    private void InstantiateMeteor(int p_size, Vector3 p_pos, Quaternion p_rot)
    {
        if (p_size == 1)
        {
            InstantiateSmall(p_pos, p_rot);
        }
        else if (p_size == 2)
        {
            InstantiateMedium(p_pos, p_rot);
        }
        else if (p_size == 3)
        {
            InstantiateLarge(p_pos, p_rot);
        }
        else if (p_size == 4)
        {
            InstantiateExtraLarge(p_pos, p_rot);
        }
        else if (p_size == 5)
        {
            InstantiateSuperDuper(p_pos, p_rot);
        }
    }

    #region Instantiate Meteor

    private void InstantiateSmall(Vector3 p_pos, Quaternion p_rot)
    {
        GameObject Meteor = Instantiate(m_MeteorSmall, p_pos, p_rot);
        Meteor.transform.parent = transform;
    }

    private void InstantiateMedium(Vector3 p_pos, Quaternion p_rot)
    {
        GameObject Meteor = Instantiate(m_MeteorMedium, p_pos, p_rot);
        Meteor.transform.parent = transform;
    }

    private void InstantiateLarge(Vector3 p_pos, Quaternion p_rot)
    {
        GameObject Meteor = Instantiate(m_MeteorLarge, p_pos, p_rot);
        Meteor.transform.parent = transform;
    }

    private void InstantiateExtraLarge(Vector3 p_pos, Quaternion p_rot)
    {
        GameObject Meteor = Instantiate(m_MeteorExtraLarge, p_pos, p_rot);
        Meteor.transform.parent = transform;
    }

    private void InstantiateSuperDuper(Vector3 p_pos, Quaternion p_rot)
    {
        GameObject Meteor = Instantiate(m_MeteorSuperDuper, p_pos, p_rot);
        Meteor.transform.parent = transform;
    }

#endregion

}
