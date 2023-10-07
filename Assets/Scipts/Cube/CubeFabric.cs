using UnityEngine;

[CreateAssetMenu(menuName = "Fabrics")]
public class CubeFabric : BaseFabric
{
    [SerializeField] private Cube _cube2;
    [SerializeField] private Cube _cube4;
    [SerializeField] private Cube _cube8;
    [SerializeField] private Cube _cube16;
    [SerializeField] private Cube _cube32;
    [SerializeField] private Cube _cube64;
    [SerializeField] private Cube _cube128;
    [SerializeField] private Cube _cube256;
    [SerializeField] private Cube _cube512;
    [SerializeField] private Cube _cube1024;
    [SerializeField] private Cube _cube2048;

    public Cube Get(int index)
    {
        Cube cube;
        return index switch
        {
            0 => cube = Get(_cube2),
            1 => cube = Get(_cube4),
            2 => cube = Get(_cube8),
            3 => cube = Get(_cube16),
            4 => cube = Get(_cube32),
            5 => cube = Get(_cube64),
            6 => cube = Get(_cube128),
            7 => cube = Get(_cube256),
            8 => cube = Get(_cube512),
            9 => cube = Get(_cube1024),
            10 => cube = Get(_cube2048),
            _ => cube = Get(_cube2),
        };
    }
    private T Get<T>(T prefab) where T : Cube
    {
        T instance = CreateGameObjectInstance(prefab);
        return instance;
    }
}
