using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private const string LAUNCH_TRIGGER_OBJECT_TAG = "LauncherTrigger";
    private const string LOST_TRIGGER_OBJECT_TAG = "LostTrigger";
    private const string LAUNCH_BUTTON_NAME = "Jump";

    private bool holdLaunch = false;
    private float holdLaunchTimer = 0f;
    private const float holdLaunchLimit = 2f;
    private Rigidbody ballRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageLaunchButtonDown();
        ManageLaunchButtonUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == LAUNCH_TRIGGER_OBJECT_TAG)
        {
            Debug.Log("TriggerEnter");
            ballRigidbody = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == LAUNCH_TRIGGER_OBJECT_TAG)
        {
            Debug.Log("TriggerExit");
            ballRigidbody = null;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == LAUNCH_TRIGGER_OBJECT_TAG)
        {
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();

            if (rb == null) return;

            rb.AddForce(CreateNewForce(hit.transform.position, 0.5f), ForceMode.Impulse);
        }
    }

    private void ManageLaunchButtonDown()
    {
        if (Input.GetButtonDown(LAUNCH_BUTTON_NAME)) holdLaunch = true;

        if (holdLaunch) holdLaunchTimer += Time.deltaTime;

        if (holdLaunchTimer > holdLaunchLimit) holdLaunchTimer = holdLaunchLimit;
    }

    private void ManageLaunchButtonUp()
    {
        if (Input.GetButtonUp(LAUNCH_BUTTON_NAME))
        {
            if (ballRigidbody != null)
            {
                Vector3 newForce = CreateNewForce(ballRigidbody.transform.position, 30f);

                newForce.y = Random.Range(0f, holdLaunchTimer * 9f);

                ballRigidbody.AddForce(newForce, ForceMode.Impulse);
            }

            holdLaunchTimer = 0f;
            holdLaunch = false;
        }
    }

    private Vector3 CreateNewForce(Vector3 otherObjectPosition, float intensity)
    {
        return new Vector3(otherObjectPosition.x - transform.position.x,
                           otherObjectPosition.y - transform.position.y,
                           otherObjectPosition.z - transform.position.z).normalized * intensity;
    }
}
