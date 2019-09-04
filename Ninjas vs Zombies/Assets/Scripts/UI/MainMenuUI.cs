using NinjasVsZombies.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NinjasVsZombies.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Gameplay");
            GameManager.instance.gameStatus = Utils.GameStatus.PLAYING;
        }

        public void Highscore()
        {
            SceneManager.LoadScene("Highscore");
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quitting the game...");
        }
    }
}

