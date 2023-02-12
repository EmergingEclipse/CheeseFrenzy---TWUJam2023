using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseWheelFollow : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 18;
    public GameObject[] enemies;
    public float distance;
    public int bounces;
    int enemyNum = 0;
    public int damage = 10;

    public int BounceMax = 3;
    public int total;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        total = enemies.Length;
        Debug.Log(total);
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        UpgradeMenu playerstat = player.GetComponent<UpgradeMenu>();

        BounceMax = playerstat.GetCheeseBounceCount();
        damage = playerstat.GetCheeseDamage();
        bounces = 0;
        enemyNum = 0;
    }


    void Update()
    {
        follow();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null && collision.tag == "Enemy")
        {
            Health health = collision.GetComponent<Health>();
            health.Damage(damage);
            Debug.Log(damage);
        }
        Debug.Log("miss");
    }

    private void follow()
    {

        if (BounceMax >= enemyNum && bounces < total)
        {

            if (enemyNum == 0)
            {
                try
                {
                    transform.position = Vector2.MoveTowards(transform.position, enemies[0].transform.position, speed * Time.deltaTime);
                    float distance = Vector3.Distance(enemies[0].GetComponent<Transform>().position, transform.position);
                    if (distance < .25)
                    {
                        enemyNum = 1;
                        bounces = bounces + 1;
                    }
                }
                catch
                {
                    enemyNum = 1;
                    bounces = bounces + 1;
                }
            }
            else if (enemyNum == 1)
            {
                try
                {
                    transform.position = Vector2.MoveTowards(transform.position, enemies[1].transform.position, speed * Time.deltaTime);
                    float distance = Vector3.Distance(enemies[1].GetComponent<Transform>().position, transform.position);
                    if (distance < .1)
                    {
                        enemyNum = 2;
                        bounces = bounces + 1;
                    }
                }
                catch
                {
                    enemyNum = 2;
                    bounces = bounces + 1;
                }
            }
            else if (enemyNum == 2)
            {
                try
                {
                    transform.position = Vector2.MoveTowards(transform.position, enemies[2].transform.position, speed * Time.deltaTime);
                    float distnace = Vector3.Distance(enemies[2].GetComponent<Transform>().position, transform.position);
                    if (distance < .1)
                    {
                        enemyNum = 3;
                        bounces = bounces + 1;
                    }
                }
                catch
                {
                    enemyNum = 3;
                    bounces = bounces + 1;
                }

            }
            else if (enemyNum == 3)
            {
                try
                {
                    transform.position = Vector2.MoveTowards(transform.position, enemies[3].transform.position, speed * Time.deltaTime);
                    float distance = Vector3.Distance(enemies[3].GetComponent<Transform>().position, transform.position);
                    if (distance < .1)
                    {
                        enemyNum = 4;
                        bounces = bounces + 1;
                    }
                }
                catch
                {
                    enemyNum = 4;
                    bounces = bounces + 1;
                }
            }
            else if (enemyNum == 4)
            {
                try
                {
                    transform.position = Vector2.MoveTowards(transform.position, enemies[4].transform.position, speed * Time.deltaTime);
                    float distance = Vector3.Distance(enemies[4].GetComponent<Transform>().position, transform.position);
                    if (distance < .1)
                    {
                        enemyNum = 5;
                        bounces = bounces + 1;
                    }
                }
                catch
                {
                    enemyNum = 5;
                    bounces = bounces + 1;
                }
            }
            else if (enemyNum == 5)
            {
                try
                {
                    transform.position = Vector2.MoveTowards(transform.position, enemies[5].transform.position, speed * Time.deltaTime);
                    float distance = Vector3.Distance(enemies[5].GetComponent<Transform>().position, transform.position);
                    if (distance < .1)
                    {
                        enemyNum = 6;
                        bounces = bounces + 1;
                    }
                }
                catch
                {
                    enemyNum = 5;
                    bounces = bounces + 1;
                }
            }
            else if (enemyNum == 6)
            {
                try
                {
                    transform.position = Vector2.MoveTowards(transform.position, enemies[6].transform.position, speed * Time.deltaTime);
                    float distance = Vector3.Distance(enemies[6].GetComponent<Transform>().position, transform.position);
                    if (distance < .25)
                    {
                        Destroy(this.gameObject);
                    }
                }
                catch
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
