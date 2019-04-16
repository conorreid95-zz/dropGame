using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    GameObject player;

    GameObject tapText;
    GameObject toText;
    GameObject startText;

    Camera mainCamera;

    GameObject highScoreText;
    GameObject currentScoreText;

    public bool started = false;
    public bool firstClicked = false;
    public bool showHighScore = false;

    float highScore = 0f;
    float currentScore = 0f;

    void Start()
    {
        player = GameObject.Find("Player");
        DontDestroyOnLoad(this);

        mainCamera = Camera.main;

        tapText = GameObject.Find("TapText");
        toText = GameObject.Find("ToText");
        startText = GameObject.Find("StartText");

        highScoreText = GameObject.Find("HighScoreText");
        currentScoreText = GameObject.Find("CurrentScoreText");
        highScore = PlayerPrefs.GetFloat("highScore", 0f);
        if(highScore > 0.01f)
        {
            highScoreText.GetComponent<TextMeshPro>().text = "High Score: " + highScore.ToString("0");
            highScoreText.GetComponent<MeshRenderer>().enabled = true;
        }
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    

    private void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (tapText == null)
        {
            tapText = GameObject.Find("TapText");
        }

        if (toText == null)
        {
            toText = GameObject.Find("ToText");
        }

        if (startText == null)
        {
            startText = GameObject.Find("StartText");
        }

        if (highScoreText == null)
        {
            highScoreText = GameObject.Find("HighScoreText");
            if (highScore > 0.01f || showHighScore)
            {
                highScoreText.GetComponent<TextMeshPro>().text = "High Score: " + highScore.ToString("0");
                highScoreText.GetComponent<MeshRenderer>().enabled = true;
            }

        }

        if (currentScoreText == null)
        {
            currentScoreText = GameObject.Find("CurrentScoreText");
        }

        if (!firstClicked || !started)
        {
            CheckForFirstClick();
        }




        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(player.transform.position.x, player.transform.position.y - 13.84f, player.transform.position.z - 26.88f);
            Vector3 smoothedPosition = Vector3.Lerp(mainCamera.transform.position, desiredPosition, 0.10f);
            mainCamera.transform.position = smoothedPosition;

        }
        
    }

    public void CheckForFirstClick()
    {
        if (!started && !firstClicked)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                tapText.GetComponent<MeshRenderer>().enabled = false;
                toText.GetComponent<MeshRenderer>().enabled = false;
                startText.GetComponent<MeshRenderer>().enabled = false;
                highScoreText.GetComponent<MeshRenderer>().enabled = false;
                showHighScore = false;
                started = true;
                firstClicked = true;
                player.GetComponent<PlayerControllerScript>().makePlayerActive();
            }
        }
        else if(started && !firstClicked)
        {
            player.GetComponent<MeshRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                started = true;
                firstClicked = true;
                showHighScore = false;
                highScoreText.GetComponent<MeshRenderer>().enabled = false;
                player.GetComponent<PlayerControllerScript>().makePlayerActive();
            }
        }
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(0);

    }

    public void ProcessNewScore(float newScore)
    {
        if(newScore > highScore)
        {
            highScore = newScore;
            PlayerPrefs.SetFloat("highScore", highScore);
        }
    }
}
