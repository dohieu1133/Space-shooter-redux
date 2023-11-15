using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : MonoBehaviour
{
    [SerializeField] float delateTime = 1f;
    [SerializeField] float seed = 4f;


    float countTime = 0;

    Vector2 target;
    Transform posA;

    private void Awake()
    {
        posA = GameObject.Find("playerShip").transform;
    }

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
        
        transform.position = Vector2.MoveTowards(transform.position, target, seed * Time.deltaTime);
    }
}
