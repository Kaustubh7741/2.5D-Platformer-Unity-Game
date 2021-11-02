using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Globals
    private float _gravity = 1f;
    private float _yBound = 7f;//, xBound = 10f;

    private CharacterController _playerController;

    //[SerializeField]
    private float   _playerSpeed = 8.5f,
                    _playerJumpHeight = 15f,
                    _yVelocity = 0f;
    private bool _canDoubleJump = false;
    private int _coinCount = 0;

    private Vector3 _playerDirection, _playerVelocity;

    private UIManager _uiManager;

    private GameObject _playerSpawn;        //to set position for player respawn

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<CharacterController>();
        if (_playerController == null)
            Debug.LogError("Player Controller not initialized in Player class");

        _playerDirection = new Vector3();
        _playerVelocity = new Vector3();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
            Debug.LogError("UI Manager was not initialised in Player class");

        _playerSpawn = GameObject.Find("Player_Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        //X-axis movements based on player controls
        _playerDirection.Set(Input.GetAxis("Horizontal"), 0f, 0f);
        _playerVelocity = _playerDirection * _playerSpeed;

        //Y-axis movements based on physics and player jump
        if(_playerController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space))
            {
                _yVelocity = _playerJumpHeight;
                _canDoubleJump = true;
            }
            else
            {
                //reset yvelocity if no activity to reset gravity
                _yVelocity = 0f;
            }

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump)
                {
                    //_yVelocity += _playerJumpHeight;
                    //to reset the gravity, assign the jump height instead of adding
                    _yVelocity = _playerJumpHeight;

                    _canDoubleJump = false;
                }
            }
            _yVelocity -= _gravity;
        }
        _playerVelocity.y = _yVelocity;

        _playerController.Move(_playerVelocity * Time.deltaTime);

        if (transform.position.y < -_yBound)
            DeletePlayerLife();

    }

    public void pickUpCoin()
    {
        //_uiManager.UpdateCoinCount(++_coinCount);
        _coinCount++;
        _uiManager.UpdateCoinCount(_coinCount);
    }

    void DeletePlayerLife()
    {
        transform.position = _playerSpawn.transform.position + (Vector3.up * 1.5f);
        _yVelocity = 0f;
    }

}
