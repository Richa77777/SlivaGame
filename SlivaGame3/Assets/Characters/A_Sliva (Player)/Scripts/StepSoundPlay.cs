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
            public struct Walk
            {
                [SerializeField] public AudioClip _dirtyGround;
                [SerializeField] public AudioClip _grass;
                [SerializeField] public AudioClip _gravel;
                [SerializeField] public AudioClip _leaves;
                [SerializeField] public AudioClip _metal;
                [SerializeField] public AudioClip _mud;
                [SerializeField] public AudioClip _rock;
                [SerializeField] public AudioClip _sand;
                [SerializeField] public AudioClip _snow;
                [SerializeField] public AudioClip _tile;
                [SerializeField] public AudioClip _water;
                [SerializeField] public AudioClip _wood;
            }

            [Serializable]
            public struct Run
            {
                [SerializeField] public AudioClip _dirtyGround;
                [SerializeField] public AudioClip _grass;
                [SerializeField] public AudioClip _gravel;
                [SerializeField] public AudioClip _leaves;
                [SerializeField] public AudioClip _metal;
                [SerializeField] public AudioClip _mud;
                [SerializeField] public AudioClip _rock;
                [SerializeField] public AudioClip _sand;
                [SerializeField] public AudioClip _snow;
                [SerializeField] public AudioClip _tile;
                [SerializeField] public AudioClip _water;
                [SerializeField] public AudioClip _wood;
            }

            [Serializable]
            public struct Jump
            {
                [SerializeField] public AudioClip _dirtyGround;
                [SerializeField] public AudioClip _grass;
                [SerializeField] public AudioClip _gravel;
                [SerializeField] public AudioClip _leaves;
                [SerializeField] public AudioClip _metal;
                [SerializeField] public AudioClip _mud;
                [SerializeField] public AudioClip _rock;
                [SerializeField] public AudioClip _sand;
                [SerializeField] public AudioClip _snow;
                [SerializeField] public AudioClip _tile;
                [SerializeField] public AudioClip _water;
                [SerializeField] public AudioClip _wood;
            }

            [SerializeField] public Walk _walk;
            [Space(5)]
            [SerializeField] public Run _run;
            [Space(5)]
            [SerializeField] public Jump _jump;
        }

        [SerializeField] private StepSounds _sounds;
        
        [Space(15)]
        
        [SerializeField] private AudioClip _currentSound;

        public AudioClip CurrentSound { get { return _currentSound; } set { _currentSound = value; } }

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound()
        {
            _audioSource?.PlayOneShot(_currentSound);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            string tag = collision.gameObject.tag;

            switch (tag)
            {
                case "Dirty Ground":
                    _currentSound = _sounds._walk._dirtyGround;
                    break;
                case "Grass":
                    _currentSound = _sounds._walk._grass;
                    break;
                case "Gravel":
                    _currentSound = _sounds._walk._gravel;
                    break;
                case "Leaves":
                    _currentSound = _sounds._walk._leaves;
                    break;
                case "Metal":
                    _currentSound = _sounds._walk._metal;
                    break;
                case "Mud":
                    _currentSound = _sounds._walk._mud;
                    break;
                case "Rock":
                    _currentSound = _sounds._walk._rock;
                    break;
                case "Sand":
                    _currentSound = _sounds._walk._sand;
                    break;
                case "Snow":
                    _currentSound = _sounds._walk._snow;
                    break;
                case "Tile":
                    _currentSound = _sounds._walk._tile;
                    break;
                case "Water":
                    _currentSound = _sounds._walk._water;
                    break;
                case "Wood":
                    _currentSound = _sounds._walk._wood;
                    break;

            }
        }
    }
}