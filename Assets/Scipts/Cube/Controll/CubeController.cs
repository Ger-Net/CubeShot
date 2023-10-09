using System.Collections;
using UnityEngine;
public class CubeController : MonoBehaviour 
{
    [SerializeField] private CubePhysicsConfig _config;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private SpawnPoints _spawnPoints;

    [SerializeField] private float _sensivity = 0.0025f;
    [SerializeField] private float _roadSize = 3;

    private InputHandler _inputHandler;

    public void Init()
    {
        if (Application.platform == RuntimePlatform.Android)
            _inputHandler = new AndroidControll(_config);
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            _inputHandler = new PCControll(_config);
        _inputHandler.OnImpulse += SpawnNewCube;
    }
    private void Update()
    {
        _inputHandler.Input(_sensivity,_roadSize);
    }
    public void SpawnNewCube()
    {
        StartCoroutine(SpawnCube());
    }
    public IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(0.5f);
        Cube cube = _spawner.StartSpawn(_spawnPoints.spawnPoint.position);
        _inputHandler.SetCube(cube);
    }
}
