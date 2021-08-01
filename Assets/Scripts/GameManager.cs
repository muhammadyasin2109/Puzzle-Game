using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header ("Timer Attribute")]
    public TextMeshProUGUI timerText;
    public float time;

    [Header("Puzzle Attribute")]
    public GameObject finishPanel;
    public GameObject losePanel;
    public int progressPuzzle;
    public int totalPuzzle;

    [Header("Game Attribute")]
    public GameObject hintPanel;
    public GameObject gamePanel;
    public GameObject playButton;
    public string levelType;
    public int levelIndex;
    public bool isRun;

    float s;

    void Start()
    {
        hintPanel.SetActive(true);
        gamePanel.SetActive(false);
        playButton.SetActive(true);
        isRun = true;
    }

    void Update()
    {
        if (!isRun)
            SetTimerText();

        if (progressPuzzle == totalPuzzle)
            SetGameOver(1);
        else if (time < 0)
            SetGameOver(2);
    }

    public void SetGameOver(int index)
    {
        if (index == 1)
            finishPanel.SetActive(true);
        else if (index == 2)
            losePanel.SetActive(true);

        gamePanel.SetActive(false);
        isRun = true;
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

    public void NextLevel()
    {
        if (levelIndex < 3)
            SceneManager.LoadScene($"{levelType}Level-{levelIndex + 1}");
        else
            SceneManager.LoadScene($"LevelSelection");
    }

    public void BackToHome()
    {
        SceneManager.LoadScene($"MainMenu");
    }

    public void SetFirstGame()
    {
        hintPanel.SetActive(false);
        gamePanel.SetActive(true);
        playButton.SetActive(false);
        isRun = false;
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
