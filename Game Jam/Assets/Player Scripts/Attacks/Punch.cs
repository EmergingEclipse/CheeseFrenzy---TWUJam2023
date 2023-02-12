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

    public UnityEvent OnBegin, OnDone;

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
        if (collision.GetComponent<Health>() != null && collision.tag == "Enemy")
        {

            rb = collision.GetComponentInParent<Rigidbody2D>();
            Health health = collision.GetComponent<Health>();
            health.Damage(Damage);
            GameObject enemy = collision.gameObject;
            PlayFeedback(enemy);
            Debug.Log(Damage);

        }

    }
    public void PlayFeedback(GameObject sender)
    {
        StopCoroutine(Reset());
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        try
        {
            rb.AddForce(direction * knockback, ForceMode2D.Impulse);
        }
        catch
        {

        }
        StartCoroutine(Reset());

    }
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        try
        {
            rb.velocity = Vector3.zero;
        }
        catch
        {

        }
        OnDone?.Invoke();

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
