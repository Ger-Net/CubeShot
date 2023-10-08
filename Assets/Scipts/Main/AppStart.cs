using UnityEngine;

public class AppStart : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Transform _startSpawnPoint;
    [SerializeField] private CubeController _cubeController;


    private void Awake()
    {
        Cube cube = _spawner.StartSpawn(_startSpawnPoint.position);
        _cubeController.Init();
        _cubeController.SetCube(cube);
    }
}
