using UnityEngine;

public class Shoot_Script : MonoBehaviour
{
    public GameObject projectile;

    void Update() ///////////////////////////////////////////////////////////////////////
    {
        shoot();
    } ///////////////////////////////////////////////////////////////////////////////////

    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}
