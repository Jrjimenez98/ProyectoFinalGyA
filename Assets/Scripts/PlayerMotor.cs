using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(isDead)
            return;*/
        
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        
        // X - Left & right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        
        // Y - Up & dowwn
        moveVector.y = verticalVelocity;
        
        // Z - Forward & backward
        moveVector.z = speed;
        
        controller.Move (moveVector * Time.deltaTime);
    }

    //Lo llama cada vez que nuestra capsula golpea algo
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
            Death();
    }

    private void Death()
    {
        Debug.Log("Has chocado");
        /*isDead = false;
        GetComponent<Score>().OnDeath();*/

    }
}
