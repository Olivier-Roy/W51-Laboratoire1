using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    private const string BALL_OBJECT_TAG = "Ball";

    [SerializeField] int forceMultiplier = 1;
    [SerializeField] int pointsToAdd = 0;
    [SerializeField] GameManager gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == BALL_OBJECT_TAG)
        {
            Rigidbody rigidBody = collision.gameObject.GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                rigidBody.AddForce(CreateNewForce(collision.transform.position, forceMultiplier), ForceMode.Impulse);
                gameManager.AddPoints(pointsToAdd);
            }
        }
    }

    private Vector3 CreateNewForce(Vector3 otherObjectPosition, int intensity)
    {
        return new Vector3(otherObjectPosition.x - transform.position.x,
                           otherObjectPosition.y - transform.position.y,
                           otherObjectPosition.z - transform.position.z).normalized * intensity;
    }
}
