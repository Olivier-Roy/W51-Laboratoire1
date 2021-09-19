using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private const string BALL_OBJECT_TAG = "Ball";
    private const int POINTS_TO_ADD = 1000;

    [SerializeField] int multiplier = 1;
    [SerializeField] GameManager gameManager;

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
