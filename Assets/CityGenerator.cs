using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public GameObject roadPrefab;
    public int cityWidth = 10;
    public int cityLength = 10;
    public float roadWidth = 4f;

    private void Start()
    {
        GenerateCity();
    }

    private void GenerateCity()
    {
        // Generate roads
        for (int x = 0; x < cityWidth; x++)
        {
            for (int z = 0; z < cityLength; z++)
            {
                // Instantiate road prefabs at regular intervals
                if (x % roadWidth == 0 && z % roadWidth == 0)
                {
                    Vector3 position = new Vector3(x, 0f, z);
                    Instantiate(roadPrefab, position, Quaternion.identity);
                }
            }
        }

        // Generate buildings
        for (int x = 0; x < cityWidth; x++)
        {
            for (int y = 0; y < cityLength; y++)
            {
                // Instantiate building prefabs at non-road locations
                if (x % roadWidth != 0 && y % roadWidth != 0)
                {
                    Vector3 position = new Vector3(x, 0f, y);
                    int randomIndex = Random.Range(0, buildingPrefabs.Length);
                    GameObject buildingPrefab = buildingPrefabs[randomIndex];
                    Instantiate(buildingPrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
