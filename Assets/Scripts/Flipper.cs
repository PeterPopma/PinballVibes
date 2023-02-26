using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    [SerializeField] AudioSource soundFlipper;
    [SerializeField] float hitStrength = 80000f;
    [SerializeField] float dampening = 250f;
    [SerializeField] HingeJoint hingeJointLeft;
    [SerializeField] HingeJoint hingeJointRight;
    private bool leftFlipperPressed, rightFlipperPressed;
    private JointSpring jointSpringReleased = new();
    private JointSpring jointSpringPressed = new();

    public void Awake()
    {
        jointSpringPressed.spring = jointSpringReleased.spring = hitStrength;
        jointSpringPressed.damper = jointSpringReleased.damper = dampening;
        jointSpringPressed.targetPosition = hingeJointLeft.limits.max;
        jointSpringReleased.targetPosition = hingeJointLeft.limits.min;
    }

    private void OnLeftFlipper(InputValue value)
    {
        soundFlipper.Play();
        leftFlipperPressed = value.isPressed;
    }

    private void OnRightFlipper(InputValue value)
    {
        soundFlipper.Play();
        rightFlipperPressed = value.isPressed;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftFlipperPressed)
        {
            hingeJointLeft.spring = jointSpringPressed;
        }
        else
        {
            hingeJointLeft.spring = jointSpringReleased;
        }

        if (rightFlipperPressed)
        {
            hingeJointRight.spring = jointSpringPressed;
        }
        else
        {
            hingeJointRight.spring = jointSpringReleased;
        }
    }
}
