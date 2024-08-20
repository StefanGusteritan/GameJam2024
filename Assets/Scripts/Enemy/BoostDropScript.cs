using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    [SerializeField] GameObject[] boosts;
    [SerializeField] int[] boostsDropChanse;
    int chanse = 0, boost;
    Quaternion boostRotation;

    public void Drop()
    {
        boost  = Random.Range(1, 101);
        for (int i = 0; i < boostsDropChanse.Length; i++)
        {
            chanse += boostsDropChanse[i];
            if (chanse >= boost)
            {
                boost = i;
                break;
            }
        }

        boostRotation = transform.rotation;
        boostRotation.z = 0;
        Instantiate(boosts[boost], transform.position, boostRotation);
        Debug.Log(gameObject.name  + " droped: " + boosts[boost].name + " instantiated");
    }
}
