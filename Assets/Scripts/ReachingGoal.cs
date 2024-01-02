using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachingGoal : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject player;
    public Logic logic;
    //public bool goalIsReach = false;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //player.transform.position = startPoint.transform.position;
            logic.successUI();
            //goalIsReach = true;
        }
    }
}
