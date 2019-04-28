using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenuControllerScript : MonoBehaviour
{
    GameObject gameController;


    float[] bestLevelTimes = new float[7];

    int[] levelsFinished = new int[7];

    //GameObject[] bestTimes = new GameObject[6];
    GameObject button1;
    GameObject button2;
    GameObject button3;
    GameObject button4;
    GameObject button5;
    GameObject button6;

    public Image tick1;
    public Image tick2;
    public Image tick3;
    public Image tick4;
    public Image tick5;
    public Image tick6;

    public GameObject percent1;
    public GameObject percent2;
    public GameObject percent3;
    public GameObject percent4;
    public GameObject percent5;
    public GameObject percent6;

    float level1Percent;
    float level2Percent;
    float level3Percent;
    float level4Percent;
    float level5Percent;
    float level6Percent;

    public float[] levelLength;

    float[] highScore = new float[7];

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        levelLength = new float[7];
        levelLength[1] = 341f;
        levelLength[2] = 820.75f;
        levelLength[3] = 434f;
        levelLength[4] = 391f;
        levelLength[5] = 240f;
        levelLength[6] = 434f;

        highScore[1] = PlayerPrefs.GetFloat("highScore1", 0f);
        highScore[2] = PlayerPrefs.GetFloat("highScore2", 0f);
        highScore[3] = PlayerPrefs.GetFloat("highScore3", 0f);
        highScore[4] = PlayerPrefs.GetFloat("highScore4", 0f);
        highScore[5] = PlayerPrefs.GetFloat("highScore5", 0f);
        highScore[6] = PlayerPrefs.GetFloat("highScore6", 0f);

        if(highScore[1] > 0.01f)
        {
            level1Percent = (highScore[1] / levelLength[1]) * 100f;
        }

        if (highScore[2] > 0.01f)
        {
            level2Percent = (highScore[2] / levelLength[2]) * 100f;
        }

        if (highScore[3] > 0.01f)
        {
            level3Percent = (highScore[3] / levelLength[3]) * 100f;
        }

        if (highScore[4] > 0.01f)
        {
            level4Percent = (highScore[4] / levelLength[4]) * 100f;
        }

        if (highScore[5] > 0.01f)
        {
            level5Percent = (highScore[5] / levelLength[5]) * 100f;
        }

        if (highScore[6] > 0.01f)
        {
            level6Percent = (highScore[6] / levelLength[6]) * 100f;
        }
        levelsFinished[1] = PlayerPrefs.GetInt("level1FinishedPref", 0);
        bestLevelTimes[1] = PlayerPrefs.GetFloat("level1BestTime", 10000f);


        levelsFinished[2] = PlayerPrefs.GetInt("level2FinishedPref", 0);
        bestLevelTimes[2] = PlayerPrefs.GetFloat("level2BestTime", 10000f);


        levelsFinished[3] = PlayerPrefs.GetInt("level3FinishedPref", 0);
        bestLevelTimes[3] = PlayerPrefs.GetFloat("level3BestTime", 10000f);

        levelsFinished[4] = PlayerPrefs.GetInt("level4FinishedPref", 0);
        bestLevelTimes[4] = PlayerPrefs.GetFloat("level4BestTime", 10000f);

        levelsFinished[5] = PlayerPrefs.GetInt("level5FinishedPref", 0);
        bestLevelTimes[5] = PlayerPrefs.GetFloat("level5BestTime", 10000f);

        levelsFinished[6] = PlayerPrefs.GetInt("level6FinishedPref", 0);
        bestLevelTimes[6] = PlayerPrefs.GetFloat("level6BestTime", 10000f);

        tick1.enabled = false;
        tick2.enabled = false;
        tick3.enabled = false;
        tick4.enabled = false;
        tick5.enabled = false;
        tick6.enabled = false;

        gameController = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(button1 == null)
        {
            button1 = GameObject.Find("BestTime1");

            if (button1 != null)
            {
                if (levelsFinished[1] == 1)
                {
                    tick1.enabled = true;
                    button1.GetComponent<TextMeshProUGUI>().text = ConvertSecondsToMinutesAndSeconds(bestLevelTimes[1]);
                    
                }
                else
                {
                    button1.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }

        if (button2 == null)
        {
            button2 = GameObject.Find("BestTime2");

            if (button2 != null)
            {
                if (levelsFinished[2] == 1)
                {
                    tick2.enabled = true;
                    button2.GetComponent<TextMeshProUGUI>().text = ConvertSecondsToMinutesAndSeconds(bestLevelTimes[2]);
                }
                else
                {
                    button2.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }

        if (button3 == null)
        {
            button3 = GameObject.Find("BestTime3");

            if (button3 != null)
            {
                if (levelsFinished[3] == 1)
                {
                    tick3.enabled = true;
                    button3.GetComponent<TextMeshProUGUI>().text = ConvertSecondsToMinutesAndSeconds(bestLevelTimes[3]);
                }
                else
                {
                    button3.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }

        if (button4 == null)
        {
            button4 = GameObject.Find("BestTime4");

            if (button4 != null)
            {
                if (levelsFinished[4] == 1)
                {
                    tick4.enabled = true;
                    button4.GetComponent<TextMeshProUGUI>().text = ConvertSecondsToMinutesAndSeconds(bestLevelTimes[4]);
                }
                else
                {
                    button4.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }

        if (button5 == null)
        {
            button5 = GameObject.Find("BestTime5");

            if (button5 != null)
            {
                if (levelsFinished[5] == 1)
                {
                    tick5.enabled = true;
                    button5.GetComponent<TextMeshProUGUI>().text = ConvertSecondsToMinutesAndSeconds(bestLevelTimes[5]);
                }
                else
                {
                    button5.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }

        if (button6 == null)
        {
            button6 = GameObject.Find("BestTime6");

            if (button6 != null)
            {
                if (levelsFinished[6] == 1)
                {
                    tick6.enabled = true;
                    button6.GetComponent<TextMeshProUGUI>().text = ConvertSecondsToMinutesAndSeconds(bestLevelTimes[6]);
                }
                else
                {
                    button6.GetComponent<TextMeshProUGUI>().enabled = false;
                }
            }
        }


        if (percent1 == null)
        {
            percent1 = GameObject.Find("Percent1Text");

            if(percent1 != null)
            {
                if(levelsFinished[1] == 1)
                {
                    percent1.SetActive(false);
                }
                else
                {
                    if (level1Percent > 0.01f)
                    {
                        percent1.GetComponent<TextMeshProUGUI>().text = level1Percent.ToString("0") + "%";
                    }                    
                }
            }
        }

        if (percent2 == null)
        {
            percent2 = GameObject.Find("Percent2Text");

            if (percent2 != null)
            {
                if (levelsFinished[2] == 1)
                {
                    percent2.SetActive(false);
                }
                else
                {
                    if (level2Percent > 0.01f)
                    {
                        percent2.GetComponent<TextMeshProUGUI>().text = level2Percent.ToString("0") + "%";
                    }

                }
            }
        }

        if (percent3 == null)
        {
            percent3 = GameObject.Find("Percent3Text");

            if (percent3 != null)
            {
                if (levelsFinished[3] == 1)
                {
                    percent3.SetActive(false);
                }
                else
                {
                    if (level3Percent > 0.01f)
                    {
                        percent3.GetComponent<TextMeshProUGUI>().text = level3Percent.ToString("0") + "%";
                    }

                }
            }
        }

        if (percent4 == null)
        {
            percent4 = GameObject.Find("Percent4Text");

            if (percent4 != null)
            {
                if (levelsFinished[4] == 1)
                {
                    percent4.SetActive(false);
                }
                else
                {
                    if (level4Percent > 0.01f)
                    {
                        percent4.GetComponent<TextMeshProUGUI>().text = level4Percent.ToString("0") + "%";
                    }

                }
            }
        }

        if (percent5 == null)
        {
            percent5 = GameObject.Find("Percent5Text");

            if (percent5 != null)
            {
                if (levelsFinished[5] == 1)
                {
                    percent5.SetActive(false);
                }
                else
                {
                    if (level5Percent > 0.01f)
                    {
                        percent5.GetComponent<TextMeshProUGUI>().text = level5Percent.ToString("0") + "%";
                    }

                }
            }
        }

        if (percent6 == null)
        {
            percent6 = GameObject.Find("Percent6Text");

            if (percent6 != null)
            {
                if (levelsFinished[6] == 1)
                {
                    percent6.SetActive(false);
                }
                else
                {
                    if (level6Percent > 0.01f)
                    {
                        percent6.GetComponent<TextMeshProUGUI>().text = level6Percent.ToString("0") + "%";
                    }

                }
            }
        }

        if (gameController != null)
        {
            Destroy(gameController);
        }


    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(6);
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
