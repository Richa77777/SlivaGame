using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private bool _isStatic = false;
    [SerializeField] private float _offset = 0;

    private int _sortingOrderBase = 0;

    private Renderer _renderer;
    private SortingGroup _sortingGroup;

    private bool _isGroup;

    private void Awake()
    {
        if (transform.GetComponentInChildren<SortingGroup>())
        {
            _sortingGroup = transform.GetComponentInChildren<SortingGroup>();
            _isGroup = true;
        }

        else if (!transform.GetComponentInChildren<SortingGroup>())
        {
            _renderer = GetComponent<Renderer>();
        }
    }

    private void LateUpdate()
    {
        if (_isGroup == true)
        {
            _sortingGroup.sortingOrder = (int)(_sortingOrderBase - transform.position.y + _offset);
        }

        else if (_isGroup == false)
        {
            _renderer.sortingOrder = (int)(_sortingOrderBase - transform.position.y + _offset);
        }

        if (_isStatic == true)
        {
            Destroy(this);
        }
    }
}
