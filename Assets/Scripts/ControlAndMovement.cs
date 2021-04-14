using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAndMovement : MonoBehaviour
{

    //Public
    public float movementSpeed = 8f;
    public float rotationSpeed = 3f;
    //Private

    //Get Components
    private CharacterController controller;
    //public Camera camera;

    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        //camera = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Vertical");
        float movementZ = Input.GetAxis("Horizontal");

        Vector3 move = transform.forward * movementX + transform.right * movementZ;

        controller.SimpleMove(move * movementSpeed);
        

    }


}
