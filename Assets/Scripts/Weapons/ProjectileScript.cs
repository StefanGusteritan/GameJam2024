using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    ScalingScript playerScale;
    public float range, speed, damage;
    Vector3 startPosition;

    public virtual void Start() {
        startPosition = transform.position;

        playerScale = GameObject.FindGameObjectWithTag("Player").GetComponent<ScalingScript>();
        damage *= (gameObject.layer == 7)? playerScale.GetScale() : (1/playerScale.GetScale());
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if ((transform.position - startPosition).magnitude >= range)
            Destroy();

        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy();
    }

    public virtual void Destroy()
    {
        GameObject.Destroy(gameObject);
        Debug.Log(gameObject.name + " Destroyed");
    }

    public float GetDamage()
    {
        return damage;
    }
}
