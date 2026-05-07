using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryBlock : MonoBehaviour
{
    public GameObject victoryUI;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level Complete!");

            // Show victory screen
            if (victoryUI != null)
            {
                victoryUI.SetActive(true);
            }

            SceneManager.LoadScene(3);
            
        }
    }
}