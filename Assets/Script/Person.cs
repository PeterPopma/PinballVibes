using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] AudioSource soundScream;
    Animator animator;
    private float timeleftFalling;
    Vector3 originalPosition;
    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        originalPosition = transform.position; 
        originalRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeleftFalling>0)
        {
            timeleftFalling -= Time.deltaTime;
            if (timeleftFalling <= 0)
            {
                animator.SetLayerWeight(1, 0);
                transform.position = originalPosition;
                transform.rotation = originalRotation;
                timeleftFalling = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (timeleftFalling==0)
        {
            soundScream.Play();
            Game.Instance.IncreaseScore(250);
            timeleftFalling = 4;
            animator.Play("Fall", 1, 0);
            animator.SetLayerWeight(1, 1);
        }
    }
}
