using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextChanger : MonoBehaviour
{
    public ScoreSO score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ChangeScore();
        score.onChanged += ChangeScore;
    }

    private void OnDisable()
    {
        score.onChanged-= ChangeScore;
    }

    private void ChangeScore()
    {
        scoreText.SetText("{0}", score.Get());
    }
}
