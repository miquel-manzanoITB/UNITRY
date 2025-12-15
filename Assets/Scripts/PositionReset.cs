using System;
using UnityEngine;

public class PositionReset : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    private void Awake()
    {
        _position = transform.position;
        _rotation = transform.rotation;
    }

    private void OnEnable()
    {
        transform.position = _position;
        transform.rotation = _rotation;
    }
}
