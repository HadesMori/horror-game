using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _smoothTime;
    private Vector3 _offset = new Vector3(0, 0, -10f);
    private Vector3 _velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = _targetTransform.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }
}
