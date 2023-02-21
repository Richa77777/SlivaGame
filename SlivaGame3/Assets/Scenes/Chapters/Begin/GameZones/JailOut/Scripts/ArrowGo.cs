using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JailOut
{
    public class ArrowGo : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _arrow;

        [SerializeField] private float _arrowForce;
        [SerializeField] private float _arrowSpeed;

        [SerializeField] private AudioClip _arrowSound;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void ArrowLaunch()
        {
            _audioSource.PlayOneShot(_arrowSound);
            _arrow.gameObject.SetActive(true);
            _arrow.AddForce(new Vector2(_arrowForce, 0f));
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ArrowLaunch();
            }
        }
    }
}
