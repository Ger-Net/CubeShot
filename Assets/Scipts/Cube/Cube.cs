using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    public event Action<Cube,Cube> OnCollisionDetected;
    [SerializeField] private CubeData _data;

    public CubeData Data => _data;

    private void OnCollisionEnter(Collision collision)
    {
        if (_data.Index == 10)
            return;
        if(collision.gameObject.TryGetComponent(out Cube cube))
        {
            if (_data.Index != cube.Data.Index)
                return;
            OnCollisionDetected?.Invoke(this,cube);
        }
    }
}