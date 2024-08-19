using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    GameObject player, weapon;
    [SerializeField] Slider healtBar;
    HealthScript health;
    GunScript weaponLogic;
    [SerializeField] Image weaponImage;
    [SerializeField] TextMeshProUGUI amoText;
     int amo;
    

    // Start is called before the first frame update
    void Start()
    {
        //Gets the player object
        player = GameObject.FindGameObjectWithTag("Player");

        //Gets the health script and sets the slider max value to the player max health
        health = player.GetComponent<HealthScript>();
        healtBar.maxValue = health.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the helth bar value to the players health
        healtBar.value = health.GetHealth();

        amo = weaponLogic.GetAmo();
        amoText.text = (amo == -1)? "R" : amo.ToString();
    }

    public void ChangeWeapon(GameObject newWeapon)
    {
        weapon = newWeapon;
        weaponLogic = newWeapon.GetComponent<GunScript>();
        weaponImage.sprite = weaponLogic.hudSprite;
    }
}
