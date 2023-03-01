using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] AudioSource soundPoints;
    private Vector3 startPosition = new Vector3(27.3299999f, -5.30000019f, 0.189999998f);
    public static Game Instance;
    [SerializeField] GameObject pfBall;
    [SerializeField] TextMeshProUGUI textScore;
    private int score, currentScore;
    public GameObject PfBall { get => pfBall; set => pfBall = value; }

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Physics.gravity = new Vector3(0, -50, 0);
        SpawnBall();
    }

    public void IncreaseScore(int amount)
    {
        soundPoints.Play();
        score += amount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore < score)
        {
            currentScore += (int)(1000 * Time.deltaTime);
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

    public void SpawnBall()
    {
        Instantiate(pfBall, startPosition, Quaternion.identity);
    }
}
