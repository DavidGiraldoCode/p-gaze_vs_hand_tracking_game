using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTriggers : MonoBehaviour
{
    private float zPos;
    private Camera cam;
    public GameObject player;
    void Start()
    {
        cam = Camera.main;
        zPos = cam.transform.position.z + cam.nearClipPlane;
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x-1, player.transform.position.y+1, zPos);
        }
    }
}
