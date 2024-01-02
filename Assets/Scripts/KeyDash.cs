using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDash : MonoBehaviour
{
    enum Direction
    {
        North, South, East, West, Center
    }

    private float speed = 3000;
    public Rigidbody2D playerRB;
    Direction direction;
    public bool hasReachedGoal = false;
    public GameObject goalObject;

    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        direction = Direction.Center;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("direction: " + direction);
        if (!hasReachedGoal)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                playerRB.constraints = RigidbodyConstraints2D.FreezePositionY;

                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    direction = Direction.East;
                }
                else
                {
                    direction = Direction.West;
                }

            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;

                if (Input.GetAxisRaw("Vertical") == 1)
                {
                    direction = Direction.North;
                }
                else
                {
                    direction = Direction.South;
                }
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            hasReachedGoal = true;
        }
        if (other.gameObject.CompareTag("Lava"))
        {
            direction = Direction.Center;
        }
    }



    void FixedUpdate()
    {   
        switch (direction)
        {
            case Direction.North:
                playerRB.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                break;
            case Direction.South:
                playerRB.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
                break;
            case Direction.East:
                playerRB.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
                break;
            case Direction.West:
                playerRB.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                break;
            case Direction.Center:
                playerRB.velocity = Vector2.zero;
                break;
        }
    }
}

