using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private CubeFabric _fabric;

    public Cube MergeSpawn(Cube cube,Vector3 spawnPosition)
    {
        Cube spawnedCube = _fabric.Get(cube.Data.Index + 1);
        spawnedCube.transform.position = spawnPosition;
        return spawnedCube;
    }
    public Cube StartSpawn(Vector3 spawnPosition)
    {
        Cube spawnedCube = _fabric.Get(0);
        spawnedCube.OnCollisionDetected += Singleton<Merger>.Instance.Merge;
        spawnedCube.transform.position = spawnPosition;
        return spawnedCube;
        
    }
}