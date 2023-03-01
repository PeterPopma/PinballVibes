using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private float lightValue;
    private new Light light;
    [SerializeField] AudioSource soundCircle;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightValue > 0)
        {
            lightValue -= Time.deltaTime * 10000;
            if (lightValue>5000)
            {
                light.intensity = (6000-lightValue) * 1.25f;
            }
            else
            {
                light.intensity = lightValue * 0.5f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        soundCircle.Play();
        Game.Instance.IncreaseScore(300);
        lightValue = 6000;
    }
}
