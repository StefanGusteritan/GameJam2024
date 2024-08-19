using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float shootTime, projectilePositionOffset;
    float shootTimer;

    // Update is called once per frame
    void Update()
    {
        if (shootTimer < shootTime)
            shootTimer += Time.deltaTime;
        else
        {
            shootTimer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectile, transform.position + transform.up * projectilePositionOffset, transform.rotation);
        Debug.Log(projectile.name + " instantiated (" + gameObject.name + " shoot)");
    }
}
