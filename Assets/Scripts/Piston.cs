using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Piston : MonoBehaviour
{
    private float power;
    private Vector3 starterPosition = new Vector3(0, 0.01f, 1);
    private Vector3 enderPosition = new Vector3(0, 0.01f, 0);
    private bool getBack;
    private AudioSource sound;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {        
        if (getBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, enderPosition, .3f);
            if (transform.position == enderPosition)
            {
                getBack = false;
            }
        }
        if (transform.position != starterPosition)
        {
            transform.position = Vector3.Lerp(transform.position, starterPosition, Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        sound.Play();
        power = Random.Range(17, 23);
        collision.rigidbody.AddForce(Vector3.back * power, ForceMode.Impulse);
        ScoreCounter.score.scoreValue = 0;
    }
    private void OnCollisionExit(Collision collision)
    {
        getBack = true;
    }
}
