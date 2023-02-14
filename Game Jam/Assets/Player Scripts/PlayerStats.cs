using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject UpgradePanel;
    public GameObject DeathPanel;

    public GameObject UI;
    public static bool gamePaused = false;
    public Rigidbody2D mRigidbody;
    public float mSpeed = 5f;

    public AudioSource musicPlayer;
    public AudioClip death;

    private Animator anim;
    [SerializeField] private RuntimeAnimatorController newController;
    private SpriteRenderer spRend;
    [SerializeField] private Sprite newSprite;

    void Start()
    {



        mRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRend = GetComponent<SpriteRenderer>();
        runTimeData();
        if (PlayerPrefs.GetInt("Mouse") == 1)
        {
            turnIntoMouse();
        }
    }
    void FixedUpdate()
    {
        if (gamePaused)
        {
            activatePausemenu();
        }
        if (!gamePaused)
        {
            playerMovement();
        }



    }

    private void playerMovement()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        mRigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * mSpeed);
        Debug.Log(transform.position + m_Input * Time.deltaTime * mSpeed);
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

    public void activatePausemenu()
    {
        gamePaused = true;
        Time.timeScale = 0;
    }
    public void Deactivate_PauseMenu()
    {
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void DeathTrigger()
    {
        activatePausemenu();
        musicChanger();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);


        DeathPanel.SetActive(true);
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        GameObject.Destroy(spawner);
        UI.SetActive(false);

    }

    public void musicChanger()
    {
        musicPlayer.clip = death;
        musicPlayer.Play();
        musicPlayer.loop = false;
    }

    public void turnIntoMouse()
    {
        anim.runtimeAnimatorController = newController;
        spRend.sprite = newSprite;
    }



    //creates all of the base upgrades on initial runtime so upgrades will work
    public void runTimeData()
    {

        mSpeed = GetComponentInParent<UpgradeMenu>().GetSpeed() + 1;
    }



}
