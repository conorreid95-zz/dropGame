using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomingMissile : MonoBehaviour
{
    public Transform target;

    private Rigidbody rb;
    public float speed = 5f;
    public float rotateSpeed = 2f;
    bool once = false;
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {


            Vector3 direction = target.position - transform.position;
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);

            //rb.transform.LookAt(target, new Vector3(0,0,1));
            rb.velocity = transform.forward * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!once && active)
        {
            transform.GetChild(4).GetComponent<ParticleSystem>().Play();
            transform.GetChild(4).transform.parent = null;
            Destroy(gameObject);
            once = true;
        }
    }
}
