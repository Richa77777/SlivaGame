using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Sounds
{
    public class StepSoundPlay : MonoBehaviour
    {
        [Space(15)]
        
        [SerializeField] private AudioClip _currentSound;
        [SerializeField] private AudioSource _audioSource;

        public AudioClip CurrentSound { get { return _currentSound; } set { _currentSound = value; } }

        private StepSoundsBase _stepSoundBase;

        private void Awake()
        {
            _stepSoundBase = FindObjectOfType<StepSoundsBase>(true);
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
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._dirtyGround;
                    break;
                case "Grass":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._grass;
                    break;
                case "Gravel":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._gravel;
                    break;
                case "Leaves":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._leaves;
                    break;
                case "Metal":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._metal;
                    break;
                case "Mud":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._mud;
                    break;
                case "Rock":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._rock;
                    break;
                case "Sand":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._sand;
                    break;
                case "Snow":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._snow;
                    break;
                case "Tile":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._tile;
                    break;
                case "Water":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._water;
                    break;
                case "Wood":
                    _currentSound = _stepSoundBase.Sounds.WalkSounds._wood;
                    break;

            }
        }
    }
}