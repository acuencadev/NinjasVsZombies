using NinjasVsZombies.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int _currentScore;

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        _currentScore = 0;
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

    public void IncreaseScore(int newScore)
    {
        _currentScore += newScore;

        GameplayUI.instance.UpdateScore(_currentScore);
    }
}
