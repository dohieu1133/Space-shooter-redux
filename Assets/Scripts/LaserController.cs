using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 30;
    [SerializeField] string tagEnemy;

    float rangeCounter = 0;

    Vector2 screenBounds;
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(transform.up.x, transform.up.y, 0) * speed * Time.deltaTime;
        rangeCounter += Time.deltaTime;
        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x || transform.position.y > screenBounds.y || transform.position.y < -screenBounds.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagEnemy))
        {
            Health healthEnemy = collision.GetComponent<Health>();
            if (healthEnemy != null) {
                healthEnemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
