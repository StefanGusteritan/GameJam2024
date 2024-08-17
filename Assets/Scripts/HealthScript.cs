using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] float health;

    // Update is called once per frame
    void Update()
    {
        //Deletes the object when it has no more health
        if (health == 0)
        {
            GameObject.Destroy(parent);
            Debug.Log(parent.name + " deleted");
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log(parent.name + " hit (-" + damage + " damage)");
    }

    public void heal(float hp)
    {
        health += hp;
        Debug.Log(parent.name + " heal (+" + hp + " hp)");
    }
}
