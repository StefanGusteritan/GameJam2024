using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] float health, maxHealh;
    LevelLogicScript logicScript;

    private void Start() {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LevelLogicScript>();

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
        if (health + hp <= maxHealh)
            health += hp;
        else
            health = maxHealh;

        Debug.Log(gameObject.name + " heal (+" + hp + " hp)");
    }

    //Deletes the object when it has no more health and opens the game over menu
    public void Die()
    {
        GameObject.Destroy(gameObject);
        Debug.Log(gameObject.name + " deleted");
        logicScript.GameOver();
    }

    public float GetMaxHealth()
    {
        return maxHealh;
    }

    public float GetHealth()
    {
        return health;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer == 6)
            takeDamage(10);

        else if (other.gameObject.layer == 8)
            takeDamage(other.gameObject.GetComponent<ProjectileScript>().GetDamage());
    }
}
