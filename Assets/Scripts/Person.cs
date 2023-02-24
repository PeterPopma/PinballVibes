using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    Animator animator;
    float falling;
    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (falling > 0)
        {
            falling -= Time.deltaTime;
            if (falling < 0)
            {
                animator.SetLayerWeight(1, 0);
                falling = 0;
                transform.position = originalPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (falling == 0)
        {
            falling = 4;
            Game.Instance.Score += 250;
            animator.Play("Fall", 1, 0);
            animator.SetLayerWeight(1, 1);
        }
    }


}
