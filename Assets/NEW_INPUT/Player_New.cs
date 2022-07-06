using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_New : MonoBehaviour
{
    [Header("Character Controller")]
    public CharacterController char_con;

    [Header("Player speed")]
    public float speed = 10f;
    public float sprintspeed = 2;

    [Header("Player gravity attributes")]
    public float gravity = -9.18f;
    public Transform ground_check;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [Header("Player jump attributes")]
    public float jumpHeight = 3f;

    [Header("Bools")]
    private bool isGrounded;
    public bool isRunning;

    public Transform Pos;
    public GameObject PlayNEW;
  public static Player_New Player_instance;

    private void Awake()
    {
        if(Player_instance != null)
        {
            return;
        }
        Player_instance = this;
    }
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(ground_check.position , groundDistance, groundMask);

        if(isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        char_con.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -5 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        char_con.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            char_con.Move(move * speed* sprintspeed * Time.deltaTime);
        }

      
    }

  
}
