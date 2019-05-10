using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideVelocity : MonoBehaviour
{

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(0f, 0f, 0f);
        //rigidbody.AddRelativeForce(Vector3.left * 450f * Time.deltaTime, ForceMode.VelocityChange);
        rigidbody.AddRelativeForce(Vector3.left * 7.5f, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
