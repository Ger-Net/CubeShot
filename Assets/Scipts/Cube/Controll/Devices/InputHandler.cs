using UnityEngine;

public abstract class InputHandler
{
    protected Vector3 _mousePos;
    protected float _move;
    protected bool _touched;

    protected Cube _currentCube;

    public abstract void Input(float sensivity, float roadSize);
    protected void Impulse()
    {

    }
    public void SetCube(Cube cube)
    {
        _currentCube = cube;
    }
}
