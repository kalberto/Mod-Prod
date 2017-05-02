using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject m_Bullet;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Use Instantiate
    public void Shoot()
    {

        GameObject bullet = Instantiate(m_Bullet, transform.position, m_Bullet.transform.rotation);
        bullet.GetComponent<Bullet>().FatherSpeed = transform.parent.parent.GetComponent<ShipController>().Rigidbody.velocity;
        Destroy(bullet, bullet.GetComponent<Bullet>().TimeAlive);
    }
}
