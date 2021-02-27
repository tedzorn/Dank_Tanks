using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.2f;
    public int Health = 10;
    
    public GameObject gObj;
    public Rigidbody2D playerrb;
    public Rigidbody2D enemyrb;
    private float maxspeed = 0.5f;
	private float acceleration = 0.05f;
    private Vector3 z_angle;
    private float angle = 1.0f;

   

    void Start()
    {
        enemyrb = gameObject.GetComponent<Rigidbody2D>();
        gObj = GameObject.Find("Tank Blue Base Idle");
        
        
    }
		
    // Update is called once per frame
    void FixedUpdate()
    {
	    if (gObj ?? false)
	    {
		    EnemyMovement();
		    EnemyRotation();
	    }

    }

    void EnemyMovement()
    {

        if (gObj)
        {
            playerrb = gObj.GetComponent<Rigidbody2D>();
            var playerpos = new Vector2(playerrb.position.x, playerrb.position.y);
			var  enemypos = new Vector2(enemyrb.position.x, enemyrb.position.y);
			float dx = playerpos.x - enemypos.x;
    		float dy = playerpos.y - playerpos.y;
    		float distance = Mathf.Sqrt(dx * dx + dy * dy);
            var movementVector = new Vector2(1,1);
			
			if(distance < 100){
				if(speed < maxspeed){
				speed += acceleration * Time.deltaTime;
				}
				else{
					speed = maxspeed;
					}
				transform.Translate(0f, speed * Time.deltaTime, 0f);
				}
			else{
				speed -= acceleration * Time.deltaTime;
				}
				transform.Translate(0f, speed * Time.deltaTime, 0f);
			}

            /*if (playerx > enemyrb.position.x)
            {
                movementVector.x = speed;
            }
            else
            {
                movementVector.x = -speed;
            }

            if (playery > enemyrb.position.y)
            {
                movementVector.y = speed;

            }
            else
            {
                movementVector.y = -speed;
            }
*/
           // enemyrb.MovePosition(enemyrb.position + movementVector * Time.fixedDeltaTime);

            
        
    }
    
    void EnemyRotation()
    {
        
        
        Vector3 playerLocation = playerrb.position;
        playerLocation.z = 0f;

        Vector3 aimDirection = (playerLocation - transform.position).normalized;
        angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		var neededRotation = Quaternion.LookRotation(Vector3.forward, aimDirection - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,neededRotation, 1f * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("PlayerProjectile") | other.gameObject.CompareTag("Player") | other.gameObject.CompareTag("Bomb"))
	    {
		    Destroy(gameObject);
	    }
    }




    

    
    
}
