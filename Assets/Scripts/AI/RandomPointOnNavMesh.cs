using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class RandomPointOnNavMesh : MonoBehaviour
{
    public float xMin = -10f; // Minimum x bound
    public float xMax = 10f;  // Maximum x bound
    public float zMin = -10f; // Minimum z bound
    public float zMax = 10f;  // Maximum z bound

    private NavMeshSurface navMeshSurface;

    private void Start()
    {
        // Find the NavMeshSurface component in the scene
        navMeshSurface = FindObjectOfType<NavMeshSurface>();

        // Ensure the NavMeshSurface is up-to-date
        if (navMeshSurface)
            navMeshSurface.BuildNavMesh();
        else
            Debug.LogError("NavMeshSurface not found in the scene!");
    }

    // Call this function to get a random point on the NavMesh within the specified bounds
    public Vector3 GetRandomPointOnNavMesh()
    {
        // Generate random x and z coordinates within the specified bounds
        float randomX = Random.Range(xMin, xMax);
        float randomZ = Random.Range(zMin, zMax);

        // Use the NavMesh to find a valid position on the NavMesh
        NavMeshHit hit;
        Vector3 randomPoint = Vector3.zero;

        if (NavMesh.SamplePosition(new Vector3(randomX, 0f, randomZ), out hit, 1.0f, NavMesh.AllAreas))
        {
            randomPoint = hit.position;
        }
        else
        {
            // If no valid position is found, return the center of the bounds
            Debug.LogWarning("Could not find a valid position on the NavMesh. Returning center of bounds.");
            randomPoint = new Vector3((xMin + xMax) * 0.5f, 0f, (zMin + zMax) * 0.5f);
        }

        return randomPoint;
    }
}