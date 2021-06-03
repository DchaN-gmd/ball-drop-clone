using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;
    [SerializeField] private float _delayToDestroy;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach(var segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius, _delayToDestroy);
        }
    }
}
