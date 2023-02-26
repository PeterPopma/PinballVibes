using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] AudioSource soundSpring;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnShoot()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2.5f);
        soundSpring.Play();

        foreach (Collider collider in colliders)
        {
            Ball ball = collider.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                collider.gameObject.GetComponent<Ball>().Shoot();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
