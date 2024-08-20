using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] ScalingScript scale;
    [SerializeField] float speed = 2, raycastOffset = 0.04F;
    [SerializeField] Rigidbody2D body;
    [SerializeField] ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    [SerializeField] Vector2 inputDirection, movement;


    // Update is called once per frame
    void Update()
    {
        //Gets the movement input
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");
        inputDirection.Normalize();
    }

    private void FixedUpdate()
    {
        //Moves the player
        RestrictMovement();
        body.MovePosition(body.position + movement);
    }

    //Creates the movement vector by verifing there are no collisions using raycasting
    private void RestrictMovement()
    {
        int count;

        count = body.Cast
        (
            new Vector2(inputDirection.x, 0),
            movementFilter,
            castCollisions,
            speed * Time.deltaTime + raycastOffset
        );
        movement.x = Convert.ToInt16(count == 0) * inputDirection.x * speed * (1 / scale.GetScale()) * Time.deltaTime;

        count = body.Cast
        (
            new Vector2(0, inputDirection.y),
            movementFilter,
            castCollisions,
            speed * Time.deltaTime + raycastOffset
        );
        movement.y = Convert.ToInt16(count == 0)* inputDirection.y * speed * Time.deltaTime;
    }
}
