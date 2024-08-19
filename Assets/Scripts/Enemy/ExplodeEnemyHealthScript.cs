using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEnemyHealthScript : EnemyHealthScript
{
    [SerializeField] GameObject projectile;
    public override void Die()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        base.Die();
    }
}
