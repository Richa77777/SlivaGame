using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FadeScript : MonoBehaviour
    {
        [SerializeField] private GameObject _fadeImage;

        private Animator _animator;

        public GameObject FadeImage { get => _fadeImage; }
        public Animator AnimatorGet { get => _animator; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void FadeIn()
        {
            _fadeImage.SetActive(true);
            _animator.Play("FadeIn", 0, 0f);
        }

        public void FadeOut(int delayBeforeOff)
        {
            _animator.Play("FadeOut", 0, 0f);

            Invoke(nameof(OffObject), _animator.GetCurrentAnimatorClipInfo(0).Length + delayBeforeOff);
        }

        private void OffObject()
        {
            _fadeImage.SetActive(false);
        }
    }
}
