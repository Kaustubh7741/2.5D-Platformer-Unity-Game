using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    private Player _player;

/*    private Vector3 _direction;

    private float _translationSpeed = 0.01f;

    private float _lowerXMovementLimit, _higherXMovementLimit, _lowerYMovementLimit, _higherYMovementLimit;
*/
    // Start is called before the first frame update
    /*void Start()
    {
        _direction = new Vector3();

        _lowerXMovementLimit = Mathf.Abs(transform.position.x);
        _higherXMovementLimit = 6f;
        _lowerYMovementLimit = Mathf.Abs(transform.position.y);
        _higherYMovementLimit = 5f;
    }*/

    // Update is called once per frame
    /*void Update()
    {
        //Coin movements
        if ((Mathf.Abs(transform.position.x) <= _lowerXMovementLimit) && (Mathf.Abs(transform.position.y) <= _lowerYMovementLimit))
        {
            _direction.Set(
                _translationSpeed * Mathf.Sign(transform.position.x),
                _translationSpeed * Mathf.Sign(transform.position.y),
                0f
                );
        }
        else if ((Mathf.Abs(transform.position.x) >= _higherXMovementLimit) && (Mathf.Abs(transform.position.y) >= _higherYMovementLimit))
        {
            _direction.Set(
                -_translationSpeed * Mathf.Sign(transform.position.x),
                -_translationSpeed * Mathf.Sign(transform.position.y),
                0f
                );
        }
        transform.Translate(_direction);
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _player = other.GetComponent<Player>();
            if (_player == null)
                Debug.LogError("Player object was not instantiated in CoinCollectible class");
            _player.CoinPickUp();
            Destroy(this.gameObject);
        }
    }
}
