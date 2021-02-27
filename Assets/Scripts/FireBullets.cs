using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    public GameObject gObj;
    
    [SerializeField] private int bulletsAmount = 5;

    [SerializeField] private float startAngle = 145f, endAngle = 225f;

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i<bulletsAmount + 1; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);
            
            Vector3 bulMoveVector = new Vector3(bulDirx, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;
            
                GameObject bul = BulletPool.bulletPoolInstanse.GetBullet();
                
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<ShotgunBullet>().SetMoveDirection(bulDir);
            

            angle += angleStep;
        }
    }
}
