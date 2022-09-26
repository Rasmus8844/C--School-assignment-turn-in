using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private PlayerTurn playerTurn;


    [SerializeField] private float speed = 10f;
    [SerializeField] private Rigidbody playerbody;
    public Transform oriantation;

    public float jumpforce;
    public float jumpCooldwon;
    public float airMultiplier;
    bool readyToJump;

    public KeyCode jumpKey = KeyCode.Space;
    public float friction;
    public float playerHeight;
    public LayerMask ground;
    bool onGround;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    private void Start()
    {

        playerbody = GetComponent<Rigidbody>();
        playerbody.freezeRotation = true;
        readyToJump = true;
    }

    private void Update()
    {
        onGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground);
        SpeedLimiter();

        if (onGround)
            playerbody.drag = friction;
        else
            playerbody.drag = 0;

        if (playerTurn.IsPlayerTurn())
        {
            Inputs();
        }
        else
        {
            horizontalInput = 0;
            verticalInput = 0;


        }


    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Inputs()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
      
       

        if (Input.GetKey(jumpKey) && readyToJump && onGround)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldwon);

        }
    }

    private void MovePlayer()
    {

        moveDirection = oriantation.forward * verticalInput + oriantation.right * horizontalInput;

        playerbody.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

        if (onGround)
            playerbody.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

        else if (!onGround)
            playerbody.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedLimiter()
    {
        Vector3 flatVel = new Vector3(playerbody.velocity.x, 0f, playerbody.velocity.z);

        if (flatVel.magnitude > speed)
        {

            Vector3 limitedVel = flatVel.normalized * speed;
            playerbody.velocity = new Vector3(limitedVel.x, playerbody.velocity.y, limitedVel.z);


        }
    }
    private void Jump()
    {

        playerbody.velocity = new Vector3(playerbody.velocity.x, 0f, playerbody.velocity.z);
        playerbody.AddForce(transform.up * jumpforce, ForceMode.Impulse);

    }
    private void ResetJump()
    {
        readyToJump = true;

    }

}









   /* void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (IsTuchingFloor())
                {
                    Jump();

                }
            }


            if (Input.GetAxis("Horizontal") != 0)
            {

                Vector3 direction = Vector3.right * Input.GetAxis("Horizontal");

                transform.Translate(direction * speed * Time.deltaTime);
            }


            if (Input.GetAxis("Vertical") != 0)
            {

                Vector3 direction = Vector3.forward * Input.GetAxis("Vertical");

                transform.Translate(direction * speed * Time.deltaTime);

            }
        }
    }

    public void Jump()
    {
        playerbody.AddForce(Vector3.up * 180f);

    }

    private bool IsTuchingFloor()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        
    }*/



    



    


