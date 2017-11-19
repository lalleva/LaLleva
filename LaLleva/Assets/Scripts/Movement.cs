using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Atributes movement
    public string horizontal = "Horizontal";
    public string vertical = "Vertical";

    public float magnitudeMove = 5f;

    //Atribute camera
    public string mouseX = "Mouse X";
    public string mouseY = "Mouse Y";
    public float sensitivity = 3f;

    float rotX;
    //float rotY;

    Transform mTransform;

    //Bomb condition
    bool iHaveBomb = false;

    public delegate void PassBomb();
    public static event PassBomb OnPassBomb;

	void Start ()
    {
        mTransform = GetComponent<Transform>();

    }
	
	void Update ()
    {
        Move();
        MoveCamera();
	}

    public void Move()
    {
        //Z movement
        Vector3 directionZ = mTransform.forward;

        float senseZ = Input.GetAxis(vertical);
        Vector3 velocityZ = directionZ * senseZ * magnitudeMove;
        Vector3 movementZ = velocityZ * Time.deltaTime;

        mTransform.position += movementZ;

        //X movement
        Vector3 directionX = mTransform.right;

        float senseX = Input.GetAxis(horizontal);
        Vector3 velocityX = directionX * senseX * magnitudeMove;
        Vector3 movementX = velocityX * Time.deltaTime;

        mTransform.position += movementX;
    }

    public void MoveCamera()
    {
        rotX = Input.GetAxis(mouseX) * sensitivity;
       // rotY = Input.GetAxis(mouseY) * sensitivity;

        mTransform.Rotate(0, rotX, 0);
        //mTransform.Rotate(-rotY,0,0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisioned = collision.gameObject;

        if (collisioned.tag == "Player")
        {
            BombSticked();
        }
    }

    public void BombSticked()
    {
        if (iHaveBomb == true)
        {
            OnPassBomb();
        }
    }
}
