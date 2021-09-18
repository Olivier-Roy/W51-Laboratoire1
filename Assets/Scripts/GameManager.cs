using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int multiplier = 1;
    private int remainingBalls = 3;

    [SerializeField] Text[] uiTexts = new Text[3];

    private void Start()
    {
        SetScoreText();
        SetMultiplierText();
        SetRemainingBallsText();
    }

    public void AddPoint()
    {
        score++;
        SetScoreText();
    }

    public void SetMultiplier(int newMultiplier)
    {
        if (newMultiplier > multiplier)
        {
            multiplier = newMultiplier;
            SetMultiplierText();
        }
    }

    public void RemoveRemainingBall()
    {
        if (remainingBalls > 0)
        {
            remainingBalls--;
            SetRemainingBallsText();
        }
    }

    private void SetScoreText()
    {
        uiTexts[0].text = score.ToString();
    }

    private void SetMultiplierText()
    {
        uiTexts[1].text = "x" + multiplier.ToString();
    }

    private void SetRemainingBallsText()
    {
        uiTexts[2].text = remainingBalls.ToString();
    }
}