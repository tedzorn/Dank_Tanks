using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_movement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D bossrb;
    public float speed = 1.5f;
    public float rotateSpeed = 5.0f;
    private Vector3 lookAtPosition;
    private float angle = 1.0f;
    private float lowx;
    private float highx;
    private float lowy;
    private float highy;
    float whatwayy = 0f;
    float whatwayx = 0f;
    
    

    void Start()
    {
        bossrb = gameObject.GetComponent<Rigidbody2D>();
        
    }
    
 
    void Update() {

        //if (Time.time % 5 == 0)
        //{
            
        //}
        //else
        //{
            BossMovement();
            
        //}
 
    }

    void BossMovement()
    {
        transform.Translate(0f,Time.deltaTime, 0f);
    }
    void BossRotation(float xchange, float ychange)
    {
        lowx = -8f;
        highx = 8f;
        lowy = -5f;
        highy = 8f;
       if (xchange == 1)
        {
            lowx = 0f;
            highx = 8f;

        }
       if (xchange == 2)
       {
           lowx = -8f;
           highx = 0f;

       }

        if (ychange == 1)
        {
            lowy = 0f;
            highy = 8f;
            
        }

        if (ychange == 2f)
        {
            lowy = -5f;
            highy = 0f;
        }
        lookAtPosition = new Vector3(Random.Range(lowx, highx),0, Random.Range(lowy, highy) );
        
        float distanceX = lookAtPosition.x - transform.position.x;
        float distanceY = lookAtPosition.y - transform.position.y;
        float angle = Mathf.Atan2(distanceX, distanceY) * Mathf.Rad2Deg;
       
        Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.back);
        transform.rotation = Quaternion.Slerp(transform.rotation, endRotation, Time.deltaTime * 50);
       /* Debug.Log("in rotation");
        Vector3 rotationpoint = new Vector3(Random.Range(-100.0f, 100.0f), Random.Range(-100.0f, 100.0f), 0);
        
        Vector3 aimDirection = (rotationpoint - transform.position).normalized;
        angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        var neededRotation = Quaternion.LookRotation(Vector3.forward, aimDirection - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,neededRotation, 1f * Time.deltaTime);
        */
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rock")
        {
            Debug.Log("here");
            whatwayy = 0f;
            whatwayx = 0f;
            if (bossrb.position.y < -4)
            {
                whatwayy = 1f;
                //what new spot to be a positive spot
            }

            if (bossrb.position.x < 0)
            {
                whatwayx = 1f;
                //what the change to be in a positive way
            }

            if (bossrb.position.x > 7)
            {
                whatwayx = 2f;
            }
            if (bossrb.position.y > 8)
            {
                whatwayy = 2f;
                //what new spot to be a positive spot
            }




            BossRotation(whatwayx,whatwayy);
        }

        




    }
    
    
    
}
