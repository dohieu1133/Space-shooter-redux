using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyType1 : MonoBehaviour
{
    [SerializeField] Transform posA;
    [SerializeField] float speed = 5f;

    Vector2 target;

    private void Awake()
    {
        speed += Random.Range(-2f, 2f);
        target = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target) < .1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, posA.position);
    }
}
