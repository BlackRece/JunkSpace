using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_speed = 5f;
    [SerializeField] private float m_rotationSpeed = 10f;
    
    private Rigidbody m_rb;
    private bool m_isCursorLocked;

    private static Vector3 m_pos;
    public static Vector3 Position => m_pos;  
    
    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        SetCursorLock(true); 
    }

    private void Update() {
        m_pos = transform.position;
        
        if (Input.GetKeyDown(KeyCode.Escape))
            SetCursorLock(!m_isCursorLocked);
    }

    private void FixedUpdate()
    {
        if(!m_isCursorLocked)
            return;
        
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
        m_rb.velocity =  l_forwardMovement + l_rightMovement; 
    }
    
    private void SetCursorLock(bool a_state) {
        m_isCursorLocked = a_state;
        Cursor.lockState = a_state 
            ? CursorLockMode.Locked 
            : CursorLockMode.None;
        Cursor.visible = !a_state;
    }

}
