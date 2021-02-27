using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemyMovement : MonoBehaviour
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
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector3 movement;
    private float timeLeft;
    private float nextActionTime = 0.0f;
    public float period = 5f;
 
    /*
    void Update () {
	    if (Time.time > nextActionTime ) {
		    nextActionTime += period;
		    movement = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
	    }
    }
    */
   

    void Start()
    {
        enemyrb = gameObject.GetComponent<Rigidbody2D>();
        //gObj = GameObject.Find("Tank Blue Base Idle");
        Screen.SetResolution(1280, 720, false);
        
    }
		
    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMovement();
        EnemyRotation();
        
        
    }

    void EnemyMovement()
    {
	    
	    //playerrb = gObj.GetComponent<Rigidbody2D>();
	    //var playerpos = new Vector2(playerrb.position.x, playerrb.position.y);
	    var enemypos = new Vector2(enemyrb.position.x, enemyrb.position.y);
	    float dx = movement.x - enemypos.x;
	    float dy = movement.y - movement.y;
	    float distance = Mathf.Sqrt(dx * dx + dy * dy);

	    if (distance < 100)
	    {
		    if (speed < maxspeed)
		    {
			    speed += acceleration * Time.deltaTime;
		    }
		    else
		    {
			    speed = maxspeed;
		    }

		    transform.Translate(0f, speed * Time.deltaTime, 0f);
	    }
	    else
	    {
		    speed -= acceleration * Time.deltaTime;
	    }

	    transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
    
    void EnemyRotation()
    {
	    if (Time.time > nextActionTime ) {
		    nextActionTime += period;
		    movement = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
	    }
        
        //Vector3 playerLocation = playerrb.position;
        //playerLocation.z = 0f;

        Vector3 aimDirection = (movement - transform.position).normalized;
        angle = (Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg) - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		var neededRotation = Quaternion.LookRotation(Vector3.forward, aimDirection - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,neededRotation, 1f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("PlayerProjectile") | other.gameObject.CompareTag("Player"))
	    {
		    Destroy(gameObject);
	    }
    }




    

    
    
}
