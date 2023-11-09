using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : MonoBehaviour
{
    [SerializeField] float delateTime;
    [SerializeField] Transform posA;
    [SerializeField] int Speed;

    float countTime = 0;

    Vector2 target;

    private void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime >= delateTime)
        {
            countTime = 0;
            target = posA.position;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
