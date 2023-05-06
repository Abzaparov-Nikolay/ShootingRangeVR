using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeLeftTextChanger : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TimeLeftSO timeLeft;
    // Start is called before the first frame update

    public void Start()
    {
        ChangeText();
    }

    private void OnEnable()
    {
        timeLeft.onChanged += ChangeText;
    }

    private void OnDisable()
    {
        timeLeft.onChanged -= ChangeText;
    }

    private void ChangeText()
    {
        text.SetText("{0:0}", timeLeft.Get());
    }
}
