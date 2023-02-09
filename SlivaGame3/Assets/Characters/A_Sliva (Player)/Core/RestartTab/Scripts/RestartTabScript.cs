using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class RestartTabScript : MonoBehaviour
    {
        private FadeScript _fadeScript;

        private Animator _animator;

        private Canvas _fadeCanvas;
        private Canvas _canvas;

        [SerializeField] private GameObject _restartTabObject;

        private void Awake()
        {
            _fadeScript = FindObjectOfType<FadeScript>(true);

            _animator = GetComponent<Animator>();

            _canvas = GetComponent<Canvas>();
            _fadeCanvas = _fadeScript.gameObject.GetComponent<Canvas>();
        }

        public void RestartTabOn()
        {
            _restartTabObject.SetActive(true);
            _animator.Play("RestartFadeIn", 0, 0f);
        }

        public void RestartTabOff(int delayBeforeOff)
        {
            _animator.Play("RestartFadeOut", 0, 0f);

            Invoke(nameof(OffObject), _animator.GetCurrentAnimatorClipInfo(0).Length + delayBeforeOff);
        }

        private void OffObject()
        {
            _restartTabObject.SetActive(false);
        }

        public void Restart(int delayBeforeRestart)
        {
            StartCoroutine(RestartE(delayBeforeRestart));
        }

        private IEnumerator RestartE(int delayBeforeRestart)
        {
            RestartTabOff(delayBeforeRestart);

            yield return new WaitForSeconds(_fadeScript.AnimatorGet.GetCurrentAnimatorClipInfo(0).Length + delayBeforeRestart);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            yield return new WaitForSeconds(1.5f);

            _restartTabObject.SetActive(false);
            _fadeScript.FadeImage.SetActive(false);
        }
    }
}
