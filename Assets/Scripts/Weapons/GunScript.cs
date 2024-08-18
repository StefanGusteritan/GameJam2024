using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    LevelLogicScript level;

    [SerializeField] float speed;
    Vector2 mousePosition, parentPosition, targetPosition;
    float angle, radius;

    [SerializeField] GameObject projectile;
    [SerializeField] int maxAmo, amo;
    [SerializeField] float reloadTime, shootTime;
    float reloadTimer, shootTimer;
    bool reload, shoot;

    private void Start() 
    {
        level = GameObject.FindGameObjectWithTag("Logic").GetComponent<LevelLogicScript>();

        radius = transform.localPosition.x;
    }

    // Update is called once per frame
    private void Update()
    { 
        if(!level.isPaused())
        { 
            //Moves and rotates towrds the mouse around the Player
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            parentPosition = transform.parent.position;
            targetPosition = (mousePosition - parentPosition).normalized * radius;
            angle = VectorLogic.Angle(targetPosition) - VectorLogic.Angle(transform.localPosition);
            transform.RotateAround(parentPosition, Vector3.forward, angle);

            if (shoot)
            {
                if (shootTimer < shootTime)
                    shootTimer += Time.deltaTime;
                else
                {
                    shootTimer = 0;
                    shoot = false;
                }
            }

            if (reload)
            {
                if (reloadTimer < reloadTime)
                    reloadTimer += Time.deltaTime;
                else
                {
                    reloadTimer = 0;
                    reload = false;
                    amo = maxAmo;
                    Debug.Log(gameObject.name + " Reloaded (" + maxAmo + " amo)");
                }
            }

            if (Input.GetMouseButtonDown(0) && !shoot && !reload)
                Shoot(projectile);

            if (Input.GetKeyDown(KeyCode.R) && !reload)
                reload = true;
        }
    }

    void Shoot(GameObject projectile)
    {
        if (amo > 0)
        {
            amo--;
            Instantiate(projectile, transform.position, transform.rotation);
            shoot = true;
            Debug.Log("Instatiated " + projectile.name + "(" + gameObject.name + " shoot)");
        }
        else if (!reload)
            reload = true;
    }
}
