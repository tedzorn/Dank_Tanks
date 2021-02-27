using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public string keyMoveForward;
    public string keyMoveReverse;
    public string keyRotateRight;
    public string keyRotateLeft;
    public string keyPlantBomb;
    public GameObject bombPrefab;
    public GameObject tank;
    private Rigidbody2D rb2D;
    
    bool moveForward = false;
    bool moveReverse = false;
    float moveSpeed = 0f;
    float moveSpeedReverse = 0f;
    float moveAcceleration = 0.1f;
    float moveDeceleration = 0.20f;
    float moveSpeedMax = 2.5f;

    bool rotateRight = false;
    bool rotateLeft = false;
    float rotateSpeedRight = 0f;
    float rotateSpeedLeft = 0f;
    float rotateAcceleration = 4f;
    float rotateDeceleration = 10f;
    float rotateSpeedMax = 130f;
    

    void Update()
    {

        if (Input.GetKeyDown(keyPlantBomb))
        {
            GameObject tempBomb = Instantiate(bombPrefab) as GameObject;
            tempBomb.transform.position = tank.transform.position;
            tempBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        
        
        if(Input.GetKeyDown(keyRotateLeft))
        {
            rotateLeft = true;
        }
        
        if(Input.GetKeyUp(keyRotateLeft))
        {
            rotateLeft = false;
        }
        
        if (rotateLeft)
        {
            if (rotateSpeedLeft < rotateSpeedMax)
            {
                rotateSpeedLeft = rotateSpeedLeft + rotateAcceleration;
            }
            else
            {
                rotateSpeedLeft = rotateSpeedMax;
            }
        }
        
        else
        {
            if (rotateSpeedLeft > 0)
            {
                rotateSpeedLeft = rotateSpeedLeft - rotateDeceleration;
            }
            else
            {
                rotateSpeedLeft = 0;
            }
        }
        
        transform.Rotate(0f, 0f, rotateSpeedLeft * Time.deltaTime);

        
        if(Input.GetKeyDown(keyRotateRight))
        {
            rotateRight = true;
        }
        
        if(Input.GetKeyUp(keyRotateRight))
        {
            rotateRight = false;
        }
        
        if (rotateRight)
        {
            if (rotateSpeedRight < rotateSpeedMax)
            {
                rotateSpeedRight = rotateSpeedRight + rotateAcceleration;
            }
            else
            {
                rotateSpeedRight = rotateSpeedMax;
            }

        }
        
        else
        {
            if (rotateSpeedRight > 0)
            {
                rotateSpeedRight = rotateSpeedRight - rotateDeceleration;
            }
            else
            {
                rotateSpeedRight = 0;
            }
        }
        
        transform.Rotate(0f, 0f, rotateSpeedRight * Time.deltaTime * -1f);

        
        if(Input.GetKeyDown(keyMoveForward))
        {
            moveForward = true;
        }
        
        if(Input.GetKeyUp(keyMoveForward))
        {
            moveForward = false;
        }

        if (moveForward)
        {
            if (moveSpeed < moveSpeedMax)
            {
                moveSpeed = moveSpeed + moveAcceleration;
            }
            else
            {
                moveSpeed = moveSpeedMax;
            }
        }
        
        else
        {
            if (moveSpeed > 0)
            {
                moveSpeed = moveSpeed - moveDeceleration;
            }
            else
            {
                moveSpeed = 0;
            }
        }
        
        transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        //transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime));
        
        if(Input.GetKeyDown(keyMoveReverse))
        {
            moveReverse = true;
        }
        
        if(Input.GetKeyUp(keyMoveReverse))
        {
            moveReverse = false;
        }
        
        if (moveReverse)
        {
            if (moveSpeedReverse < moveSpeedMax)
            {
                moveSpeedReverse = moveSpeedReverse + moveAcceleration;
            }
            else
            {
                moveSpeedReverse = moveSpeedMax;
            }

        }
        else
        {
            if (moveSpeedReverse > 0)
            {
                moveSpeedReverse = moveSpeedReverse - moveDeceleration;
            }
            else
            {
                moveSpeedReverse = 0;
            }
        }

        transform.Translate(0f, moveSpeedReverse * Time.deltaTime * -1f, 0f);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") | other.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            rb2D.velocity = Vector2.zero;
        }
    }
    
}
