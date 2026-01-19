using UnityEngine;

public class TractorUpgrade : MonoBehaviour
{
    [SerializeField] GameObject tractor;
    [SerializeField] GameObject firstUpgrade;
    [SerializeField] GameObject secondUpgrade;
    [SerializeField] GameObject thirdUpgrade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpgradeTractor(GameObject tractor)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tractor"))
        {
            UpgradeTractor(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boulder"))
        {
            UpgradeTractor(other.gameObject);
        }
    }
}
