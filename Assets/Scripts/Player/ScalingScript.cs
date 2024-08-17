using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ScalingScript : MonoBehaviour
{
    UnityEngine.Vector3 normalScale; 
    [SerializeField] List<float> scales = new List<float>();
    [SerializeField] float scaledTime = 30, normalTime = 60;
    float timer = 0;
    [SerializeField] bool isScaled;
    // Start is called before the first frame update
    void Start()
    {
        normalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScaled)
        {
            if(timer < scaledTime)
                timer += Time.deltaTime;
            else
            {
                timer = 0;
                transform.localScale = normalScale;
                isScaled = false;
            }
        }
        else
        {
            if (timer < normalTime)
                timer += Time.deltaTime;
            else
            {
                timer = 0;
                int scale = Random.Range(0,4);
                transform.localScale = scales[scale]*normalScale;
                isScaled = true;
            }
        }
    }
}
