using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject bulletPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
