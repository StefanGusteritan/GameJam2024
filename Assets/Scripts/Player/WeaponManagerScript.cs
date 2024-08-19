using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerScript : MonoBehaviour
{
    [SerializeField] GameObject defaultWeapon, weapon;
    HUDScript hud;

    private void Start() {
        hud = GameObject.FindGameObjectWithTag("UI").GetComponent<HUDScript>();

        changeWeapon(defaultWeapon);
    }

    public void changeWeapon(GameObject newWeapon)
    {
        GameObject.Destroy(weapon);
        weapon = Instantiate(newWeapon, transform, false);
        hud.ChangeWeapon(weapon);
        Debug.Log("Weapon changed to " + newWeapon.name);
    }
}
