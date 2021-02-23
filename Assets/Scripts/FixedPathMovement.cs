using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPathMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.3f;
    public int Health = 10;
    public Rigidbody2D enemyrb;
    
    public float x1;
    public float y1;
    public float x2;
    public float y2;
    private Vector3 p1;
    private Vector3 p2;

	void Start()
    {
    	enemyrb = gameObject.GetComponent<Rigidbody2D>();
        p1 = new Vector3(x1, y1, 0);
        p2 = new Vector3(x2, y2, 0);
    }
		
    // Update is called once per frame
    void Update()
    {

    	transform.position = Vector3.Lerp (p1, p2, Mathf.PingPong(Time.time*speed, 1.0f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("PlayerProjectile") | other.gameObject.CompareTag("Player") | other.gameObject.CompareTag("Bomb"))
	    {
		    Destroy(gameObject);
	    }
    }
}