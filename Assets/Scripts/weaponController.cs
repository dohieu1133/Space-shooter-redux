using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefabs;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (bulletPrefabs != null)
            {
                GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
            }
        }
    }
}
