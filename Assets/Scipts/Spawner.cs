using UnityEngine;

public class Spawner
{
    [SerializeField] private CubeFabric _cubeFabric;

    [SerializeField] private Transform _spawnPoint;

    public void Spawn(int index)
    {
        Cube cube = _cubeFabric.Get(index);
        cube.transform.position = _spawnPoint.position;
    }
}