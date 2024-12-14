using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassPopulator : MonoBehaviour
{
    public GameObject[] grassPrefabs;
    public int populationCount = 1000;
    int numGrass = 0;
    int grassChoice = 0;
    public BoxCollider2D boundingBox;

    // Start is called before the first frame update

    void Awake()
    {
        if (populationCount > 3000) {
                Debug.Log("I wouldn't do that if I were you...");
                populationCount = 500;
        }
    }
    void Start()
    {
        numGrass = grassPrefabs.Length;
        boundingBox = gameObject.GetComponent<BoxCollider2D>();
        if (boundingBox != null) {
            
            for (int i = 0; i < populationCount; i++) {
                grassChoice = Random.Range(0, numGrass);
                GameObject newGrass = Instantiate(grassPrefabs[grassChoice], RandomPointInBounds(boundingBox.bounds), Quaternion.identity);
                newGrass.transform.SetParent(transform);

            }
        }
    }

    /* Choose a random point according to the bounding Box Collider 2D */
    private Vector3 RandomPointInBounds(Bounds bounds) 
    {
        return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );
    }

}
