using System;
using System.Collections;
using UnityEditor.TextCore.Text;
using UnityEngine;

public abstract class InputHandler
{
    public event Action OnImpulse;

    protected CubePhysicsConfig _physicsConfig;

    protected Vector3 _mousePos;
    protected float _move;
    protected bool _touched;

    protected Cube _currentCube;
    public InputHandler(CubePhysicsConfig physicsConfig)
    {
        _physicsConfig = physicsConfig;
    }
    public abstract void Input(float sensivity, float roadSize);
    protected void Impulse()
    {
        _currentCube.GetComponent<Rigidbody>().AddForce(_currentCube.transform.forward * _physicsConfig.dropForce, ForceMode.Impulse);
        OnImpulse?.Invoke();
    }
    public void SetCube(Cube cube)
    {
        _currentCube = cube;
    }
}
