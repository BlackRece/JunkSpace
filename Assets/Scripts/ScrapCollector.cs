using UnityEngine;

public class ScrapCollector : MonoBehaviour
{
    public int m_scrapCount = 0; 

    private void OnTriggerEnter(Collider a_other)
    {
        if (a_other.TryGetComponent<Scrap>(out Scrap l_scrap)) 
        {
            // Increase scrap count
            m_scrapCount++;

            // Destroy the scrap object
            Destroy(l_scrap.gameObject); 
        }
    }
}
