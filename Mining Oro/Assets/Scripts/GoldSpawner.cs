using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject rock;
    [SerializeField] private GameObject goldCoin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Rock (Clone)"))
        {
            Vector3 spawnPos = collision.transform.position;

            // Spawn gold coin
            Instantiate(goldCoin, spawnPos, Quaternion.identity);

            // Destroy the rock
            Destroy(collision.gameObject);
        }
    }
}
