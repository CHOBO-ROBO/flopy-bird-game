using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdy : MonoBehaviour
{
    private CharacterController controller;

    private const float gravity = 15f;
    private Vector3 velocity = new Vector3 (0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
       controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}