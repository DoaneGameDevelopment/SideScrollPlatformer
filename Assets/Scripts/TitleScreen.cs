using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(0); // Main Stage is idx 0

    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}