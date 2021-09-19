using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private const string BALL_OBJECT_TAG = "Ball";

    [SerializeField] int multiplier = 1;
    [SerializeField] GameManager gameManager;
    [SerializeField] int pointsToAdd = 0;

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
