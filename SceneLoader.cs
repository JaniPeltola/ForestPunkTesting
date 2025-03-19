using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // Load the next scene when the player collides with the trigger
    {
        if (other.CompareTag("Player")) // Check if the player is colliding with the trigger
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get the index of the current scene

            int nextSceneIndex = currentSceneIndex + 1; // Calculate the index of the next scene

            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Check if the next scene exists
            {
                SceneManager.LoadScene(nextSceneIndex); // Load the next scene
            }
        }
    }
}
