using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGen : MonoBehaviour {
    private GameObject m_scrap;

    [SerializeField] private Vector2Int m_size = new(50, 50);
    private Dictionary<Vector3Int, GameObject> m_grid = new();
    
    private void Start()
    {
        m_scrap = GameObject.CreatePrimitive(PrimitiveType.Cube);
        m_scrap.GetComponent<Renderer>().material.color = Color.gray; 
        m_scrap.transform.localScale = new Vector3(1f, 2f, 1f); 
        
        var l_center = new Vector3(m_size.x / 2f, -1f, m_size.y / 2f);
        
        for (var x = 0; x < m_size.x; x++) {
            for (var z = 0; z < m_size.y; z++) {
                // Check if it's within the center area (e.g., a 3x3 square)
                if (Mathf.Abs(x - m_size.x / 2f) <= 1 && Mathf.Abs(z - m_size.y / 2f) <= 1)
                    continue; // Skip creating a cube in the center
                
                var l_pos = new Vector3Int(x, 0, z);
                
                GameObject l_tmp = Instantiate(m_scrap, transform);
                l_tmp.transform.position = l_pos - l_center;
                
                m_grid.Add(l_pos, l_tmp);
            }
        }
        
        m_scrap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
