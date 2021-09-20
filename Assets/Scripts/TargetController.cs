using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private const string BALL_OBJECT_TAG = "Ball";
    private const int DEFAULT_MULTIPLIER = 1;
    private const int POINTS_TO_ADD = 1000;

    [SerializeField] GameManager gameManager;
    [SerializeField] int multiplier = DEFAULT_MULTIPLIER;

    public void SetBlinking(bool enabled)
    {
        if (GetComponent<demoTargetBlink>())
            GetComponent<demoTargetBlink>().enabled = enabled;
        else if (GetComponent<demoSpriteBlink>())
            GetComponent<demoSpriteBlink>().enabled = enabled;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == BALL_OBJECT_TAG)
        {
            gameManager.SetMultiplier(multiplier);
            gameManager.AddPoints(POINTS_TO_ADD);
            SetBlinking(true);
        }
    }
}
