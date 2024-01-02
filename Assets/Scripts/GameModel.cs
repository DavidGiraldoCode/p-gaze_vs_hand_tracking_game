using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    static public float eyeX;
    static public float eyeY;

    public enum Direction
    {
        North, South, East, West, Center
    }

    static public Direction[] arrayDirection = { Direction.Center, Direction.North, Direction.South, Direction.East, Direction.West };

    //static public char[] directions = new char[5] { 'c', 'n', 's', 'e', 'w' };
    static public char direction;

}


