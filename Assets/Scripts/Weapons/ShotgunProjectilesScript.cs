using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectilesScript : ProjectileScript
{
    [SerializeField] ProjectileScript projectile;

    // Start is called before the first frame update
    public override void Start()
    {
        range = projectile.range;
        speed = projectile.speed;
        damage = projectile.damage * 5;
    }

    public override void Update()
    {
        
    }

    public override void Destroy()
    {
        
    }
}
