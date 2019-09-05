using NinjasVsZombies.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace NinjasVsZombies.UI
{
    public class HighscoreUI : MonoBehaviour
    {
        [SerializeField] private Text _highscoreText;

        private void Update()
        {
            int highscore = HighscoreDB.Instance.GetHighScore();
            _highscoreText.text = highscore.ToString();
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
