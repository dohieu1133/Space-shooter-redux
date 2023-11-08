using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Moving system")]
    [SerializeField] float speed = 4;

    Vector2 move = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
