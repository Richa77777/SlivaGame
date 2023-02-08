using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private GameObject _fadeImage;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        _fadeImage.SetActive(true);
        _animator.Play("FadeIn", -1, 0f);
    }

    public void FadeOut()
    {
        _animator.Play("FadeOut", -1, 0f);

        Invoke(nameof(OffObject), _animator.GetCurrentAnimatorClipInfo(-1).Length);
    }

    private void OffObject()
    {
        _fadeImage.SetActive(false);
    }
}
