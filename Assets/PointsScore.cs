using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsScore : MonoBehaviour
{
    public bool scoreIsRunning = true;
    public TMP_Text pointsText;

    public string scoreFromated { get; set; }

    public static int globalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIsRunning){
            DisplayScore(globalScore);
        }
    }

    void DisplayScore(int score){
        scoreFromated = string.Format($"Score: {score}");
        pointsText.text = scoreFromated;

    }
}
