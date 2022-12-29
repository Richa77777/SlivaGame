using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class PlayerCameraMove : MonoBehaviour
    {
        private Camera _camera;

        [SerializeField] private GameObject _target;

        [Range(0.0f, 10.0f)]
        [SerializeField] private float _cameraSpeed;


        private void Start()
        {
            _camera = Camera.main;
            _camera.transform.localPosition = new Vector3(_target.transform.localPosition.x, _target.transform.localPosition.y, -10);
        }

        private void Update()
        {
            CameraMove();
        }


        private void CameraMove()
        {
            Vector3 targetPos = new Vector3(_target.transform.localPosition.x, _target.transform.localPosition.y, -10);
            _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, targetPos, _cameraSpeed * Time.deltaTime);
        }
    }
}

