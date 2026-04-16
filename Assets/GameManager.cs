using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeDisplay;
    float timeTaken = 0f;
    public float timer = 300f;

    public static GameManager instance; // what this do
    void Awake() // what this do, is this the same thing as Start and OnEnable?
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeTaken = 0f;
        PlayerPrefs.SetFloat("timeTaken", 0f); // reset time wasted
        Game_Paused = false;
        Pause_Menu.SetActive(false);
    }
    

    void OnDisable() // save file
    {
        PlayerPrefs.SetFloat("timeTaken", timeTaken);
    }

    void OnEnable() // load file
    {
        timeTaken = PlayerPrefs.GetFloat("timeTaken");

    }
    void Update()
    {
        // calculating what to display on the timer
        timeTaken += Time.deltaTime;
        int mins = Mathf.FloorToInt(timeTaken / 60);
        int secs = Mathf.FloorToInt(timeTaken % 60);
        timer -= Time.deltaTime;

        if (timer <= 15f)
        {
            timeDisplay.color = Color.red;
        }
        else if (timer <= 20f)
        {
            timeDisplay.color = Color.orange;
        }
        else if (timer <= 30f)
        {
            timeDisplay.color = Color.yellow;
        }
        else if (timer <= 35f)
        {
            timeDisplay.color = Color.chartreuse;
        }

        timeDisplay.text = string.Format("{0:00}", timer);


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Game_Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public bool Game_Paused = false;
    public GameObject Pause_Menu;
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        Game_Paused = true;
        Pause_Menu.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Game_Paused = false;
        Pause_Menu.SetActive(false);
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1;
        Game_Paused = false;
        Pause_Menu.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void Options()
    {
        Time.timeScale = 1;
        Game_Paused = false;
        Pause_Menu.SetActive(false);
        SceneManager.LoadScene(2);
    }
}

