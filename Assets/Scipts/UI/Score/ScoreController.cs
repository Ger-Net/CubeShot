using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Specifically, in this case, there is no need to make such a complication, 
 * but here I just wanted to show the principle of separation by MVC
 */

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreView _view;

    public void UpdateScore(int score)
    {
        _view.UpdateText(score.ToString());
    }
    
}
