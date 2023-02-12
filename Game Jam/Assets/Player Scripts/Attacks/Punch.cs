using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Punch : MonoBehaviour
{
    GameObject[] enemies;
    public int Damage;
    float speed = 45f;
    public float knockback;
    private float delay = 0.15f;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {


        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        UpgradeMenu playerstat = player.GetComponent<UpgradeMenu>();
        knockback = playerstat.GetKnockBackBuff();
        Damage = playerstat.GetPunch();
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit!");
        if (collision.GetComponent<Health>() != null && collision.tag == "Enemy")
        {

            rb = collision.GetComponentInParent<Rigidbody2D>();
            Health health = collision.GetComponent<Health>();
            health.Damage(Damage);
            GameObject enemy = collision.gameObject;
            Debug.Log(Damage);

        }

    }

    private IEnumerator SelfDestruct()
    {

        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
