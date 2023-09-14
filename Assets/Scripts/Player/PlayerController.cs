using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Transform objectiveToScale;
    [SerializeField] float gradesMultiply;
    float movX, movZ;
    
    Vector3 moveInput;
    Quaternion rotateInput;
    
    [SerializeField] float movementSpeed;
    private float turnSpeed = 200;
    private Rigidbody myRb;
   

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

    }*/
    private void FixedUpdate()
    {
       ControlMovement();

    }
    void ControlMovement()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = transform.forward * (verticalInput * movementSpeed);
        myRb.velocity = moveDirection;
        
        this.transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);

        
        
        /*moveInput = new Vector3(movX, moveInput.y, movZ);
        Vector3 directionToMove = myRb.rotation * moveInput;
        rotateInput = Quaternion.Euler(rotateInput.x, movX * gradesMultiply, rotateInput.z);

        myRb.MovePosition(myRb.position + directionToMove * speed * Time.fixedDeltaTime);
        //myRb.MoveRotation(myRb.rotation * rotateInput);
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up *  movZ);*/

    }
}
