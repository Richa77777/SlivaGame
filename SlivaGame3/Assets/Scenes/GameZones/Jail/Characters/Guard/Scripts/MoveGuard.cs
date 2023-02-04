using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jail
{
    public class MoveGuard : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 0f;

        [SerializeField] private GameObject[] _movePoints = new GameObject[2];

        private Animator _animator;

        private int _nextPoint = 1;

        private bool _notBehindWall;

        public bool NotBehindWall { get => _notBehindWall; }

        private void Start()
        {
            _animator = GetComponent<Animator>();

            gameObject.transform.localPosition = _movePoints[0].transform.localPosition;

            StartCoroutine(GoToNextPoint());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("WallInJail"))
            {
                _notBehindWall = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("WallInJail"))
            {
                _notBehindWall = false;
            }
        }

        public void StartMove()
        {
            StartCoroutine(GoToNextPoint());
        }

        public void StopMove()
        {
            _animator.SetBool("IsWalking", false);
            StopCoroutine(GoToNextPoint());
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

            StartCoroutine(GoToNextPoint());
        }
    }
}
