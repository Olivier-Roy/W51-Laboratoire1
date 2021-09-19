using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int POINTS_BEFORE_NEW_BALL = 100000;
    private const int DEFAULT_MULTIPLIER = 1;
    private const int MAXIMUM_MULTIPLIER = 5;
    
    private int score = 0;
    private int multiplier = DEFAULT_MULTIPLIER;
    private int remainingBalls = 3;
    private bool gameOver = false;
    private int pointsBeforeNewBall = POINTS_BEFORE_NEW_BALL;

    [SerializeField] GameObject gameOverMessage;
    [SerializeField] Text[] uiTexts = new Text[3];
    [SerializeField] GameObject[] lights = new GameObject[19];
    [SerializeField] GameObject[] targets = new GameObject[5];
    [SerializeField] GameObject jackpot;

    private void Start()
    {
        SetScoreText();
        SetMultiplierText();
        SetRemainingBallsText();
    }

    public void AddPoints(int points)
    {
        int pointsToAdd = points * multiplier;
        score += pointsToAdd;
        pointsBeforeNewBall -= pointsToAdd;
        SetScoreText();
        if (pointsBeforeNewBall <= 0)
        {
            remainingBalls++;
            SetRemainingBallsText();
            pointsBeforeNewBall += POINTS_BEFORE_NEW_BALL;
        }
    }

    public void SetMultiplier(int newMultiplier)
    {
        if (newMultiplier > multiplier)
        {
            multiplier = newMultiplier;
            SetMultiplierText();
        }
        if (multiplier == MAXIMUM_MULTIPLIER)
            jackpot.GetComponent<demoLetterCycle>().enabled = true;
    }

    public void RemoveRemainingBall()
    {
        if (remainingBalls > 0)
        {
            remainingBalls--;
            SetRemainingBallsText();
        }
        else
        {
            gameOver = true;
            gameOverMessage.SetActive(true);
        }

        ResetMultiplier();

        foreach (GameObject light in lights)
            light.GetComponent<LightController>().SetBlinking(false);
        foreach (GameObject target in targets)
            target.GetComponent<TargetController>().SetBlinking(false);
    }

    public bool GameOver()
    {
        return gameOver;
    }

    private void ResetMultiplier()
    {
        multiplier = DEFAULT_MULTIPLIER;
        SetMultiplierText();
        jackpot.GetComponent<demoLetterCycle>().enabled = false;
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