using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] float pressedPosition;
    private float releasedPosition = 0;
    [SerializeField] float power;
    private float springDamper = 0;
    private HingeJoint hinge;
    [SerializeField] string inputKey;
    private JointSpring mySpring = new JointSpring();
    private AudioSource mySound;
    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        mySound = GetComponent<AudioSource>();
    }

    private void Update()
    {        
        mySpring.spring = power;
        mySpring.damper = springDamper;

        if (Input.GetAxis(inputKey) == 1)
        {
            mySpring.targetPosition = pressedPosition;
            mySound.Play();
        }
        else
        {
            mySpring.targetPosition = releasedPosition;
        }
        hinge.spring = mySpring;
    }
}
