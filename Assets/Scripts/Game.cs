using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game : MonoBehaviour
{
    [SerializeField] AudioSource soundPoints;
    [SerializeField] GameObject pfBall;
    [SerializeField] TextMeshProUGUI textScore;
    public static Game Instance;
    Vector3 ballStartPosition = new Vector3(23.4300003f, 11.6300001f, 1.824f);
    private float score, currentScore;

    public GameObject PfBall { get => pfBall; set => pfBall = value; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -50.0f, 0);
        SpawnBall();
    }

    public void SpawnBall()
    {
        Instantiate(pfBall, ballStartPosition, Quaternion.identity);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        soundPoints.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore < score)
        {
            currentScore += 1000 * Time.deltaTime;
            if (currentScore > score)
            {
                currentScore = score;
            }
            textScore.text = currentScore.ToString("00000000");
        }
        else
        {
            soundPoints.Stop();
        }
    }
}
