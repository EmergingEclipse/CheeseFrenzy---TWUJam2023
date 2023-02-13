using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musk : MonoBehaviour
{
    GameObject[] enemies;
    private UpgradeMenu playerstats;
    public int Damage;
    float distance;

    void Start()
    {
        playerstats = GetComponentInParent<UpgradeMenu>();
    }
    void FixedUpdate()
    {
        float scale = playerstats.GetMuskRange() / 2;
        GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
        StartCoroutine(muskDMG());
    }
    public IEnumerator muskDMG()
    {
        yield return new WaitForSeconds(.5f);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform playerTransform = GetComponentInParent<Transform>();
        float TempDamage = playerstats.GetMuskDamage();
        Damage = (int)(TempDamage / 2);
        foreach (GameObject enemy in enemies)
        {
            distance = Vector3.Distance(enemy.transform.position, playerTransform.position);
            if (distance < (playerstats.GetMuskRange() + .5f))
            {
                Health health = enemy.GetComponent<Health>();
                health.Damage(Damage);

            }
        }
    }
}
