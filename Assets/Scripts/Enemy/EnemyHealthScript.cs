using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] float health, maxHealh, dropChanse;
    [SerializeField] DropScript drop;
    float chanse;

    private void Start() {
        health = maxHealh;
    }

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
    public virtual void Die()
    {
        chanse = Random.Range(1, 101);
        if (chanse <= dropChanse)
            drop.Drop();

        GameObject.Destroy(gameObject);
        Debug.Log(gameObject.name + " deleted");
    }
}
