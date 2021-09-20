using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private const string BALL_OBJECT_TAG = "Ball";
    private const int DEFAULT_MULTIPLIER = 1;
    private const int DEFAULT_POINTS_TO_ADD = 0;

    [SerializeField] GameManager gameManager;
    [SerializeField] int multiplier = DEFAULT_MULTIPLIER;
    [SerializeField] int pointsToAdd = DEFAULT_POINTS_TO_ADD;

    public void SetBlinking(bool enabled)
    {
        if (GetComponent<demoTargetBlink>())
            GetComponent<demoTargetBlink>().enabled = enabled;
        else if (GetComponent<demoSpriteBlink>())
            GetComponent<demoSpriteBlink>().enabled = enabled;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == BALL_OBJECT_TAG)
        {
            gameManager.SetMultiplier(multiplier);
            gameManager.AddPoints(pointsToAdd);
            SetBlinking(true);
        }
    }
}
