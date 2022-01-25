using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using TMPro;



public class FirstPersonMovementController : MonoBehaviour
{
    public CharacterController controller;

    Vector3 velocity;
    public float gravity = -9.81f;
    public float jumpAmount = 0.44f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float speed = 12f;
    public TextMeshProUGUI scoreUI;

    private int score;

    public GameObject InGameMenu;
    bool InGameMenuOpened;



    bool isGrounded;
    void Start()
    {
        InGameMenuOpened = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InGameMenuOpened)
            {
                InGameMenu.SetActive(false);
                InGameMenuOpened = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
              Cursor.lockState = CursorLockMode.None;
              Cursor.visible = true;
              InGameMenu.SetActive(true);
              InGameMenuOpened = true;
            }


        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            velocity.y += Mathf.Sqrt(jumpAmount * -1f * gravity);
            isGrounded = false;
        }



        if (Input.GetKey("w") && isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        if (Input.GetKey("s") && isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        if (Input.GetKey("a") && isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        if (Input.GetKey("d") && isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("moving", true);
        }
        if (!Input.GetKey("a") && !Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("d"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }
        if (isGrounded)
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
        }
    }



    public void updateScore(int incomingScore)
    {
        score += incomingScore;
        scoreUI.text = score.ToString();

    }
}
