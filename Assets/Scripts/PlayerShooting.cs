using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool m_bulletPool; 
    [SerializeField] private float m_fireRate = 0.2f; 
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

    private void Shoot()
    {
        GameObject l_bullet = m_bulletPool.GetBullet(
            transform.position + transform.forward * 1f,
            transform.rotation); 
    }
}