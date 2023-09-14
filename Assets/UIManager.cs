using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverTextScore;
    [SerializeField] private GameObject gameOverUI;    
    [SerializeField] private Button restartButton;
    private int score;

    public static UIManager Instance { get; private set; }

    private void Start() {
        Instance = this;
        score = 0;
        HideGameOverUI();

        restartButton.onClick.AddListener (() => {
            RestartGame();
        });
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void ScorePoint() { score += 1; }

    private void HideGameOverUI() {
        gameOverUI.SetActive(false);
    }

    private void ShowGameOverUI() {
        gameOverUI.SetActive(true);

    }

    public void SetGameOver() {
        gameOverTextScore.text = scoreText.text;
        scoreText.enabled = false;
        ShowGameOverUI();
    }

    public void RestartGame() {
        score = 0;
        HideGameOverUI();
        scoreText.enabled = true;
        SceneManager.LoadScene(0);
    }
}
