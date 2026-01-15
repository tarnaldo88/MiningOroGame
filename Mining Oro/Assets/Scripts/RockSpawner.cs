using System;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;

    public int amount = 50;

    public Vector2 areaSize = new Vector2(20, 20);

    public float minScale = 0.8f;
    public float maxScale = 1.4f;

    public bool randomRotation = true;

    public LayerMask groundLayer;

    public void Spawn()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 randomPos =
                transform.position +
                new Vector3(
                    Random.Range(-areaSize.x, areaSize.x),
                    50f,
                    Random.Range(-areaSize.y, areaSize.y)
                );

            // Raycast to ground so rocks sit correctly
            if (Physics.Raycast(randomPos, Vector3.down, out RaycastHit hit, 100f, groundLayer))
            {
                GameObject rock = Instantiate(rockPrefab, hit.point, Quaternion.identity);

                // Random scale
                float s = Random.Range(minScale, maxScale);
                rock.transform.localScale = Vector3.one * s;

                if (randomRotation)
                {
                    rock.transform.rotation =
                        Quaternion.Euler(0, Random.Range(0, 360f), 0);
                }

                rock.transform.parent = transform;
            }
        }
    }
}
