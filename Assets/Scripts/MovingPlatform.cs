using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _waypointA, _waypointB, _target;

    private float _platformMoveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (_waypointA == null || _waypointB == null)
            Debug.LogError("A waypoint was not assigned in inspector for Moving Platform");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == _waypointA.position)
            _target = _waypointB;
        else if (transform.position == _waypointB.position)
            _target = _waypointA;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _platformMoveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = this.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}
