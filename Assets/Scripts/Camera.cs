using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCameraBack()
    {
        transform.Translate(Vector3.forward * -500.0f * Time.deltaTime);
    }

    void OnCameraForward()
    {
        transform.Translate(Vector3.forward * 500.0f * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, transform.position.z);
        }
        else
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            if (balls.Length>0)
            {
                ball = balls[0];
            }
        }
    }
}
