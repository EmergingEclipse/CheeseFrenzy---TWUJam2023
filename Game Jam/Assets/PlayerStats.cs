using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int hpUpgrade;
    public int damageUpgrade;
    public int mouseUpgrade;


    public GameObject deathPanel;
    public float playerHP = 100;
    public static bool game_paused = false;
    Rigidbody2D m_Rigidbody;
    public float m_Speed = 5f;
    [SerializeField] private float PlayerDamage = 15;
    // Start is called before the first frame update

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (game_paused)
        {
            activate_pausemenu();
        }
        if (!game_paused)
        {
            PlayerMovement();
        }

        if (playerHP <= 0.00)
        {
            DeathTrigger();
        }

    }

    private void PlayerMovement()
    {

        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }


    public void TakeDamage(float damage)
    {
        playerHP = playerHP - damage;
    }

    public void DealDamage(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject collided = collision.gameObject;
            //collided.GetComponent<HPScript>.TakeDamage(playerDamage);

        }


    }

    public void activate_pausemenu()
    {
        game_paused = true;
    }

    public void DeathTrigger()
    {
        activate_pausemenu();
        //saving the permanent upgrades after death
        PlayerPrefs.SetInt("hpUpgrade", hpUpgrade);
        PlayerPrefs.SetInt("damageUpgrade", hpUpgrade);
        deathPanel.SetActive(true);
    }

    public void Upgrades()
    {
        //Temporary Upgrades
        int moveSpeedUpgrade = 0;

        //actually upgradeing player stats
        playerHP *= hpUpgrade;
        PlayerDamage *= damageUpgrade;
        m_Speed = m_Speed + moveSpeedUpgrade;
    }

    //creates all of the base upgrades on initial runtime so upgrades will work
    public void RunTimeData()
    {
        if (PlayerPrefs.GetInt("firstTime") == null)
        {
            PlayerPrefs.SetInt("firstTime", 0);
            PlayerPrefs.SetInt("hpUpgrade", 1);
            PlayerPrefs.SetInt("damageUpgrade", 1);
            PlayerPrefs.SetInt("mouseUpgrade", 0);
        }

        hpUpgrade = PlayerPrefs.GetInt("hpUpgrade");
        damageUpgrade = PlayerPrefs.GetInt("damageUpgrade");
        mouseUpgrade = PlayerPrefs.GetInt("mouseUpgrade");


    }



}
