using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MAX_HEALTH;
    [SerializeField] private int health = 100;



    void start()
    {
        MAX_HEALTH = GetComponent<UpgradeMenu>().GetMaxHP();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("no negative damage allowed");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        if (this.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            this.GetComponent<PlayerStats>().DeathTrigger();
        }
        Destroy(gameObject);
    }

    public void HealHealth(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("no negative healing allowed");
        }

        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }



    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }
}


