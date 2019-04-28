using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject != null && active)
        {
            Vector3 desiredPosition = new Vector3(player.transform.position.x * 0.7f, player.transform.position.y +1f, player.transform.position.z -3f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.15f);
            transform.position = smoothedPosition;
        }
    }
}
