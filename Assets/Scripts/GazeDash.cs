using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeDash: MonoBehaviour
{

    enum DirectionOLD
    {
        North, South, East, West, Center
    }
    private char[] directions = new char[5] { 'c', 'n', 's', 'e', 'w' };
    //enum GameModel.Direction Direction;
    private float speed = 3000;
    public Rigidbody2D playerRB;
    //private Vector2 currentPosition;
    private Vector2 lastPosition;
    public bool isMoving = false;
    public bool hasReachedGoal = false;
    public GameObject goalObject;
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        //currentPosition = new Vector2(playerRB.position.x, playerRB.position.y);
        lastPosition = playerRB.position;
    }
    void Start()
    {
        playerRB.velocity = Vector2.zero;
        //direction = Direction.Center;
        Debug.Log("Array: " + directions);
        GameModel.direction = 'c';
        Debug.Log("GameModel.direction: " + GameModel.direction);
    }

    void Update()
    {


        //The GetAxis page describes in detail what the axisName for GetAxisRaw means. 
        //For example the Horizontal axis is managed by Left and Right, and a and d keys
        //Debug.Log("playerRB.velocity: " + playerRB.velocity);

        //Debug.Log("Time : " + (int)Time.time);
        if (!hasReachedGoal)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                playerRB.constraints = RigidbodyConstraints2D.FreezePositionY;

                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    GameModel.direction = 'e';
                }
                else
                {
                    GameModel.direction = 'w';
                }

            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;

                if (Input.GetAxisRaw("Vertical") == 1)
                {
                    //GameModel.direction = Direction.North;
                    GameModel.direction = 'n';
                }
                else
                {
                    // GameModel.direction = Direction.South;
                    GameModel.direction = 's';
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
        else if (other.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Hit!");
        }
    }
    void FixedUpdate()
    {
        float velocityMagnitude = playerRB.velocity.magnitude;
        float movementThreshold = 1f; // Tweak this value based on your game's scale
        isMoving = velocityMagnitude > movementThreshold;

        if (!hasReachedGoal && !isMoving && Time.time % 2 == 0)
        {
            switch (GameModel.direction)
            {
                case 'n'://North
                    playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;
                    playerRB.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                    break;
                case 's'://South
                    playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;
                    playerRB.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
                    break;
                case 'e'://East
                    playerRB.constraints = RigidbodyConstraints2D.FreezePositionY;
                    playerRB.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
                    break;
                case 'w'://West
                    playerRB.constraints = RigidbodyConstraints2D.FreezePositionY;
                    playerRB.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                    break;
                case 'c': //Center
                    playerRB.velocity = Vector2.zero;
                    break;
            }
        }
    }
}