using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachingLava : MonoBehaviour
{
    public GameObject player;
    public GameObject startPoint;
    public Logic logic;
    // public Transform startPoint; 
    //public Vector3 startPoint = new Vector3(-18.5f, 3.5f, -1.0f);
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PointsController pointsController = other.gameObject.GetComponent<PointsController>();
            if (pointsController != null)
            {
                other.transform.position = startPoint.transform.position;
                pointsController.AddLives(-1);
            }
            
        }
    }
}
