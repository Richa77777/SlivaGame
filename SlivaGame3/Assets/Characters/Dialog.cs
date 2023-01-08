using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialog : MonoBehaviour
{
    [System.Serializable]
    protected struct Phrase
    {
        [SerializeField] private Character _speaker;

        [SerializeField] private string _phraseText;
        [SerializeField] private AudioClip _voiceActing;

        public Character Speaker { get { return _speaker; } }
        public string PhraseText { get { return _phraseText; } }
        public AudioClip VoiceActing { get { return _voiceActing; } }
    }
}
