using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_speed = 5f;
    [SerializeField] private float m_rotationSpeed = 10f;
    private Rigidbody m_rb;
    
    private void Start()
    {
        m_rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        // Rotation
        float l_mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, l_mouseX * m_rotationSpeed * Time.deltaTime, 0f);

        // Movement
        float l_horizontal = Input.GetAxis("Horizontal"); 
        float l_vertical = Input.GetAxis("Vertical");

        // Calculate movement vector based on player's forward direction
        Vector3 l_forwardMovement = transform.forward * (l_vertical * m_speed); 

        // Calculate strafe movement based on player's right direction
        Vector3 l_rightMovement = transform.right * (l_horizontal * m_speed); 

        // Combine forward and strafe movement
        Vector3 l_movement = l_forwardMovement + l_rightMovement;

        m_rb.velocity = l_movement; 
    }
}
