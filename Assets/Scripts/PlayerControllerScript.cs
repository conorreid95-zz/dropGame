using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControllerScript : MonoBehaviour
{
    GameObject gameController;
    Rigidbody rigidbody;
    GameObject currentScoreText;

    bool leftRightBool = true;
    bool hasControl = true;
    bool playerVisibleAndActive = false;

    float distanceTravelled = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameManager");
        rigidbody = GetComponent<Rigidbody>();
        currentScoreText = GameObject.Find("CurrentScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerVisibleAndActive)
        {
            GetInput();
            distanceTravelled = Mathf.Abs(transform.position.y+4.55f);
        }

        if (currentScoreText)
        {
            currentScoreText = GameObject.Find("CurrentScoreText");
        }
        
    }

    private void GetInput()
    {
        if (hasControl)
        {


            float x = rigidbody.velocity.x;
            float y = rigidbody.velocity.y;
            float z = rigidbody.velocity.z;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (y < -1f)
                {
                    y = y * 0.7f;
                }
                if (leftRightBool)
                {

                    rigidbody.velocity = new Vector3(0f, y, z);
                    rigidbody.AddRelativeForce(Vector3.left * 450f * Time.deltaTime, ForceMode.VelocityChange);
                    //rigidbody.AddForce(Vector3.left * 12000f * Time.deltaTime, ForceMode.Acceleration);
                    leftRightBool = !leftRightBool;
                }
                else
                {
                    rigidbody.velocity = new Vector3(0f, y, z);
                    rigidbody.AddRelativeForce(Vector3.right * 450f * Time.deltaTime, ForceMode.VelocityChange);
                    //rigidbody.AddForce(Vector3.right * 12000f * Time.deltaTime, ForceMode.Acceleration);
                    leftRightBool = !leftRightBool;
                }
            }

            //float normY = Mathf.Abs(y);
            //float cubeY = Mathf.Pow(normY, 1f / 3f);



            //if (cubeY >= 1)
            //{
                //transform.localScale = new Vector3(5f / (2f * cubeY), 5f / (2f * cubeY), 5f / (2f * cubeY));
            //}
        }


        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasControl)
        {
            gameController.GetComponent<GameControllerScript>().ProcessNewScore(distanceTravelled);
            currentScoreText.GetComponent<TextMeshPro>().text = distanceTravelled.ToString("0");
            currentScoreText.GetComponent<MeshRenderer>().enabled = true;
            currentScoreText.transform.position = new Vector3(collision.contacts[0].point.x * 0.7f, collision.contacts[0].point.y, -1f);
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y*0.3f, rigidbody.velocity.z);
            hasControl = false;
            Invoke("ReloadLevel", 1.5f);
        }
        
        
    }

    void ReloadLevel()
    {
        gameController.GetComponent<GameControllerScript>().firstClicked = false;
        gameController.GetComponent<GameControllerScript>().LoadCurrentLevel();
    }

    public void makePlayerActive()
    {
        playerVisibleAndActive = true;
        GetComponent<MeshRenderer>().enabled = true;
        rigidbody.useGravity = true;
    }
   
}
