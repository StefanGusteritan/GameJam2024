using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float range, speed, damage;
    Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - startPosition).magnitude >= range)
            Destroy();

        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy();
    }

    void Destroy()
    {
        GameObject.Destroy(gameObject);
        Debug.Log(gameObject.name + " Destroyed");
    }

    public float GetDamage()
    {
        return damage;
    }
}
