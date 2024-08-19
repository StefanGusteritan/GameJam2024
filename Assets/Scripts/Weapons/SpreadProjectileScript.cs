using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectileScript : ProjectileScript
{
    public override void Destroy()
    {
        GameObject.Destroy(transform.parent.gameObject);
        Debug.Log(transform.parent.gameObject.name + " Destroyed");
    }
}
