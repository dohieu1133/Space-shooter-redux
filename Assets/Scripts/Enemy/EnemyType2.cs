using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : MonoBehaviour
{
    public GameObject bulletPrefabs;
    [SerializeField] Transform weapon;

    [SerializeField] float timeShoot = 2f;
    float countTime = 0;

    private void Awake()
    {
        timeShoot += Random.Range(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= timeShoot)
        {
            countTime = Random.Range(-2f, 2f); ;
            if (bulletPrefabs != null)
            {
                GameObject bullet = Instantiate(bulletPrefabs, weapon.position, weapon.rotation);
            }
        }
    }
}
