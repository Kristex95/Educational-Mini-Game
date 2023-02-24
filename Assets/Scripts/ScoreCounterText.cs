using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounterText : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    public void UpdateScore(int score)
    {
        text.text = score.ToString();
    }
}
