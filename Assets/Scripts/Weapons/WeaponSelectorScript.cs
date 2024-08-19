using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectorScript : MonoBehaviour
{
    LevelLogicScript logicScript;
    [SerializeField] int wave;

    WeaponManagerScript weaponManager;

    [SerializeField] GameObject[] wavePistols, waveSMGs, waveSnipers, waveShotguns;
    GunScript pistol, SMG, sniper, shotgun;
    ProjectileScript pistolProjectile, SMGProjectile, sniperProjectile, shotgunProjectile;
    [SerializeField] Image pistolImage, SMGImage, sniperImage, shotgunImage;
    [SerializeField] TextMeshProUGUI pistolDamage, SMGDamage, sniperDamage, shotgunDamage,
        pistolRange, SMGRange, sniperRange, shotgunRange,
        pistolBullets, SMGBullets, sniperBullets, shotgunBullets,
        pistolReloadTime, SMGReloadTime, sniperReloadTime, shotgunReloadTime;
        
    void GetWeaponInfo()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LevelLogicScript>();
        wave = logicScript.GetWave();

        weaponManager = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManagerScript>();

        pistol = wavePistols[wave].GetComponent<GunScript>();
        SMG = waveSMGs[wave].GetComponent<GunScript>();
        sniper = waveSnipers[wave].GetComponent<GunScript>();
        shotgun = waveShotguns[wave].GetComponent<GunScript>();

        pistolProjectile = pistol.GetProjectile().GetComponent<ProjectileScript>();
        SMGProjectile = SMG.GetProjectile().GetComponent<ProjectileScript>();
        sniperProjectile = sniper.GetProjectile().GetComponent<ProjectileScript>();
        shotgunProjectile = shotgun.GetProjectile().GetComponent<ProjectileScript>();

        pistolImage.sprite = pistol.hudSprite;
        SMGImage.sprite = SMG.hudSprite;
        sniperImage.sprite = sniper.hudSprite;
        shotgunImage.sprite = shotgun.hudSprite;

        pistolDamage.text = pistolProjectile.damage.ToString();
        SMGDamage.text = SMGProjectile.damage.ToString();
        sniperDamage.text = sniperProjectile.damage.ToString();
        shotgunDamage.text = shotgunProjectile.damage.ToString();

        pistolRange.text = pistolProjectile.range.ToString();
        SMGRange.text = SMGProjectile.range.ToString();
        sniperRange.text = sniperProjectile.range.ToString();
        shotgunRange.text = shotgunProjectile.range.ToString();

        pistolBullets.text = pistol.GetMaxAmo().ToString();
        SMGBullets.text = SMG.GetMaxAmo().ToString();
        sniperBullets.text = sniper.GetMaxAmo().ToString();
        shotgunBullets.text = shotgun.GetMaxAmo().ToString();

        pistolReloadTime.text = pistol.GetReloadTime().ToString();
        SMGReloadTime.text = SMG.GetReloadTime().ToString();
        sniperReloadTime.text = sniper.GetReloadTime().ToString();
        shotgunReloadTime.text = shotgun.GetReloadTime().ToString();
    }

    public void Select(int weapon)
    {
        weaponManager.changeWeapon(
            (weapon == 0)? wavePistols[wave] : 
            (weapon == 1)? waveSMGs[wave] : 
            (weapon == 2)? waveSnipers[wave] : waveShotguns[wave]
        );
    }
}
