using NinjasVsZombies.Managers;
using NinjasVsZombies.UI;
using NinjasVsZombies.Utils;
using UnityEngine;

namespace NinjasVsZombies.Units
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : BaseUnit
    {
        [Header("Attack")]
        [SerializeField] private float _attackDelay;
        private float _nextAttackTime;

        [SerializeField] private Transform _attackPos;
        [SerializeField] private Vector2 _attackArea;
        [SerializeField] private LayerMask _whatIsEnemy;

        [Header("Throw Attack")]
        [SerializeField] private Kunai _kunaiPrefab;

        [SerializeField] private float _throwDelay;
        private float _nextThrowTime;

        [SerializeField] private int _initialKunais;

        private int _numKunais;

        [SerializeField] private Transform _kunaiHolder;

        [Header("Health")]
        [SerializeField] private int _initialLives;

        [Header("Invincible Time (After taking damage)")]
        [SerializeField] private float _invincibleTime;
        private float _invincibleCountdown;
        private bool _isInvincible;

        [Header("SFX")]
        [SerializeField] private AudioClip _attackClip;
        [SerializeField] private AudioClip _throwClip;
        [SerializeField] private AudioClip _gameOverClip;

        private int _lives;

        protected override void Start()
        {
            base.Start();

            _lives = _initialLives;
            _numKunais = _initialKunais;

            GameplayUI.instance.UpdateScore(0);
            GameplayUI.instance.UpdateLives(_lives);
            GameplayUI.instance.UpdateNumKunais(_numKunais);
        }

        private void Update()
        {
            if (_isInvincible)
            {
                _invincibleCountdown -= Time.deltaTime;

                if (_invincibleCountdown < 0)
                {
                    _isInvincible = false;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_attackPos.position, _attackArea);
        }

        private bool CanAttack()
        {
            return Time.time >= _nextAttackTime;
        }

        public void Attack()
        {
            if (!CanAttack())
            {
                return;
            }

            _nextAttackTime = Time.time + _attackDelay;

            _animator.SetTrigger("Attack");

            AudioManager.instance.PlayClip(_attackClip);
        }

        public override void Move(float xDirection)
        {
            _lookDirection.Set(xDirection, 0);
            _lookDirection.Normalize();

            _animator.SetFloat("Look X", _lookDirection.x);
            _animator.SetFloat("Speed", _lookDirection.magnitude);

            Vector2 newPos = _rb2d.position + _lookDirection * _speed * Time.deltaTime;

            _rb2d.MovePosition(newPos);
        }

        public override void Die()
        {
            _animator.SetTrigger("Die");
            _rb2d.simulated = false;
        }

        public void StopMoving()
        {
            _animator.SetFloat("Speed", 0);
        }

        public void Jump()
        {
            Debug.Log("Player Jump");
        }

        public void DamageEnemiesOnAttack()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(_attackPos.position, _attackArea, 0f, _whatIsEnemy);

            foreach (Collider2D collider in enemiesToDamage)
            {
                collider.GetComponent<Zombie>().Die();
            }
        }

        public void Throw()
        {
            if (!CanThrow() || _kunaiPrefab == null || _numKunais <= 0)
            {
                return;
            }

            AudioManager.instance.PlayClip(_throwClip);

            _nextThrowTime = Time.time + _throwDelay;
            _numKunais--;

            _animator.SetTrigger("Throw");
        }

        public void ThrowKunai()
        {
            MovementDirection kunaiDirection =
                Mathf.Approximately(_lookDirection.x, -1f) ? MovementDirection.RightToLeft : MovementDirection.LeftToRight;

            Vector2 kunaiPosition = new Vector2(transform.position.x + (_lookDirection.x * 0.5f), transform.position.y);

            Kunai newKunai = Instantiate(_kunaiPrefab, kunaiPosition, _kunaiPrefab.transform.rotation, _kunaiHolder);
            newKunai._movementDirection = kunaiDirection;

            GameplayUI.instance.UpdateNumKunais(_numKunais);
        }

        private bool CanThrow()
        {
            return Time.time >= _nextThrowTime;
        }

        public void Slide()
        {
            Debug.Log("Player Slide");
        }

        public void TakeDamage()
        {
            if (!_isInvincible)
            {
                _isInvincible = true;
                _invincibleCountdown = _invincibleTime;

                _lives = Mathf.Clamp(_lives - 1, 0, _initialLives);

                GameplayUI.instance.UpdateLives(_lives);

                if (_lives == 0)
                {
                    Die();

                    GameplayUI.instance.GameOver();
                    AudioManager.instance.PlayClip(_gameOverClip);
                    HighscoreDB.Instance.SetHighscore(ScoreManager.instance.GetScore());
                }
            }
        }

        public void CollectKunai(int kunais)
        {
            _numKunais += kunais;
            GameplayUI.instance.UpdateNumKunais(_numKunais);
        }
    }
}