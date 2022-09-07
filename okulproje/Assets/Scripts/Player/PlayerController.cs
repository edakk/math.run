using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;      //0 left   1 miiddle   2 right
    public float laneDistance = 4;     //the distamce between two lanes

    public float jumpForce;
    public float Gravity;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.z = forwardSpeed;
        if (controller.isGrounded)
        {
           
            if (Swipe.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }
        //gather the inputs
        if(Swipe.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (Swipe.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        //calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desiredLane==0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane==2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        //   transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.fixedDeltaTime);

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }

        controller.Move(direction * Time.fixedDeltaTime);


    }
 /*   private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }  */
    private void Jump()
    {
        direction.y = jumpForce;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacles")
        {
            
            GameOverManager.gameOver = true;

        }
    }

}
