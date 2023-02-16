using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchScript : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        Invoke(nameof(StartTorch), Random.Range(0.1f, 5f));
    }

    private void StartTorch()
    {
        _animator.enabled = true;

        StartCoroutine(TorchRandomIntensity());
    }

    private IEnumerator TorchRandomIntensity()
    {
        while (true)
        {
            float number = Random.Range(1f, 1.3f);

            while (_light.intensity != Mathf.Lerp(_light.intensity, number, 0.1f))
            {
                _light.intensity = Mathf.Lerp(_light.intensity, number, 0.1f);
                yield return new WaitForSeconds(0.02f);
            }

            yield return new WaitForSeconds(Random.Range(0.5f, 10f));
        }
    }
}
