using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTabScript : MonoBehaviour
{
    private FadeScript _fadeScript;

    private Animator _fadeAnimator;
    private Animator _animator;

    private SpriteRenderer _fadeSpriteRenderer;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _fadeScript = FindObjectOfType<FadeScript>(true);

        _animator = GetComponent<Animator>();
        _fadeAnimator = _fadeScript.gameObject.GetComponent<Animator>();

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _fadeSpriteRenderer = _fadeScript.gameObject.GetComponent<SpriteRenderer>();
    }

    public void RestartTabOn()
    {
        _animator.Play("RestartFadeIn", -1, 0f);
    }

    public IEnumerator Restart()
    {
        _fadeSpriteRenderer.sortingOrder = _spriteRenderer.sortingOrder + 1;
        _fadeScript.FadeIn();

        yield return new WaitForSeconds(_fadeAnimator.GetCurrentAnimatorClipInfo(-1).Length);

        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());

        _fadeSpriteRenderer.sortingOrder = _spriteRenderer.sortingOrder - 1;
    }
}