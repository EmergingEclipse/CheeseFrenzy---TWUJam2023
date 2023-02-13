using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int damage;
    private float speed;
    private float value;
    private Animator anim;

    [SerializeField] private EnemyData data;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        SetEnemyValues();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            follow();
        }
        catch
        {
        }
    }

    private void follow()
    {
        Vector3 pp = player.transform.position;
        Vector3 ep = transform.position;
        if (GetDominantDist(pp, ep) == 0)
        {
            if (pp.x - ep.x > 0) { anim.SetFloat("moveX", 1.0f); }
            else { anim.SetFloat("moveY", -1.0f); }
        }
        else if (GetDominantDist(pp, ep) == 1)
        {
            if (pp.y - ep.y > 0) { anim.SetFloat("moveY", 1.0f); }
            else { anim.SetFloat("moveY", -1.0f); }
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<PlayerStats>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                GetComponent<Health>().Damage(10000);

            }
        }
    }
    public float getValue()
    {
        return value;
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
        value = data.value;
    }

    private int GetDominantDist(Vector3 a, Vector3 b)
    {
        float diffX = Mathf.Abs(Mathf.Abs(a.x) - Mathf.Abs(b.x));
        float diffY = Mathf.Abs(Mathf.Abs(a.y) - Mathf.Abs(b.y));
        if (diffX >= diffY) { return 0; }
        else { return 1; }
    }
}
