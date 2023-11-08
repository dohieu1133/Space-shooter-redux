using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float maxRange = 1;
    [SerializeField] int damage = 30;

    float rangeCounter = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(transform.up.x, transform.up.y, 0) * speed * Time.deltaTime;
        rangeCounter += Time.deltaTime;
        if (rangeCounter > maxRange)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        if (enemy != null )
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
