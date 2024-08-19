using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPistolScript : GunScript
{
    [SerializeField] Transform pistol1, pistol2;
    public override void Shoot(GameObject projectile)
    {
        if (amo > 0)
        {
            amo--;
            Instantiate(projectile, pistol1.position+pistol1.up*projectilePositionOffset, pistol1.rotation);
            Instantiate(projectile, pistol2.position+pistol2.up*projectilePositionOffset, pistol2.rotation);
            shoot = true;
            Debug.Log("Instatiated " + projectile.name + "(" + gameObject.name + " shoot)");
        }
        else if (!reload)
            reload = true;
    }

    public override void SetSprite()
    {
        
    }
}
