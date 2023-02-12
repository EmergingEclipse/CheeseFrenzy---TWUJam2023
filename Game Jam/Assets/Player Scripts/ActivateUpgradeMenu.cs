using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ActivateUpgradeMenu : MonoBehaviour
{

    public GameObject UpgradeUI;
    public GameObject player;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.GetComponent<Transform>().position, transform.position);
        WindowOpen();
    }

    public void WindowOpen()
    {
        if ((distance < 2) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("this is true");
            UpgradeUI.SetActive(true);
            //Time.timeScale = 0;
        }
    }
    public void windowClosed()
    {
        UpgradeUI.SetActive(false);

        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
}
