using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWayPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    private Rigidbody _rb;


    //private int _currentWayPoint = 0;

    private Vector3 _currentDestination;

    private void Awake()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        if (_wayPoints != null && _wayPoints.Length > 0)
        {
            _currentDestination = _wayPoints[0].position;
        }
    }


    private void Update()
    {

    }


    /*
    private void Movement()
    {
        if (_wayPoints == null || _wayPoints.Length == 0)
        {
            _rb.velocity = Vector2.zero;
            return;
        }

        MoveWayPoint(_currentDestination);

        float distancePoint = Vector2.Distance(transform.position, _currentDestination);

        if (distancePoint < _stopDistance)
        {
            _currentWayPoint++;
            if (_currentWayPoint >= _wayPoints.Length)
            {
                _currentWayPoint = 0;
            }
            _currentDestination = _wayPoints[_currentWayPoint].position;
        }
    }
    */



}
