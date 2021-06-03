using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 directionOffset;
    [SerializeField] private float _lenght;

    private Beam _beam;
    private Ball _ball;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _beam = FindObjectOfType<Beam>();
        _ball = FindObjectOfType<Ball>();

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        TrackBall();
    }

    void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + directionOffset;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);

    }
}
