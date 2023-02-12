using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int MAX_HEALTH;
    [SerializeField] private int health;



    void start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        MAX_HEALTH = player.GetComponent<UpgradeMenu>().GetMaxHP();
        if (gameObject.tag == "Player")
        {
            health = MAX_HEALTH;
        }



    }

    public int getHealth()
    {
        if (this.gameObject.tag == "Player")
        {
            return health;
        }
        else
        {
            return health;
        }
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
        if (this.gameObject.tag == "Enemy")
        {
            float Value = this.GetComponent<Enemy>().getValue();
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<UpgradeMenu>().currencyAdder(Value);
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


