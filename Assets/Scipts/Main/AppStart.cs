using UnityEngine;

public class AppStart : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Transform _endSpawnPoint;
    [SerializeField] private CubeController _cubeController;


    private void Awake()
    {
        Cube cube2 = _spawner.StartSpawn(_endSpawnPoint.position);
        _cubeController.Init();
        _cubeController.SpawnNewCube();
    }
}
