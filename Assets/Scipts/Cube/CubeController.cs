using UnityEngine;
public class CubeController : MonoBehaviour 
{
    private Cube _currentCube;
    private void Update()
    {
        
    }
    private void KeyboardControll()
    {
        if(Input.GetMouseButtonDown(0))
            _currentCube.transform.position = new(Input.mousePosition.x,0,0);
        if (Input.GetMouseButtonUp(1))
            Impulse();
    }
    private void PhoneControll()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
                _currentCube.transform.position = new(Input.touches[0].position.x,0,0);
            if (Input.touches[0].phase == TouchPhase.Ended)
                Impulse();        
        }
    }
    private void Impulse()
    {

    }

}
