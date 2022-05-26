using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
//using UnityEngine.Animations;


public class Player : MonoBehaviour
{
    [Header("New InputSystem")]
    public Input_actions controls;
    [Header("Character controller")]
    public CharacterController char_control;
   
    [Header("Player Movement")]
    public Vector3 Currentplayermovement;
    public float speed = 17f;
    public float sprint_speed = 2f;
    float velocity;
    public Transform Ground_pos;
    public float Ground_dis = 0.4f;
    public LayerMask Ground_mask;

    [Header("Gravity")]
    public float Gravity = -9.81f;

    [Header("Jump")]
    public float max_jumps = 2;
    public float jump_speed = 10f;
    public float jump_height = 4;
    [Header("Bools")]
    public bool isGrounded;
    private bool isWalking => Currentplayermovement.z > 0f || Currentplayermovement.x !=0f;
    private bool isRunning;
    private bool jumpPressed;
    

    //New input system accessing from the script.
    private void Awake()
    {
        controls = new Input_actions();
        char_control = GetComponent<CharacterController>();
     
        controls.Player.Movement.performed += ctx => movement(ctx.ReadValue<Vector2>());
        //controls.Player.Jump.performed += ctx => jump();
        controls.Player.Jump.started += jump;
        controls.Player.Jump.canceled += jump;
        controls.Player.Jump.performed += jump;

    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Checking wether the player is on the ground or not.
        isGrounded = Physics.Raycast(Ground_pos.position, Vector3.down,Ground_dis, Ground_mask);
        

        //Player Walking
        Vector2 Move_dir = controls.Player.Movement.ReadValue<Vector2>();
        Currentplayermovement.x = Move_dir.x;
        Currentplayermovement.z = Move_dir.y;
        Currentplayermovement = transform.right * Currentplayermovement.x + transform.forward * Currentplayermovement.z+ (jumpPressed && isGrounded?  jump_height * transform.up : transform.up * velocity);
        char_control.Move(Currentplayermovement*speed*Time.deltaTime);
 
        if (char_control.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity += Gravity*Time.deltaTime;
        }
        //Player Sprinting
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            isRunning = true;
            char_control.Move(Currentplayermovement * speed * sprint_speed * Time.deltaTime);
           

        }

    }
    public void movement(Vector2 Direction)
    {
        Debug.Log("Pressed" +Direction);
    }
    public void jump(InputAction.CallbackContext cxt)
    {
       
        jumpPressed = cxt.ReadValueAsButton();
     

    }
    private void OnEnable()
    {
        if (controls != null)
        controls.Enable();
    }
    private void OnDisable()
    {
        if (controls != null)
            controls.Disable();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Ground_pos.position, Vector3.down * Ground_dis);
    }
}
