using UnityEngine;

public class AppStart : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CubeController _cubeController;
    [SerializeField] private SaveSystem _saveSystem;

    private void Start()
    {
        MapInfo map = _saveSystem.Load();
        FillField(map);
    }
    public void CleanField()
    {
        var cubes = FindObjectsOfType<Cube>();
        if (cubes.Length == 0)
            return;
        foreach (var cube in cubes)
        {
            Destroy(cube.gameObject);
        }
        _cubeController.Init();
        _cubeController.SpawnNewCube();
    }
    private void FillField(MapInfo mapInfo)
    {
        if (mapInfo == null || mapInfo.cubes.Count < 1)
        {
            CleanField();
            
            return;
        }
            
        foreach(var cube in mapInfo.cubes)
        {
            var spawnPosition = new Vector3(cube.x, cube.y, cube.z);
            _spawner.Spawn(cube,spawnPosition);
        } 
        _cubeController.Init();
        _cubeController.SpawnNewCube();
    }
}
