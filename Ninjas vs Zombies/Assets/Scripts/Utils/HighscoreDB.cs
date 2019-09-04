using UnityEngine;

namespace NinjasVsZombies.Utils
{
    public class HighscoreDB
    {
        private readonly static HighscoreDB _instance = new HighscoreDB();

        private static string HIGHSCORE_KEY = "HIGHSCORE";

        private HighscoreDB() { }

        public static HighscoreDB Instance
        {
            get
            {
                return _instance;
            }
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
        }

        public void SetHighscore(int newHighscore)
        {
            int currentScore = GetHighScore();

            if (currentScore < newHighscore)
            {
                PlayerPrefs.SetInt(HIGHSCORE_KEY, newHighscore);
            }
        }
    }
}
