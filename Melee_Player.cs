using UnityEngine;

public class Melee_Player : MonoBehaviour
{
    public GameObject MeleeProjectile;




    void Update() ///////////////////////////////////////////////////////////////
    {
        spawn();

    } //////////////////////////////////////////////////////////////////////////


    void spawn()
    {
        if (Input.GetKeyDown(KeyCode.Fire1))
        {
            Instantiate(MeleeProjectile, transform.position, MeleeProjectile.transform.rotation);
        }
    }


}
