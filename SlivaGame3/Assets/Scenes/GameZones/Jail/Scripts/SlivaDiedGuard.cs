using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Jail
{
    public class SlivaDiedGuard : MonoBehaviour
    {
        private FadeScript _fade;
        private RestartTabScript _restartTab;

        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private AudioClip _mech;
        [SerializeField] private AudioClip _voiceAction1;
        [SerializeField] private AudioClip _voiceAction2;

        private void Start()
        {
            _fade = FindObjectOfType<FadeScript>(true);
            _restartTab = FindObjectOfType<RestartTabScript>(true);
        }

        public void Mech()
        {
            _audioSource.clip = _mech;
            _audioSource.Play();
        }

        public void Died()
        {
            StartCoroutine(DiedE());
        }

        private IEnumerator DiedE()
        {
            _fade.FadeIn();

            yield return new WaitForSeconds(_fade.AnimatorGet.GetCurrentAnimatorClipInfo(0).Length + 1);

            _audioSource.clip = _voiceAction1;
            _audioSource.Play();

            yield return new WaitForSeconds(_voiceAction1.length - 0.35f);

            _audioSource.clip = _voiceAction2;
            _audioSource.Play();

            yield return new WaitForSeconds(_voiceAction2.length + 0.5f);

            _restartTab.RestartTabOn();
        }
    }
}
