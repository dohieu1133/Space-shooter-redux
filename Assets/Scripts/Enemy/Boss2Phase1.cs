using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Phase1 : MonoBehaviour
{
    Vector2 screenBounds;
    [SerializeField] float horizontalDistance = 1f;
    [SerializeField] float verticalDistance = 1f;
    public LaserController bulletPrefabs;
    [SerializeField] float timeShoot = 3f;

    float countTime = 0;
    int numberHorizontal;
    int numberVertical;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        numberHorizontal = (int) ((screenBounds.x / horizontalDistance) * 2);
        numberVertical = (int) ((screenBounds.y / verticalDistance) * 2);
    }

    private void Update()
    {
        countTime += Time.deltaTime;
        if (countTime >= timeShoot)
        {
            countTime = 0;
            int attackType = Random.Range(1, 4);
            
            // kho qua bo
            // if (attackType == 0)
            // {
            //     AttackUp();
            // }
            
            
            if (attackType == 1)
            {
                AttackDown();
            }
            else if (attackType == 2)
            {
                AttackLeft();
            }
            else if (attackType == 3)
            {
                AttackRight();
            }
        }
    }

    void AttackUp()
    {
        if (bulletPrefabs == null) return;

        int emty = Random.Range(3, numberHorizontal - 2);
        for (int i = 0; i <=  numberHorizontal; i++)
        {
            if (i == emty)
            {
                continue;
            }

            GameObject bullet = Instantiate(bulletPrefabs.gameObject, new Vector3(screenBounds.x - i * horizontalDistance, -screenBounds.y, 0), Quaternion.identity);
        }
    }

    void AttackDown()
    {
        if (bulletPrefabs == null) return;

        int emty = Random.Range(3, numberHorizontal - 2);
        for (int i = 0; i <= numberHorizontal; i++)
        {
            if (i == emty)
            {
                continue;
            }

            GameObject bullet = Instantiate(bulletPrefabs.gameObject, new Vector3(screenBounds.x - i * horizontalDistance, screenBounds.y, 0), Quaternion.identity);
            if (bullet != null)
            {
                bullet.transform.up = Vector3.down;
            }
        }
    }
    void AttackLeft()
    {
        if (bulletPrefabs == null) return;

        int emty = Random.Range(3, numberVertical - 2);
        for (int i = 0; i <= numberVertical; i++)
        {
            if (i == emty)
            {
                continue;
            }

            GameObject bullet = Instantiate(bulletPrefabs.gameObject, new Vector3(screenBounds.x, screenBounds.y - i * verticalDistance, 0), Quaternion.identity);
            if (bullet != null)
            {
                bullet.transform.up = Vector3.left;
            }
        }
    }
    void AttackRight()
    {
        if (bulletPrefabs == null) return;

        int emty = Random.Range(3, numberVertical - 2);
        for (int i = 0; i <= numberVertical; i++)
        {
            if (i == emty)
            {
                continue;
            }

            GameObject bullet = Instantiate(bulletPrefabs.gameObject, new Vector3(-screenBounds.x, screenBounds.y - i * verticalDistance, 0), Quaternion.identity);
            if (bullet != null)
            {
                bullet.transform.up = Vector3.right;
            }
        }
    }
}
