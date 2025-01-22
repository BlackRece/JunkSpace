using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_speed = 10f; 
    [SerializeField] private float m_lifetime = 2f;
    [SerializeField] private int m_damage = 1;

    private Rigidbody m_rb;
    private float m_timer;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>(); 
        m_rb.useGravity = false; 
        GetComponent<Collider>().isTrigger = true;
        m_rb.velocity = transform.forward * m_speed; 
    }

    private void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer >= m_lifetime) 
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider a_other) 
    {
        if (a_other.TryGetComponent(out Debris l_block)) 
            l_block.TakeDamage(m_damage);
        
        if(a_other.TryGetComponent(out Enemy l_enemy))
            l_enemy.TakeDamage(m_damage);
        
        if(a_other.TryGetComponent(out SpawnerGen l_spawner))
            l_spawner.TakeDamage(m_damage);
        
        BulletPool.Instance.ReleaseBullet(gameObject);
    }

    private bool Tick() {
        return false;
    }
}