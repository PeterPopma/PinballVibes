using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private new Light light;
    private float lightValue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (lightValue > 0)
        {
            lightValue -= 20000 * Time.deltaTime;
            if (lightValue>10000)
            {
                light.intensity = (12000 - lightValue) * 5;
            }
            else
            {
                light.intensity = lightValue;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Game.Instance.Score += 300;
        lightValue = 12000;
    }
}
