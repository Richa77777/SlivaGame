using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jail
{
    public class MoveGuard : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 0f;
        [SerializeField] private GameObject[] _movePoints = new GameObject[2];
        [SerializeField] private DialogSystem.DialogTrigger _dialogTrigger;

        private Animator _animator;
        private int _nextPoint = 1;
        private bool _notBehindWall;
        private IEnumerator _ien;

        public bool NotBehindWall { get => _notBehindWall; }

        private void Start()
        {
            _animator = GetComponent<Animator>();

            gameObject.transform.localPosition = _movePoints[0].transform.localPosition;

            _ien = GoToNextPoint();

            StartCoroutine(_ien);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("WallInJail"))
            {
                _dialogTrigger.Enabled = true;
                _notBehindWall = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("WallInJail"))
            {
                _dialogTrigger.Enabled = false;
                _notBehindWall = false;
            }
        }

        public void DisableTrigger()
        {
            _dialogTrigger.gameObject.SetActive(false);
        }
        public void StartMove()
        {
            _animator.SetBool("IsWalking", true);
            StartCoroutine(_ien);
        }

        public void StopMove()
        {
            _animator.SetBool("IsWalking", false);
            StopCoroutine(_ien);
        }


        private IEnumerator GoToNextPoint()
        {
            _animator.SetBool("IsWalking", true);

            while (Vector2.Distance(gameObject.transform.localPosition, _movePoints[_nextPoint].transform.localPosition) > 0)
            {
                gameObject.transform.localPosition = Vector2.MoveTowards(gameObject.transform.localPosition, _movePoints[_nextPoint].transform.localPosition, _moveSpeed * Time.deltaTime);
                yield return null;
            }

            _animator.SetBool("IsWalking", false);

            yield return new WaitForSeconds(10f);

            gameObject.transform.localRotation = _nextPoint == 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);

            _nextPoint = _nextPoint == 0 ? 1 : 0;

            _ien = GoToNextPoint();
            StartCoroutine(_ien);
        }

        public void DostatMech()
        {
            _animator.Play("BeretMech", -1, 0f);
        }
    }
}
