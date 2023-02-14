using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int MAX_HEALTH = 100;
    private int health = 100;




    void start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(MAX_HEALTH + "this");
        PlayerHealthSetter();




    }
    public void PlayerHealthSetter()
    {

        MAX_HEALTH = GetComponent<UpgradeMenu>().GetMaxHP();

        health = MAX_HEALTH;

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
        StartCoroutine(Flash(this.GetComponent<SpriteRenderer>()));

        if (health <= 0)
        {
            Die();
        }

    }

    public IEnumerator Flash(SpriteRenderer sprite)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(.2f);
        sprite.color = Color.white;
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


