using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Cube : MonoBehaviour
{
    public event Action<Cube,Cube> OnCollisionDetected;

    [SerializeField] private CubeData _data;

    private BoxCollider _collider;

    public CubeData Data => _data;
    private void OnEnable()
    {
        _collider = GetComponent<BoxCollider>();
    }
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
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Floor floor))
        {
            _collider.material.staticFriction = 0;
            _collider.material.dynamicFriction = 0;
        }
        else
        {
            _collider.material.staticFriction = 0.6f;
            _collider.material.dynamicFriction = 0.6f;
        }
    }
}