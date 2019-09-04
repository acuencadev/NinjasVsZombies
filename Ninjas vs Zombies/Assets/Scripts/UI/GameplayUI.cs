﻿using UnityEngine;
using UnityEngine.UI;

namespace NinjasVsZombies.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [Header("HUD")]
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _livesText;

        [Header("Pause")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _pauseButton;

        public void PauseGame()
        {
            Debug.Log("Pausing the game...");
        }

        public void ResumeGame()
        {
            Debug.Log("Resuming the game...");
        }

        public void RestartGame()
        {
            Debug.Log("Restarting the game...");
        }

        public void BackToMainMenu()
        {
            Debug.Log("Going back to main menu...");
        }

        public void UpdateScore(int newScore)
        {
            _scoreText.text = $"Score: {newScore}";
        }

        public void UpdateLives(int newLives)
        {
            _livesText.text = $"Score: {newLives}";
        }
    }
}
