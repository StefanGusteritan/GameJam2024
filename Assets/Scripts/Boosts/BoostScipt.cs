using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScipt : MonoBehaviour
{
    public virtual void Power(GameObject player)
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 3)
        {
            Power(other.gameObject);
            Debug.Log(gameObject.name + " Destoryed");
            GameObject.Destroy(gameObject);   
        }
    }
}
