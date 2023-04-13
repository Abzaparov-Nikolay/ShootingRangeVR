using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChanger : MonoBehaviour
{
    public ScoreSO score;
    public float AddValue;
    public void IncreaseScore()
    {
        score.Add(AddValue);
    }
}
