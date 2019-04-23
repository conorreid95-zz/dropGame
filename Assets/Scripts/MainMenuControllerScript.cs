using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour
{
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameManager");
        //Destroy(gameController);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(3);
    }
}
