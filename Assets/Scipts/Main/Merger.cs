using UnityEngine;

public class Merger : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;

    [SerializeField] private Cube _cube;

    public void Merge(Cube cube1, Cube cube2)
    {
        Cube cube = _spawner.MergeSpawn(cube1, cube1.gameObject.transform.position);
        cube.OnCollisionDetected += Merge;
        cube1.OnCollisionDetected -= Merge;
        cube2.OnCollisionDetected -= Merge;
        Destroy(cube1.gameObject);
        Destroy(cube2.gameObject);
        Jump(cube);
        
    }
    private void Awake()
    {
        var cubes = FindObjectsOfType<Cube>();
        foreach(Cube cube in cubes)
        {
            cube.OnCollisionDetected += Merge;
        }
        Jump();
    }
    public void Jump()
    {
        Jump(_cube);
    }
    private void Jump(Cube cube)
    {
        Cube second = FindFirstObjectByType<Cube>();
        if(second != null)
        {
            
        }
    }
}

