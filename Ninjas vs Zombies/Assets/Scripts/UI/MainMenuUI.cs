using NinjasVsZombies.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NinjasVsZombies.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("SampleScene");
            GameManager.instance.gameStatus = Utils.GameStatus.PLAYING;
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quitting the game...");
        }
    }
}

