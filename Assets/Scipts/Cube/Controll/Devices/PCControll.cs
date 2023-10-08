using UnityEngine;

public class PCControll : InputHandler
{
    public override void Input(float sensivity, float roadSize)
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            _touched = true;
            _mousePos = UnityEngine.Input.mousePosition;
        }
        if (UnityEngine.Input.GetMouseButtonUp(0) && _touched)
        {
            _touched = false;
            _move = 0;

            Impulse();
        }

        if (_touched)
        {
            _move = -(_mousePos.x - UnityEngine.Input.mousePosition.x) * sensivity;
            _mousePos = UnityEngine.Input.mousePosition;
        }

        _currentCube.transform.position = new Vector3(
            Mathf.Clamp(_currentCube.transform.position.x + _move, -roadSize, roadSize),
            _currentCube.transform.position.y,
            _currentCube.transform.position.z);
    }
}
