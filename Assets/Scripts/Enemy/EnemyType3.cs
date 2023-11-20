using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : MonoBehaviour
{
    [SerializeField] float speedRotation = 10f;
    public GameObject bulletPrefabs;
    [SerializeField] Transform weapon;

    [SerializeField] float timeShoot = 3f;

    float countTime = 0;

    Transform target;

    private void Awake()
    {
        target = GameObject.Find("playerShip").transform;
    }

    private void Start()
    {
        countTime = Random.Range(-2f, 2f);
    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = transform;
        }
        if (weapon == null)
        {
            weapon = transform;
        }

        Rotation();
        Shoot();
    }

    Vector3 vectorToTarget;
    void Rotation()
    {
        vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.x, -vectorToTarget.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * speedRotation);
    }
    void Shoot()
    {
        countTime += Time.deltaTime;
        if (countTime >= timeShoot)
        {
            countTime = Random.Range(-2f, 2f);
            if (bulletPrefabs != null)
            {
                GameObject bullet = Instantiate(bulletPrefabs, weapon.position, weapon.rotation);
            }
        }
    }
}
