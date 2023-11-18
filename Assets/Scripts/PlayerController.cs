using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Moving system")]
    [SerializeField] float speed = 4;
    [SerializeField] WeaponController weapon;
    [SerializeField] GameObject[] damages;

    int health = 5;

    Vector2 move = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if (move != Vector2.zero)
        {
            move = move.normalized * speed;

            //transform.up = move; // xoay tàu
            transform.position += new Vector3(move.x, move.y, 0) * Time.deltaTime;
        }
    }

    public void Upgrade(int type)
    {
        if (weapon != null)
        {
            weapon.Upgrade(type);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Enemy bullet")
        {
            Health enemyHealth = collision.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(health);
            }
            Damage();
        }
    }
    void Damage()
    {
        weapon.Damage();
        health--;
        
        for (int i = 0; i < damages.Length; i++)
        {
            if (i + health > damages.Length)
            {
                break;
            }
            if (damages[i] != null)
            {
                damages[i].SetActive(true);
            }
        }
    }
}
