using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_destruct : MonoBehaviour
{
	public int health = 5;
    
	private void OnTriggerEnter2D(Collider2D other)
    {
        
   
        if (other.gameObject.CompareTag("PlayerProjectile") | other.gameObject.CompareTag("Player"))
        {
			if (health == 0){
            	Destroy(gameObject);
			}
			health = health - 1;
        }
    }
}
