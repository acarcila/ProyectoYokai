using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{

    public Character_Controller controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float VerticalMove = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        VerticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
    }

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, VerticalMove, false, false);
    }

}
