using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 3;
    
    [SerializeField] GameObject[] items;
    [SerializeField] float[] changes;

    public void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        randomItem();
        Destroy(gameObject);
    }

    void randomItem()
    {
        float change = UnityEngine.Random.Range(0, 100);

        for (int i = 0; i < items.Length; i++)
        {
            if (i < changes.Length)
            {
                change -= changes[i];

                if (change <= 0)
                {
                    if (items[i] != null)
                        Instantiate(items[i], transform.position, new Quaternion());
                    return;
                }
            }
        }
    }
}
