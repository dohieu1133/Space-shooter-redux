using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        while (transform.childCount > 0)
        {
            transform.GetChild(0).transform.parent = transform.parent;
        }
        Destroy(gameObject);
    }
}
