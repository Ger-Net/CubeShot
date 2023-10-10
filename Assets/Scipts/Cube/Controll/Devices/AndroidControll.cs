using UnityEngine;

public class AndroidControll : InputHandler
{
    public AndroidControll(CubePhysicsConfig physicsConfig) : base(physicsConfig)
    {
    }

    public override void Input(float sensivity, float roadSize)
    {
        if (_currentCube == null)
            return;

        if (UnityEngine.Input.touchCount == 0)
            return;

        Touch t = UnityEngine.Input.GetTouch(0);

        switch (t.phase)
        {
            case TouchPhase.Began:
                _touched = true;
                _mousePos = t.position;
                break;
            case TouchPhase.Moved:
                _move = -(_mousePos.x - t.position.x) * sensivity;
                _mousePos = t.position;
                break;
            case TouchPhase.Stationary:
                _move = 0;
                break;
            case TouchPhase.Ended:
                if (!_touched)
                    return;
                _touched = false;
                _move = 0;

                Impulse();
                break;
        }
    }

}
