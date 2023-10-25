using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class laserController : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float maxRange = 1;

    float rangeCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(transform.up.x, transform.up.y, 0) * speed * Time.deltaTime;
        rangeCounter += Time.deltaTime;
        if(rangeCounter > maxRange)
        {
            Destroy(gameObject);
        }
    }
}
