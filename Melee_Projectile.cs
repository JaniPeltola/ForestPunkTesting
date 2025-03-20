using UnityEngine;

public class Melee_Projectile : MonoBehaviour
{
    float speed = 10f;
    float distanceToMove = 2f;
    Vector3 startPosition;

    void Start()
    {
        // Store the initial position as the spawn point
        startPosition = transform.position;
    }

    void Update()
    {
        move();
        rangeCheck();
    }


    void move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void rangeCheck()
    {

        float distanceMoved = Vector3.Distance(startPosition, transform.position);
        if (distanceMoved >= distanceToMove)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

}
