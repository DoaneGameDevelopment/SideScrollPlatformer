using UnityEngine;

public class CollectableCoins : MonoBehaviour
{
    public int points = 2; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
    
        
     {
    GameManager.instance.AddPoints(points);
    Destroy(gameObject);
     }
    }
 }
