using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 12f;
    public float gravity = -9.8f;
    // public float Gravity = Physics.gravity.y;

    Vector3 velocity;

    bool airborne;
    float airborneTime;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(velocity);
        // Should be (0, 0, 0)
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * movementSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
