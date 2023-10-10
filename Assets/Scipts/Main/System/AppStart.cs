using UnityEngine;

public class AppStart : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CubeController _cubeController;
    [SerializeField] private SaveSystem _saveSystem;

    private SaveData _saveData;

    public SaveData SaveData => _saveData;

    public void StartGame()
    {
        Debug.Log("Start");
        _saveData = _saveSystem.Load();
        Debug.Log(_saveData.scoreModel.score);
        Debug.Log(_saveData.cubes);
        FillField(_saveData);
    }
    public void CleanField()
    {
        var cubes = FindObjectsOfType<Cube>();
        if (cubes.Length > 0)
            foreach (var cube in cubes)
                Destroy(cube.gameObject);
        
        _cubeController.Init();
        _cubeController.SpawnNewCube();
    }
    private void FillField(SaveData mapInfo)
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
