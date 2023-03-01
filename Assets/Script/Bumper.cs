using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    AudioSource soundBumper;
    [SerializeField] private new Light light;
    private float timeLeftLightShine;

    // Start is called before the first frame update
    void Start()
    {
        soundBumper = GameObject.Find("Sound/bumper").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if( timeLeftLightShine > 0)
        {
            timeLeftLightShine -= Time.deltaTime;
            if( timeLeftLightShine < 0)
            {
                light.enabled = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        soundBumper.Play();
        collision.collider.GetComponent<Rigidbody>().AddExplosionForce(7000f, transform.position, 8);
        Game.Instance.IncreaseScore(1500);
        light.enabled = true;
        timeLeftLightShine = 0.2f;
    }
}
