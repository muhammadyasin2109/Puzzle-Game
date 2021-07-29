using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header ("Timer Attribute")]
    public TextMeshProUGUI timerText;
    public float time;

    [Header("Puzzle Attribute")]
    public GameObject finishPanel;
    public int progressPuzzle;
    public int totalPuzzle;

    float s;

    void Start()
    {
        
    }

    void Update()
    {
        SetTimerText();
        SetGameOver();
    }

    public void SetGameOver()
    {
        if (progressPuzzle == totalPuzzle)
        {
            finishPanel.SetActive(true);
        }
    }

    public void SetTimerText()
    {
        int minute = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time % 60);
        timerText.text = minute.ToString("00") + ":" + second.ToString("00");

        s += Time.deltaTime;
        if (s >= 1)
        {
            time--;
            s = 0;
        }
    }
}
