using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool m_bulletPool; 
    [SerializeField] private float m_fireRate = 0.2f;
    [SerializeField] private float m_spawnPos = 0.75f;
    private float m_nextFireTime;

    private void Awake() {
        m_bulletPool = GetComponentInParent<BulletPool>(); 
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > m_nextFireTime) 
        {
            Shoot();
            m_nextFireTime = Time.time + m_fireRate; 
        }
    }

    private void Shoot() {
        Vector3 l_pos = transform.position + transform.forward * m_spawnPos;
        Quaternion l_rot = transform.rotation; 
        GameObject l_bullet = m_bulletPool.GetBullet(l_pos, l_rot); 
    }
}