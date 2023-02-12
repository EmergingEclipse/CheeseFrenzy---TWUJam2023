using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public GameObject deathPanel;
    public static bool game_paused = false;
    Rigidbody2D m_Rigidbody;
    public float m_Speed = 5f;


    private Animator anim;

    void Start()
    {
        RunTimeData();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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



    }

    private void PlayerMovement()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
        if (m_Input.x != 0 || m_Input.y != 0)
        {
            anim.SetFloat("moveX", m_Input.x);
            anim.SetFloat("moveY", m_Input.y);
            anim.Play("m_Move");
        }
        else
        {
            anim.Play("m_Idle");
        }
    }

    public void activate_pausemenu()
    {
        game_paused = true;
        Time.timeScale = 0;
    }
    public void Deactivate_PauseMenu()
    {
        game_paused = false;
        Time.timeScale = 1;
    }

    public void DeathTrigger()
    {
        activate_pausemenu();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);


        deathPanel.SetActive(true);
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        GameObject.Destroy(spawner);

    }



    //creates all of the base upgrades on initial runtime so upgrades will work
    public void RunTimeData()
    {
        m_Speed = GetComponent<UpgradeMenu>().GetSpeed();


    }



}
