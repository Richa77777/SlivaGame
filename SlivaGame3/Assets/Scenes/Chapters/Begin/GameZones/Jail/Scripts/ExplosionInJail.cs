using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jail
{
    [RequireComponent(typeof(AudioSource))]
    public class ExplosionInJail : MonoBehaviour
    {
        [SerializeField] private AudioClip _explosionSound;

        private AudioSource _audioSource;
        private Animator _playerAnimator;
        private FadeScript _fade;
        private IEnumerator _explosionCor;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _fade = FindObjectOfType<FadeScript>(true);
            _explosionCor = ExplosionE();
            _playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        }

        public void Explosion()
        {
            StartCoroutine(_explosionCor);
        }

        private IEnumerator ExplosionE()
        {
            _playerAnimator.Play("Jail_BoomDost", 0, 0);

            yield return new WaitForSeconds(_playerAnimator.GetCurrentAnimatorClipInfo(0).Length + 1);

            _fade.FadeIn();
            
            yield return new WaitForSeconds(_fade.AnimatorGet.GetCurrentAnimatorClipInfo(0).Length + 2);

            _audioSource.clip = _explosionSound;
            _audioSource.Play();
        }
    }
}