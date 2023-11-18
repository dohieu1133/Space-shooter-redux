using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabs;
    [SerializeField] Transform endPos;
    [SerializeField] int nbEnemy = 1;

    Vector2 target;
    float distance;

    [SerializeField] float timeDelay = 0.5f;
    [SerializeField] float speedMove = 8f;
    float time;
    private void Awake()
    {
        target = new Vector2(transform.position.x, endPos.position.y);
        if (nbEnemy > 1)
            distance = (transform.position.x - endPos.position.x) / (nbEnemy - 1);

        time = timeDelay;
    }
    // Start is called before the first frame update
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            return;
        }
        time = timeDelay;
        GameObject enemy = Instantiate(enemyPrefabs, transform.position, transform.rotation);
        enemy.transform.SetParent(transform.transform.parent);

        enemy.AddComponent(typeof(Move2point));
        enemy.GetComponent<Move2point>().speed = speedMove;
        enemy.GetComponent<Move2point>().point = target;
        
        target.x -= distance;
        nbEnemy--;
        if (nbEnemy == 0)
        {
            Destroy(gameObject);
        }
    }
}
