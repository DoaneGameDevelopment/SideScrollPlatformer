using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Main Stage is idx 1

    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0); // Title Screen is idx 0
    }
}