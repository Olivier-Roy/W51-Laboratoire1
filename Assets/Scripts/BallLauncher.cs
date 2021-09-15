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
    private Collider triggerCollider;

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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == LAUNCH_TRIGGER_OBJECT_TAG)
        {
            triggerCollider = collider;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == LAUNCH_TRIGGER_OBJECT_TAG)
        {
            triggerCollider = null;
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
            if (triggerCollider != null)
            {
                Vector3 newForce = CreateNewForce(triggerCollider.transform.position, 500f);

                newForce.z += Random.Range(0f, holdLaunchTimer * 9f);

                gameObject.GetComponent<Rigidbody>().AddForce(newForce, ForceMode.Impulse);
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
