using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControllerScript : MonoBehaviour
{
    GameObject gameController;
    Rigidbody rigidbody;
    GameObject currentScoreText; //text for showing score on death
    GameObject currentTimeText; //text for showing time on level completion


    bool leftRightBool = true; //used to alternate left/right mvmt
    bool hasControl = true; //for taking control away when player hits object
    bool playerVisibleAndActive = false;
    bool newScoreShowing = false; //bool for the score that shows when player dies
    bool newTimeShowing = false; //bool for the time that shows when player completets level

    float startTime = 0f;
    float completedTime = 0f;
    float distanceTravelled = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameManager");
        rigidbody = GetComponent<Rigidbody>();
        currentScoreText = GameObject.Find("CurrentScoreText");
        currentTimeText = GameObject.Find("CurrentTimeText");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerVisibleAndActive) //if player has control
        {
            GetInput(); //check for clicks to move left and right
            distanceTravelled = Mathf.Abs(transform.position.y + 4.55f); //keep record of distance travelled for scoring
        }

        if (currentScoreText == null) //look for new score text if null
        {
            currentScoreText = GameObject.Find("CurrentScoreText");
        }
        else if (newScoreShowing) //if have ref to scoreText, and it is visible as player just died...
        {
            currentScoreText.transform.Translate(Vector3.back * 8f * Time.deltaTime); //move score text for effect
            currentScoreText.transform.Translate(Vector3.down * 2f * Time.deltaTime);
        }

        if (currentTimeText == null) //look for new score text if null
        {
            currentTimeText = GameObject.Find("CurrentTimeText");
        }
        else if (newTimeShowing) //if have ref to scoreText, and it is visible as player just died...
        {
            currentTimeText.transform.Translate(Vector3.back * 8f * Time.deltaTime); //move score text for effect
            currentTimeText.transform.Translate(Vector3.down * 2f * Time.deltaTime);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
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
                if (y < -1.5f)
                {
                    y = y * 0.7f;
                }
                if (leftRightBool)
                {

                    rigidbody.velocity = new Vector3(0f, y, z);
                    //rigidbody.AddRelativeForce(Vector3.left * 450f * Time.deltaTime, ForceMode.VelocityChange);
                    rigidbody.AddRelativeForce(Vector3.left * 7.5f, ForceMode.VelocityChange);
                    //rigidbody.AddForce(Vector3.left * 12000f * Time.deltaTime, ForceMode.Acceleration);
                    leftRightBool = !leftRightBool;
                }
                else
                {
                    rigidbody.velocity = new Vector3(0f, y, z);
                    //rigidbody.AddRelativeForce(Vector3.right * 450f * Time.deltaTime, ForceMode.VelocityChange);
                    rigidbody.AddRelativeForce(Vector3.right * 7.5f, ForceMode.VelocityChange);
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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasControl) //if collided and not dead yet
        {
            if (collision.gameObject.tag == "FinishLine") //hit finish line. handle completed time
            {
                completedTime = Time.time;
                float totalTime = completedTime - startTime;
                
                gameController.GetComponent<GameControllerScript>().SetBestTimeOnLevel(totalTime);
                float distancePercentage = (distanceTravelled / gameController.GetComponent<GameControllerScript>().levelLength[SceneManager.GetActiveScene().buildIndex]) * 100f;
                gameController.GetComponent<GameControllerScript>().ProcessNewScore(distanceTravelled); //save distance score
                //currentScoreText.GetComponent<TextMeshPro>().text = distancePercentage.ToString("0") + "%"; //update score text
                //currentScoreText.GetComponent<MeshRenderer>().enabled = true; //make text visible
                //newScoreShowing = true;
                //currentScoreText.transform.position = new Vector3(collision.contacts[0].point.x * 0.7f, collision.contacts[0].point.y - 3f, -1f); //move text

                currentTimeText.GetComponent<TextMeshPro>().text = ConvertSecondsToMinutesAndSeconds(totalTime); //update time text
                currentTimeText.GetComponent<MeshRenderer>().enabled = true; //make text visible
                newTimeShowing = true;
                currentTimeText.transform.position = new Vector3(collision.contacts[0].point.x * 0.7f, collision.contacts[0].point.y - 3f, -1f); //move text

                hasControl = false; //remove control ability
                Invoke("ReloadLevel", 1.75f); //begin reloading scene
            }
            else
            {
                
                
                //print("Total time onCollision" + totalTime.ToString());
                float distancePercentage = (distanceTravelled / gameController.GetComponent<GameControllerScript>().levelLength[SceneManager.GetActiveScene().buildIndex]) * 100f;
                gameController.GetComponent<GameControllerScript>().ProcessNewScore(distanceTravelled); //save distance score
                currentScoreText.GetComponent<TextMeshPro>().text = distancePercentage.ToString("0") + "%"; //update score text
                currentScoreText.GetComponent<MeshRenderer>().enabled = true; //make text visible
                newScoreShowing = true;
                currentScoreText.transform.position = new Vector3(collision.contacts[0].point.x * 0.7f, collision.contacts[0].point.y - 3f, -1f); //move text close to position player died
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y * 0.3f, rigidbody.velocity.z); //slow down player a little
                hasControl = false; //remove control ability
                gameController.GetComponent<GameControllerScript>().showHighScore = true;
                //gameController.GetComponent<GameControllerScript>().showBestTime = true;

                Invoke("ReloadLevel", 1.75f); //begin reloading scene
            }
            
        }
        
        
    }

    void ReloadLevel()
    {
        gameController.GetComponent<GameControllerScript>().firstClicked = false;
        gameController.GetComponent<GameControllerScript>().LoadCurrentLevel();
    }

    public void makePlayerActive() //activated by gameManager to make player start falling and become active
    {
        startTime = Time.time;
        //print(startTime);
        playerVisibleAndActive = true;
        GetComponent<MeshRenderer>().enabled = true;
        rigidbody.useGravity = true;
    }

   
    public void SwitchLevel()
    {
        gameController.GetComponent<GameControllerScript>().firstClicked = false;
        gameController.GetComponent<GameControllerScript>().showHighScore = true;
        gameController.GetComponent<GameControllerScript>().showBestTime = true;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(5);

        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(0);
        }
    }


    private string ConvertSecondsToMinutesAndSeconds(float originalSeconds)
    {
        string returnString = "";
        float minutes = originalSeconds / 60f;
        if (minutes < 1f)
        {
            returnString += "00:";
        }
        else if (minutes < 10f)
        {
            returnString += "0" + Mathf.FloorToInt(minutes) + ":";
        }
        else
        {

            returnString += Mathf.FloorToInt(minutes) + ":";
        }

        originalSeconds = originalSeconds - (60f * Mathf.FloorToInt(minutes));

        if (originalSeconds < 1f)
        {
            returnString += "00" + RoundToTwoDecimalPoints(originalSeconds);
        }
        else if (originalSeconds < 10f)
        {
            returnString += "0" + RoundToTwoDecimalPoints(originalSeconds);
        }
        else
        {
            returnString += RoundToTwoDecimalPoints(originalSeconds);
        }


        return returnString;
    }

    private string RoundToTwoDecimalPoints(float toRound)
    {
        string rounded = "";

        rounded = toRound.ToString("0.00");
        return rounded;
    }

}
