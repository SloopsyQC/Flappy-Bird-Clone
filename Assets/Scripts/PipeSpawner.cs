using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipesPrefab;
    public float xSpawnPos = 10f;
    public float minY = -1f;
    public float maxY = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPipesCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator SpawnPipesCo()
    {
        while (true)
        { 
            float y = Random.Range(minY, maxY);
            Vector3 pos = new Vector3(xSpawnPos, y, 0f);
            Instantiate(pipesPrefab, pos, Quaternion.identity);
            
            yield return new WaitForSeconds(3.5f);
        }
        
        
    }
}
