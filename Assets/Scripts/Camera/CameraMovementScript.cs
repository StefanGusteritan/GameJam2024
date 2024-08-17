using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerBody;
    Vector3 targetPosition;
    [SerializeField] float offset = 5, maxSpeed = 3, speed;

    // Update is called once per frame
    private void FixedUpdate()
    {
        targetPosition = playerBody.position;
        targetPosition.z = transform.position.z;
        speed = Vector3.Distance(targetPosition, transform.position) / offset * maxSpeed;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
    }
}
