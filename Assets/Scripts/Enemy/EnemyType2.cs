using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : MonoBehaviour
{
    public GameObject bulletPrefabs;
    [SerializeField] Transform weapon;

    [SerializeField] float timeShoot = 1;
    float countTime = 0;

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= timeShoot)
        {
            countTime = 0;
            if (bulletPrefabs != null)
            {
                GameObject bullet = Instantiate(bulletPrefabs, weapon.position, weapon.rotation);
            }
        }
    }
}
