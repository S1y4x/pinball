using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour
{
    private Light lightBulb;
    private bool lightOn;
    private float timeOut;
    private AudioSource sound;
    void Start()
    {
        lightBulb = GetComponent<Light>();
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (lightBulb != null)
        {
            if (lightOn && timeOut > 0)
            {
                timeOut -= Time.deltaTime;
                lightBulb.enabled = true;
            }
            else
            {
                lightBulb.enabled = false;
                lightOn = false;
            }
        }
        else timeOut = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (sound) sound.Play();
        timeOut = 1.5f;
        lightOn = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (sound) sound.Play();
        timeOut = 1.5f;
        lightOn = true;
        ScoreCounter.score.scoreValue += 150;
    }
}
