using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;

    public void UpdateText(string text)
    {
        _score.text = text;
    }
}
