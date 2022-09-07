using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Start is called before the first frame update

    

    //public float leftRightSpeed = 4;
    private CharacterController characterController;
    private Vector3 direction;
    public float jumpSpeed;
    public float Gravity = -20;
  //public float moveSpeed = 4;
    public float forwardSpeed;
    public float leftRightSpeed = 4;
    GameManager gamemanager;

    [SerializeField]
    GameObject questionBackImage;

    private void Awake()
    {
        gamemanager = Object.FindObjectOfType<GameManager>();
    }


    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }



    // Update is called once per frame
    void Update()

    {

       
        
            direction.z = forwardSpeed;
      

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


     
        if (Swipe.swipeLeft)
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                targetPosition += Vector3.left * leftRightSpeed;
                transform.position = targetPosition;
            }
          }
          if (Swipe.swipeRight)
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {

                targetPosition += Vector3.right * leftRightSpeed;
                transform.position = targetPosition;
            }
           
          }

        transform.position = targetPosition;

     

        if(characterController.isGrounded)
        {
            direction.y = -1;
            if (Swipe.swipeUp)
            {

                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }


     

        characterController.center = characterController.center;
    }
    private void FixedUpdate()
    {
        characterController.Move(direction * Time.fixedDeltaTime);
    }
    void Jump()
    {
        direction.y = jumpSpeed;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacles")
        {
            GameOverManager.gameOver = true;
            
        }
    }

}


