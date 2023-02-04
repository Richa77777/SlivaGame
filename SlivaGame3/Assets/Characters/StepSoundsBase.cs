using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundsBase : MonoBehaviour
{
    [Serializable]
    public struct StepSounds
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

        [SerializeField] public Walk WalkSounds;
        [Space(5)]
        [SerializeField] public Run RunSounds;
        [Space(5)]
        [SerializeField] public Jump JumpSounds;
    }

    [SerializeField] public StepSounds Sounds;
}
