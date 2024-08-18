using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] float health;

    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log(gameObject.name + " hit (-" + damage + " damage)");
        if (health <= 0)
            Die();
    }

    public void heal(float hp)
    {
        health += hp;
        Debug.Log(gameObject.name + " heal (+" + hp + " hp)");
    }

    //Deletes the object when it has no more health
    void Die()
    {
        GameObject.Destroy(gameObject);
        Debug.Log(gameObject.name + " deleted");
    }
}
