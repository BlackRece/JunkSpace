using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject m_bulletPrefab; 
    [SerializeField] private int m_defaultCapacity = 10; 

    private ObjectPool<GameObject> m_bulletPool;
    public static BulletPool Instance;

    private void Awake() {
        Instance = this;
        
        m_bulletPool = new ObjectPool<GameObject>(
            CreateBullet,
            obj => obj.SetActive(true),
            obj => obj.SetActive(false)
        );
    }
    
    private void Start()
    {
        // Pre-warm the pool by creating the initial objects
        for (int i = 0; i < m_defaultCapacity; i++)
        {
            m_bulletPool.Get(); 
            m_bulletPool.Release(m_bulletPool.Get()); 
        }
    }
    
    private GameObject CreateBullet() => Instantiate(m_bulletPrefab, transform);

    public GameObject GetBullet(Vector3 a_pos, Quaternion a_rotation) 
    {
        GameObject l_bullet = m_bulletPool.Get();
        l_bullet.transform.position = a_pos;
        l_bullet.transform.rotation = a_rotation;
        l_bullet.SetActive(true);
        return l_bullet;
    }

    public void ReleaseBullet(GameObject a_bullet)
    {
        if(Instance == null) 
            return;
        
        a_bullet.SetActive(false);
        m_bulletPool.Release(a_bullet);
    }
}
