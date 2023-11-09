using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Phase : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (transform.childCount == 0)
        {
            if (transform.parent)
            {
                EnemySpawner enemySpawner = transform.parent.gameObject.GetComponent<EnemySpawner>();
                if (enemySpawner)
                {
                    Destroy(gameObject);
                    enemySpawner.PhaseClear();
                }
            }
        }
    }
}
