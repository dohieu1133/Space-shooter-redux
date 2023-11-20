using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public LevelBullet[] bulletPrefabs;

    public int type = 0;
    public int power = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (type < bulletPrefabs.Length && bulletPrefabs[type] != null)
            {
                if (bulletPrefabs[type].GetBulletsLevel(power) != null)
                {
                    GameObject bullet = Instantiate(bulletPrefabs[type].GetBulletsLevel(power), transform.position, transform.rotation);
                }
            }
        }
    }

    public void Upgrade(int typeUpgrade)
    {
        if (typeUpgrade < bulletPrefabs.Length && bulletPrefabs[typeUpgrade] != null)
        {
            if (typeUpgrade == type)
            {
                power = Mathf.Min(bulletPrefabs[typeUpgrade].MaxLevel() - 1, power + 1);
            }
            else
            {
                type = typeUpgrade;
            }
        }
    }

    public void Damage()
    {
        power = Mathf.Max(power - 1, 0);
    }
}
