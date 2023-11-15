using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController: MonoBehaviour
{
    private void Awake()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

    }
    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void PhaseClear ()
    {
        if (transform.childCount <= 1)
        {
            if (transform.parent)
            {
                LevelController level = transform.parent.gameObject.GetComponent<LevelController>();
                if (level)
                {
                    Destroy(gameObject);
                    level.PhaseClear();
                    return;
                }
            }

            Destroy(gameObject);
            return;
        }
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
