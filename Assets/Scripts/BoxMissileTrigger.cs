using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMissileTrigger : MonoBehaviour
{
    public GameObject missile1;
    public GameObject missile2;
    public GameObject missile3;
    public GameObject missile4;
    //public GameObject missile1;
    //public GameObject missile1;
    // Start is called before the first frame update
    void Start()
    {/*
        missile1 = GameObject.Find("Missile1");
        missile2 = GameObject.Find("Missile2");
        missile3 = GameObject.Find("Missile3");
        missile4 = GameObject.Find("Missile4");
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            missile1.GetComponent<HomingMissile>().active = true;
            missile2.GetComponent<HomingMissile>().active = true;
            missile3.GetComponent<HomingMissile>().active = true;
            missile4.GetComponent<HomingMissile>().active = true;
        }
    }
}
