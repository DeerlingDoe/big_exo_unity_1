using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    public InputActionAsset actions;
    public float speed = 1f;
    private InputAction xAxis;
    private InputAction jump;

    private bool isGrounded;

    [SerializeField] private Transform ground;

    public float force = 1f;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jump = actions.FindActionMap("CubeActionsMap").FindAction("Jump");
        isGrounded = true;
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
        
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
    }

    void Update()
    {
        MoveX();
        Jump();
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;

    }

    

    private void Jump()
    {
        float yJump = jump.ReadValue<float>();
        if (isGrounded) 
        {
            transform.position += force * Time.deltaTime * yJump * Vector3.up;
            
        }

        isGrounded = !isGrounded;
        
    }   
}
