using UnityEngine;

public class Debris : MonoBehaviour {
    [SerializeField] private GameObject m_scrapPrefab;
    [SerializeField] private GameObject m_spawnerPrefab;

    [SerializeField] private int m_health = 100;
    private bool m_hasSpawner = false;

    public void TakeDamage(int a_damageAmount)
    {
        m_health -= a_damageAmount;

        if (m_health <= 0) 
            Die();
    }

    private void Die()
    {
        
        if(m_hasSpawner)
            Instantiate(m_spawnerPrefab, transform.position, Quaternion.identity);
        else
            Instantiate(m_scrapPrefab, transform.position, Quaternion.identity);
        
        Destroy(gameObject); 
    }

    public void SetSpawner() => m_hasSpawner = true;
}