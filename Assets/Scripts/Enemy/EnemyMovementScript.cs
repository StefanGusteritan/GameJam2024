using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D body, playerBody;
    [SerializeField] List<UnityEngine.Vector2> directions = new List<UnityEngine.Vector2>();
    [SerializeField] List<float> distances = new List<float>();
    UnityEngine.Vector2 targetPosition, targetDirection, knockback;
    float angle, knockbackTimer = 0;
    [SerializeField] float speed, rotationSpeed, knockbackPower, knockbackTime;
    [SerializeField] bool knockbacked = false;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (knockbacked)
        {
            if (knockbackTimer < knockbackTime)
                knockbackTimer += Time.deltaTime;
            else
            {
                knockbackTimer = 0;
                knockbacked = false;
            }
        }
    }
    
    void FixedUpdate()
    {
        //Rotates towrds player
        targetDirection = playerBody.position - body.position;
        angle = VectorLogic.Angle(targetDirection);
        body.SetRotation(angle);
        
        //Choses to stay in the same plase or finds another target position
        if(body.position == targetPosition)
        {
            int i = UnityEngine.Random.Range(0,4);
            int j = UnityEngine.Random.Range(0, Convert.ToInt16(Math.Pow(2, i)));
            targetPosition = playerBody.position + directions[j] * distances[i];
        }
        else
        {
            if (!knockbacked)
                //Moves to target position
                body.MovePosition(UnityEngine.Vector2.MoveTowards(body.position, targetPosition, speed * Time.deltaTime));
            else
            {
                knockback = (body.position - playerBody.position).normalized;
                transform.position = transform.position 
                    + new UnityEngine.Vector3(knockback.x, knockback.y, transform.position.z) 
                    * knockbackPower * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.layer == 3)
            knockbacked = true;
               
    }
}
