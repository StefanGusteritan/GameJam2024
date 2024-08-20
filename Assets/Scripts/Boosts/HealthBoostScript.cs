using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoostScript : BoostScipt
{
    [SerializeField] float health;
    HealthScript playerHealth;
    public override void Power(GameObject player)
    {
        playerHealth = player.GetComponent<HealthScript>();
        playerHealth.heal(health);
    }
}
