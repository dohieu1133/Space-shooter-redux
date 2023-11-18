using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Phase : MonoBehaviour
{
    [SerializeField] Transform objectPosition;
    private void Start()
    {
        if (objectPosition != null)
        {
            transform.position = objectPosition.position;
        }

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
                LevelController level = transform.parent.gameObject.GetComponent<LevelController>();
                if (level)
                {
                    level.PhaseClear();
                }
            }
            Destroy(gameObject);
        }
    }
}
