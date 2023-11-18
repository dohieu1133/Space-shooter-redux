using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBullet : MonoBehaviour
{
    public GameObject[] bullets;

    public GameObject GetBulletsLevel(int level)
    {
        if (level >= bullets.Length)
        {
            level = bullets.Length - 1;
        }

        if (0 <= level)
            return bullets[level];

        return bullets[0];
    }

    public int MaxLevel()
    {
        return bullets.Length;
    }
}
