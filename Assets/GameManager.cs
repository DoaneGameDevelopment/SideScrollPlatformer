using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public Text timeTakenText;
    float timeTaken = 0f;

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

        
        // TODO : Uncomment and make UI
        //timeTakenText.text = "Time: \n" + timeTaken.ToString();
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


        // render and display UI elements


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

        // TODO : Uncomment and make UI
        // timeTakenText.text = string.Format("Time: \n{0:00}:{1:00}", mins, secs); // commented out due to errors (UI hasn't been made yet)
    }

    public bool Game_Paused = false;
    
    public void PauseGame()
    {
        Time.timeScale = 0;
        Game_Paused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Game_Paused = false;
    }
}
