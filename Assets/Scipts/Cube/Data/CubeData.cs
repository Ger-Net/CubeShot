using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CubeData : ScriptableObject
{
    [SerializeField] private int _score;
    [SerializeField] private int _index;

    public int Score => _score;
    public int Index => _index;
}
