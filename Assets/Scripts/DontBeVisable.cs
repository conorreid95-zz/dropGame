using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontBeVisable : MonoBehaviour
{
    GameObject gameController;
    bool finishedJob = false;

    private void Awake()
    {
        gameController = GameObject.Find("GameManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!finishedJob)
        {
            if (gameController.GetComponent<GameControllerScript>().started)
            {
                GetComponent<MeshRenderer>().enabled = false;
                finishedJob = true;
            }
        }
    }
    
}
