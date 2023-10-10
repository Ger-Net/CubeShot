using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    private Cube _currentCube;

    public void SetCube(Cube cube)
    { 
        _currentCube = cube; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Cube cube) && cube != _currentCube)
            _gameOverPanel.SetActive(true);
    }
}
