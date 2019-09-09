using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField]float movementSpeed = 1.0f;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    Vector2 playerCoords2D = Vector2.zero; 

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 lookDirection = Vector3.zero;
    private bool lookChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }

    public Vector2 GetPlayerCoords2D()
    {
        return playerCoords2D;
    }

    public void SetPlayerCoords2D(Vector2 pos)
    {
        playerCoords2D = pos;
    }

    public void SetMoveDirection(Vector3 input){
        moveDirection = input;
    }

    public void SetLookDirection(Vector2 input)
    {
        Vector2 cursorDistance = input - playerCoords2D;
        lookDirection = new Vector2(2 * cursorDistance.x / Screen.width, 2 * cursorDistance.y / Screen.height);
        lookChanged = true;
    }

    public void Jump(){
        moveDirection.y = jumpSpeed;
    }



    // Update is called once per frame
    void Update()
    {
        if (lookChanged)
        {
            this.transform.LookAt(new Vector3(transform.position.x+lookDirection.x,transform.position.y,transform.position.z+lookDirection.y));
            lookChanged = false;
        }

        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection *= speed;

        }
        else
            moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
