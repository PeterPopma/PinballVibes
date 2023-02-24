using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 previousPosition;
    private new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        rigidbody.AddForce(new Vector3(0, 130, 0), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Vector2 speed = position - previousPosition;
        Vector2 rotationAxis = Vector2.Perpendicular(speed);
        transform.Rotate(new Vector3(rotationAxis.x, rotationAxis.y, 0), -speed.magnitude * 40f, Space.World);
        previousPosition = position;        

        if (transform.position.y < -5)
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            if (balls.Length==1)
            {
                Game.Instance.SpawnBall();
            }
            Destroy(gameObject);
        }
    }

}
