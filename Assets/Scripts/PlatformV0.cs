using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformV0 : MonoBehaviour
{
    private Vector3 _target;//, _direction;

    private float _translationSpeed = 0.05f;

    private float _xMovementLimit = 6f, _yMovementLimit = 3.5f;
    private float[][] _waypoints;

    //private float _prevTime, _invertInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _waypoints = new float[][] {
        new float[]{ _xMovementLimit,  _yMovementLimit},   //quad 1
        new float[]{ -_xMovementLimit, _yMovementLimit},   //quad 2
        new float[]{ -_xMovementLimit, -_yMovementLimit},  //quad 3
        new float[]{ _xMovementLimit, -_yMovementLimit}   //quad 4
        };
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //_prevTime = Time.time;
        float x = transform.position.x, y = transform.position.y;
        /*//If quad 1 - go left
        //if quad 2 - go down
        //if quad 3 - go right
        //if quad 4 - go up
        if (x == _xMovementLimit && y == _yMovementLimit) //in quad 1
        {
            _direction = Vector3.left;
        }
        else if (x == -_xMovementLimit && y == _yMovementLimit) //in quad 2
        {
            _direction = Vector3.down;
        }
        else if (x == -_xMovementLimit && y == -_yMovementLimit) //in quad 3
        {
            _direction = Vector3.right;
        }
        else if (x == _xMovementLimit && y == -_yMovementLimit) //in quad 4
        {
            _direction = Vector3.up;
        }

        *//*if ((_prevTime + _invertInterval) < Time.time)
        {
            _direction *= -1;
            _prevTime = Time.time;
        }*/

        /*transform.Translate(_direction * _translationSpeed);*/

        /*if (x == _xMovementLimit && y == _yMovementLimit) //in quad 1
        {
            _target.Set(-_xMovementLimit, _yMovementLimit, 0f);
        }
        else if (x == -_xMovementLimit && y == _yMovementLimit) //in quad 2
        {
            _target.Set(-_xMovementLimit, -_xMovementLimit, 0f);
        }
        else if (x == -_xMovementLimit && y == -_yMovementLimit) //in quad 3
        {
            _target.Set(_xMovementLimit, -_yMovementLimit, 0f);
        }
        else if (x == _xMovementLimit && y == -_yMovementLimit) //in quad 4
        {
            _target.Set(_xMovementLimit, _yMovementLimit, 0f);
        }*/

        for(int i = 0; i < _waypoints.Length; i++)
        {
            if(x == _waypoints[i][0] && y == _waypoints[i][1])
            {
                _target.Set(_waypoints[(i+1) % _waypoints.Length][0], _waypoints[(i+1) % _waypoints.Length][1], 0f);
                break;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, _target, _translationSpeed);
    }

    //move player with platform (on trigger enter and exit)
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

}
