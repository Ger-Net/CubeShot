using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string _path;
    private void Awake()
    {
        _path = Application.persistentDataPath + "/Save.json";
    }
    private void Save()
    {
        if (!File.Exists(_path))
        {
            File.Create(_path);
        }

        var cubes = FindObjectsOfType<Cube>().Where(t=> t != Singleton<CubeController>.Instance.CurrentCube);
        SaveData saveData = new SaveData();
        saveData.scoreModel = new ScoreModel() { score = Singleton<MainGame>.Instance.GetScore() };
        saveData.cubes = new List<CubeDTO>();
        
        foreach (Cube cube in cubes)
        {
            saveData.cubes.Add(CreateDTO(cube));
        }

        var json = JsonUtility.ToJson(saveData);

        using (var writer = new StreamWriter(_path))
        {
            writer.WriteLine(json);
        }
        //Debug.Log("Saved on " + _path);
    }
    public SaveData Load()
    {
        if (!File.Exists(_path))
        {
            File.Create(_path);
        }
        string json = "";
        using(var reader = new StreamReader(_path)) 
        {
            string line;
            while((line = reader.ReadLine()) != null) { json += line; }
        }
        if (string.IsNullOrEmpty(json)) return new();
        return JsonUtility.FromJson<SaveData>(json);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    private CubeDTO CreateDTO(Cube cube)
    {
        CubeDTO cubeDTO = new CubeDTO
        {
            score = cube.Data.Score,
            index = cube.Data.Index,
            x = cube.transform.position.x,
            y = cube.transform.position.y,
            z = cube.transform.position.z,
        };
        return cubeDTO;
    }

}
