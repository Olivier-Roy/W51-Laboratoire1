using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private float restPosition = 0f;
    [SerializeField] private float pressedPosition = 45f;
    [SerializeField] private float hitStrenght = 100000f;
    [SerializeField] private float flipperDamper = 5;

    [SerializeField] private string inputName;

    private HingeJoint hingeJoint;
    private JointSpring jointSpring = new JointSpring();

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        jointSpring.spring = hitStrenght;
        jointSpring.damper = flipperDamper;

        if (Input.GetButton(inputName))
        {
            jointSpring.targetPosition = pressedPosition;
        }
        else
        {
            jointSpring.targetPosition = restPosition;
        }

        hingeJoint.spring = jointSpring;
        hingeJoint.useLimits = true;
    }
}
