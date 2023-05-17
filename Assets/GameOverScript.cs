using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text timeText;
    public TMP_Text scoreText;

    void Update(){
        timeText.text = PlayerController.GOtime;
        scoreText.text = string.Format($"Score: {PointsScore.globalScore}");
    }
}
