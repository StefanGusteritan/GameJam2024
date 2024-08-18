using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    [SerializeField] Slider healtBar;
    HealthScript health;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>();
        healtBar.maxValue = health.GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healtBar.value = health.GetHealth();
    }
}
