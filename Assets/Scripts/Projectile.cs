using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private Rigidbody2D _rb;

	public void Initialize(Vector2 velocity)
	{
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = velocity;

		Destroy(gameObject, 10f);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
<<<<<<< Updated upstream
		if (other.gameObject.CompareTag("Enemy") | other.gameObject.CompareTag("Rock"))
=======
		if (other.gameObject.CompareTag("Player") | other.gameObject.CompareTag("Rock"))
>>>>>>> Stashed changes
		{
			Destroy(gameObject);
		}
	}
}