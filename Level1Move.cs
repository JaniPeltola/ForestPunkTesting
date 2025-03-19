using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Move : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered trigger");

        if (other.CompareTag("Player"))
        {
            // Move the player to the next level
            SceneManager.LoadScene(1);
            Debug.Log("Player moved to next level");
        }
    }
}
