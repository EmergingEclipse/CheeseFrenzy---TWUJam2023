using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchArea : MonoBehaviour
{
    private int punchDamage = 10;
    void Start()
    {
        UpgradeMenu UpgradeMenu1 = GetComponentInParent<UpgradeMenu>();
        punchDamage = UpgradeMenu1.GetPunch();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            Health health = collision.GetComponent<Health>();
            health.Damage(punchDamage);
            Debug.Log(punchDamage);
        }
        Debug.Log("miss");
    }




}
