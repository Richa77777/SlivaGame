using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Sounds
{
    public class StepSoundPlay : MonoBehaviour
    {
        [Serializable] 
        private struct StepSounds
        {
            [Serializable] 
            private struct Walk
            {
                [SerializeField] private AudioClip _dirtyGround;
                [SerializeField] private AudioClip _grass;
                [SerializeField] private AudioClip _gravel;
                [SerializeField] private AudioClip _leaves;
                [SerializeField] private AudioClip _metal;
                [SerializeField] private AudioClip _mud;
                [SerializeField] private AudioClip _rock;
                [SerializeField] private AudioClip _sand;
                [SerializeField] private AudioClip _snow;
                [SerializeField] private AudioClip _tile;
                [SerializeField] private AudioClip _water;
                [SerializeField] private AudioClip _wood;
            }

            [Serializable] 
            private struct Run
            {
                [SerializeField] private AudioClip _dirtyGround;
                [SerializeField] private AudioClip _grass;
                [SerializeField] private AudioClip _gravel;
                [SerializeField] private AudioClip _leaves;
                [SerializeField] private AudioClip _metal;
                [SerializeField] private AudioClip _mud;
                [SerializeField] private AudioClip _rock;
                [SerializeField] private AudioClip _sand;
                [SerializeField] private AudioClip _snow;
                [SerializeField] private AudioClip _tile;
                [SerializeField] private AudioClip _water;
                [SerializeField] private AudioClip _wood;
            }

            [Serializable]
            private struct Jump
            {
                [SerializeField] private AudioClip _dirtyGround;
                [SerializeField] private AudioClip _grass;
                [SerializeField] private AudioClip _gravel;
                [SerializeField] private AudioClip _leaves;
                [SerializeField] private AudioClip _metal;
                [SerializeField] private AudioClip _mud;
                [SerializeField] private AudioClip _rock;
                [SerializeField] private AudioClip _sand;
                [SerializeField] private AudioClip _snow;
                [SerializeField] private AudioClip _tile;
                [SerializeField] private AudioClip _water;
                [SerializeField] private AudioClip _wood;
            }

            [SerializeField] private Walk _walk;
            [Space(5)]
            [SerializeField] private Run _run;
            [Space(5)]
            [SerializeField] private Jump _jump;
        }

        [SerializeField] private StepSounds _sounds;
        
        [Space(15)]
        
        [SerializeField] private AudioClip _currentSound;

        //public AudioClip CurrentSound { get { return _currentSound; } set { _currentSound = value; } }

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound()
        {
            _audioSource?.PlayOneShot(_currentSound);
        }
    }
}