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
        timeTakenText.text = "Time: \n" + timeTaken.ToString();
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
        timeTakenText.text = string.Format("Time: \n{0:00}:{1:00}", mins, secs);
    }
}