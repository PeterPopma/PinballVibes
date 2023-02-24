using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triple : MonoBehaviour
{
    [SerializeField] Transform spawnPosition1, spawnPosition2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        if (balls.Length < 3)
        {
            Instantiate(Game.Instance.PfBall, spawnPosition1.position, Quaternion.identity);
            Instantiate(Game.Instance.PfBall, spawnPosition2.position, Quaternion.identity);
        }
        collision.collider.GetComponent<Rigidbody>().AddExplosionForce(4000f, transform.position, 5);
    }
}
