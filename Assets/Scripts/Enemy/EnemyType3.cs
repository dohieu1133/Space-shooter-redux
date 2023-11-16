using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType3 : MonoBehaviour
{
    [SerializeField] float delateTime = 1f;
    [SerializeField] float seed = 6f;


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
        countTime = Random.Range(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime >= delateTime)
        {
            countTime = Random.Range(-2f, 2f);
            target = posA.position;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, target, seed * Time.deltaTime);
    }
}
