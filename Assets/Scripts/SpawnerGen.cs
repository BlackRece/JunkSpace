using UnityEngine;

public class SpawnerGen : MonoBehaviour {
    [SerializeField] private GameObject m_enemyPrefab;
    [SerializeField] private int m_health = 100;

    private float m_timerCounter = 0f;
    private float m_timerFrequency = 0.1f;
    private float m_timerduration = 100f;
    
    void Start()
    {
        
    }

    private void Update() {
        if (Tick())
            Spawn();
    }

    private bool Tick() {
        m_timerCounter = m_timerCounter <= m_timerduration
            ? m_timerCounter + m_timerFrequency
            : 0;

        return m_timerCounter == 0;
    }

    private void Spawn() {
        Vector3 l_playerPos = PlayerMovement.Position;
        Quaternion l_playerFacingRotation = Quaternion.LookRotation(l_playerPos - transform.position, Vector3.up);   
        Instantiate(m_enemyPrefab, transform.position, l_playerFacingRotation);
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
