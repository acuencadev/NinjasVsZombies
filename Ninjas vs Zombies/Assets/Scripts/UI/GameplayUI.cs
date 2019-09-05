using NinjasVsZombies.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NinjasVsZombies.UI
{
    public class GameplayUI : MonoBehaviour
    {
        public static GameplayUI instance;

        [Header("HUD")]
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _livesText;

        [Header("Pause")]
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _pauseButton;

        [Header("Game Over")]
        [SerializeField] private GameObject _gameOverPanel;

        private void Awake()
        {
            MakeSingleton();
        }

        private void MakeSingleton()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }

        public void PauseGame()
        {
            _gameOverPanel.SetActive(false);
            _pausePanel.SetActive(true);
            _pauseButton.SetActive(false);
            GameManager.instance.gameStatus = Utils.GameStatus.PAUSED;
        }

        public void ResumeGame()
        {
            _gameOverPanel.SetActive(false);
            _pausePanel.SetActive(false);
            _pauseButton.SetActive(true);
            GameManager.instance.gameStatus = Utils.GameStatus.PLAYING;
        }

        public void RestartGame()
        {
            GameManager.instance.gameStatus = Utils.GameStatus.PLAYING;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GameOver()
        {
            GameManager.instance.gameStatus = Utils.GameStatus.GAME_OVER;
            _gameOverPanel.SetActive(true);
            _pauseButton.SetActive(false);
            _pausePanel.SetActive(false);
        }

        public void BackToMainMenu()
        {
            GameManager.instance.gameStatus = Utils.GameStatus.NOT_STARTED;
            SceneManager.LoadScene("MainMenu");
        }

        public void UpdateScore(int newScore)
        {
            _scoreText.text = $"Score: {newScore}";
        }

        public void UpdateLives(int newLives)
        {
            _livesText.text = $"Lives: {newLives}";
        }
    }
}
