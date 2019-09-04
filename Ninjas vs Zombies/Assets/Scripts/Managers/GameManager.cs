using NinjasVsZombies.Utils;
using UnityEngine;

namespace NinjasVsZombies.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [HideInInspector]
        public GameStatus gameStatus;

        private void Awake()
        {
            gameStatus = GameStatus.NOT_STARTED;
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
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
