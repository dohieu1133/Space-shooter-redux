using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameLevelText : MonoBehaviour
{
    [SerializeField] float time = 2f;

    // Update is called once per frame
    void Update()
    {
        if (time > 0) {
            time -= Time.deltaTime;
            return;
        }

        Destroy(gameObject);
    }
}
