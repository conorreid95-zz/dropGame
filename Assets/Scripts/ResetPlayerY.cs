using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerY : MonoBehaviour
{
    [SerializeField] public Vector3 resetPosition;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //gameObject.GetComponent<TrailRenderer>().Clear();
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        gameObject.GetComponent<Rigidbody>().transform.position = resetPosition;
        gameObject.GetComponent<TrailRenderer>().Clear();
    }
}
