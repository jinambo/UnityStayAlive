using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text timeText;

    void Update(){
        timeText.text = PlayerController.GOtime;
    }
}
