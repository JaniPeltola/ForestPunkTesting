using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private float speed = 20f;

    void Update() //////////////////////////////////////////////////////////
    {
        move();
    } ////////////////////////////////////////////////////////////////////
    void move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit!");
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
