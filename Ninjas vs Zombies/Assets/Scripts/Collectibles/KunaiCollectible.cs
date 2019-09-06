using NinjasVsZombies.Units;
using UnityEngine;

namespace NinjasVsZombies.Collectibles
{
    public class KunaiCollectible : MonoBehaviour
    {
        [SerializeField] private int _numKunais;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Player player = other.GetComponent<Player>();

                if (player != null)
                {
                    player.CollectKunai(_numKunais);
                }

                Destroy(gameObject);
            }
        }
    }
}
