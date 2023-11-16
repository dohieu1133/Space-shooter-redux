using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform[] waypoints;
    public bool repeat = true;

    int currentWaypointIndex = 0;

    public float speed = 2f;

    Vector2 screenBounds, target;

    bool random = false;
    private void Start()
    {
        if (waypoints.Length == 0)
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

            random = true;
            target = randomPosition();
        }
        else
        {
            target = waypoints[0].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!repeat && currentWaypointIndex >= waypoints.Length)
        {
            return;
        }

        if (Vector2.Distance(target, transform.position) < .1f)
        {
            if (!random)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    if (!repeat) return;
                    currentWaypointIndex = 0;
                }
                target = waypoints[currentWaypointIndex].transform.position;
            }
            else
            {
                target = randomPosition();
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }

    Vector2 randomPosition()
    {
        return new Vector2(Random.Range(screenBounds.x * -1, screenBounds.x), Random.Range(screenBounds.y * -1, screenBounds.y));
    }
}
