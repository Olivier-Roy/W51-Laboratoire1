using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private const string LAUNCH_TRIGGER_TAG = "LauncherTrigger";
    private const string LOST_TRIGGER_TAG = "LostTrigger";
    private const string LAUNCH_BUTTON_NAME = "Jump";
    private const float LAUNCH_FORCE_MULTIPLIER = 200f;

    private const float RESPAWN_POSITION_X = 17f;
    private const float RESPAWN_POSITION_Y = 0.5f;
    private const float RESPAWN_POSITION_Z = 13f;

    private bool holdLaunch = false;
    private float holdLaunchTimer = 0f;
    private float respawnTimer = 0f;
    private const float HOLD_LAUNCH_LIMIT = 2f;
    private const float RESPAWN_DELAY = 2f;
    private string triggerTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageLaunchButtonDown();
        ManageLaunchButtonUp();
        ManageRespawn();
    }

    private void OnTriggerEnter(Collider collider)
    {
        string colliderTag = collider.gameObject.tag;
        if (colliderTag == LAUNCH_TRIGGER_TAG || colliderTag == LOST_TRIGGER_TAG)
            triggerTag = colliderTag;
    }

    private void OnTriggerExit(Collider collider)
    {
        string colliderTag = collider.gameObject.tag;
        if (colliderTag == LAUNCH_TRIGGER_TAG || colliderTag == LOST_TRIGGER_TAG)
            triggerTag = null;
        if (colliderTag == LOST_TRIGGER_TAG)
            respawnTimer = 0f;
    }

    private void ManageLaunchButtonDown()
    {
        if (Input.GetButtonDown(LAUNCH_BUTTON_NAME))
            holdLaunch = true;

        if (holdLaunch)
            holdLaunchTimer += Time.deltaTime;

        if (holdLaunchTimer > HOLD_LAUNCH_LIMIT)
            holdLaunchTimer = HOLD_LAUNCH_LIMIT;
    }

    private void ManageLaunchButtonUp()
    {
        if (Input.GetButtonUp(LAUNCH_BUTTON_NAME))
        {
            if (triggerTag == LAUNCH_TRIGGER_TAG)
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(holdLaunchTimer * LAUNCH_FORCE_MULTIPLIER, 0.0f, 0.0f), ForceMode.Impulse);

            holdLaunchTimer = 0f;
            holdLaunch = false;
        }
    }

    private void ManageRespawn()
    {
        if (triggerTag == LOST_TRIGGER_TAG)
        {
            respawnTimer += Time.deltaTime;
            if (respawnTimer >= RESPAWN_DELAY)
                gameObject.transform.position = new Vector3(RESPAWN_POSITION_X, RESPAWN_POSITION_Y, RESPAWN_POSITION_Z);
        }
    }
}