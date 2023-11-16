using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move2point : MonoBehaviour
{
    public Vector2 point;
    public float speed = 2f;

    Vector2 target;
    EnemyType2 enemyType2;

    private void Start()
    {
        target = new Vector2(transform.position.x, point.y);
        enemyType2 = transform.GetComponent<EnemyType2>();
        if (enemyType2)
        {
            enemyType2.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(target, transform.position) < .1f)
        {
            if (Vector2.Distance(point, transform.position) < .1f)
            {
                if (enemyType2)
                {
                    enemyType2.enabled = true;
                }
                Destroy(transform.GetComponent<Move2point>());
                return;
            }

            target = new Vector2(point.x, transform.position.y);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}
