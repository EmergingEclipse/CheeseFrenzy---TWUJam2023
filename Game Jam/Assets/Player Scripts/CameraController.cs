using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        try
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 10);
        }
        catch
        {

        }
    }
}
