using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JailOut
{
    public class RunOutJail : MonoBehaviour
    {
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private GameObject _targetPoint;

        [SerializeField] private float _runSpeed;

        private IEnumerator _moveOutJailCor;
        private Animator _playerAnimator;

        private void Start()
        {
            _playerAnimator = _playerObject.GetComponent<Animator>();

            _moveOutJailCor = MoveOutJailCor();
            MoveOutJail();
        }

        public void MoveOutJail()
        {
            StartCoroutine(_moveOutJailCor);
        }

        private IEnumerator MoveOutJailCor()
        {
            _playerAnimator.SetBool("isWalking", true);
            _playerAnimator.SetFloat("WalkingSpeed", 5f);
            while (_playerObject.transform.position != _targetPoint.transform.position)
            {
                _playerObject.transform.position = Vector3.MoveTowards(_playerObject.transform.position, _targetPoint.transform.position, _runSpeed * Time.deltaTime);
                yield return null;
            }
            _playerAnimator.SetBool("isWalking", false);
            _playerAnimator.SetFloat("WalkingSpeed", 1f);

            _playerAnimator.Play("JailOut_SlivaDied", 0, 0f);
        }
    }
}
