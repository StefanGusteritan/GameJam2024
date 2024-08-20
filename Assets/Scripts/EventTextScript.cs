using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTextScript : MonoBehaviour
{
    public virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
