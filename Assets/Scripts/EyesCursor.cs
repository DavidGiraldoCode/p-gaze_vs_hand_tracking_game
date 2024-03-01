using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesCursor : MonoBehaviour
{
    private float zPos;
    private float xPos;
    private float yPos;
    private Vector3 eyesVector;
    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
        eyesVector = new Vector3(0, 0, cam.nearClipPlane);
        zPos = cam.transform.position.z + cam.nearClipPlane;
    }

    void Update()
    {
        Vector3 eyesPosition = EyesPosition();
        xPos = eyesPosition.x;
        yPos = eyesPosition.y;
        transform.position = new Vector3(xPos, yPos, zPos);
    }

    private Vector3 EyesPosition()
    {
        eyesVector.x = GameModel.eyeX;
        eyesVector.y = cam.pixelHeight - GameModel.eyeY;
        Vector3 eyesPos = cam.ScreenToWorldPoint(new Vector3(eyesVector.x, eyesVector.y, cam.nearClipPlane));
        return eyesPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EyeUp"))
        {
            GameModel.direction = 'n';
        }
        else if (other.gameObject.CompareTag("EyeDown"))
        {
            GameModel.direction = 's';
        }
        else if (other.gameObject.CompareTag("EyeLeft"))
        {
            GameModel.direction = 'w';
        }
        else if (other.gameObject.CompareTag("EyeRight"))
        {
            GameModel.direction = 'e';
        }

    }

}
