using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] AudioSource soundSpring;

    void OnShoot()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3.5f);
        soundSpring.Play();

        foreach (Collider collider in colliders)
        {
            Ball ball = collider.GetComponent<Ball>();
            if (ball != null)
            {
                collider.GetComponent<Ball>().Shoot();
            }
        }
    }
}
