using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour {
    [SerializeField] private float m_speed = 1f;
    [SerializeField] private int m_health = 100;
    
    private Rigidbody m_rb;
    private Vector3 m_target;
    private Vector3 m_targetVelocity;

    private void Start() {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        m_target = PlayerMovement.Position;

        // Calculate direction to target
        m_targetVelocity = (m_target - transform.position).normalized;
    }

    private void FixedUpdate() {
        // Apply force towards the target
        m_rb.AddForce(m_targetVelocity * m_speed, ForceMode.Force); 
    }
    
    public void TakeDamage(int a_damageAmount)
    {
        m_health -= a_damageAmount;

        if (m_health <= 0) 
            Die();
    }

    private void Die()
    {
        Destroy(gameObject); 
    }
}