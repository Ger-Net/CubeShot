using UnityEngine;
public class CubeController : MonoBehaviour 
{
    [SerializeField] private float _sensivity = 0.0025f;
    [SerializeField] private float _roadSize = 3;

    private InputHandler _inputHandler;

    public void Init()
    {
        if (Application.platform == RuntimePlatform.Android)
            _inputHandler = new AndroidControll();
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            _inputHandler = new PCControll();

        Debug.Log(_inputHandler);
    }
    private void Update()
    {
        _inputHandler.Input(_sensivity,_roadSize);
    }
    public void SetCube(Cube cube)
    {
        _inputHandler.SetCube(cube);
    }
}
