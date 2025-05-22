using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //Initialize Variables
    public float moveSpeed = 2f;
    public float maxX = 15f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < maxX)
        {
            Destroy(gameObject);
        }
    }
}
