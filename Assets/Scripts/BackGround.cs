using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    float backGroundHeight;
    public float speed = 2f;

    private void Awake()
    {
        backGroundHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.position.y < -backGroundHeight + 1f)
        {
            transform.position = new Vector2(transform.position.x, backGroundHeight);
        }
    }
}
