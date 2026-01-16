using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    //[SerializeField] private GameObject rock;
    [SerializeField] private GameObject goldCoin;

    private void HandleRock(GameObject rock)
    {
        Vector3 spawnPos = rock.transform.position;

        Instantiate(goldCoin, spawnPos, Quaternion.identity);

        if (goldCoin.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.AddForce(Vector3.up * 3f, ForceMode.Impulse);
        }

        Destroy(rock);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            HandleRock(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            HandleRock(other.gameObject);
        }
    }
}
