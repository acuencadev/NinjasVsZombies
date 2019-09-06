using UnityEngine;

namespace NinjasVsZombies.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioSource _zombieSfx;

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
                DontDestroyOnLoad(gameObject);
            }
        }

        public void PlayClip(AudioClip audioClip)
        {
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }

        public void PlayZombieSfx()
        {
            _zombieSfx.Play();
        }

        public void StopZombieSfx()
        {
            _zombieSfx.Stop();
        }
    }
}
