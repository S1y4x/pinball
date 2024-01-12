using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyDisk : MonoBehaviour
{
    private int power;
    private Vector3 distance;

    private void OnCollisionEnter(Collision collision)
    {
        power = Random.Range(3, 6);
        distance = collision.gameObject.transform.position - transform.position;
        collision.rigidbody.AddForce(distance.normalized * power, ForceMode.Impulse);
        ScoreCounter.score.scoreValue += 25;
    }
}
