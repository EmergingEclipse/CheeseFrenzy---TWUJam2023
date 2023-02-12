using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private GameObject attackarea;

    private bool attacking = false;
    private float timeToAttack = .25f;
    private float timer = 0f;



    void Start()
    {

        attackarea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackarea.SetActive(attacking);

            }
        }
    }
    private void Attack()
    {
        attacking = true;
        attackarea.SetActive(attacking);
    }

}
