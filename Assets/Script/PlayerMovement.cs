using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    #region Public Fields
    public SPlayerMovementTweak[] playerTweak = null;

    public float playerSpeed = 5;

    private Transform _transform = null;
    #endregion

    #region Private Fields
    private EPlayerMovement _currentPlayerMovement = EPlayerMovement.RUNNING;
    private float _currentSpeed = 0;

    [SyncVar]
    private bool _canMove = true;

    private Rigidbody _rigidBody = null;
    #endregion

    #region Unity Methods
    void Start()
    {
        _transform = transform;
        _rigidBody = _transform.GetComponent<Rigidbody>();
        ChangeSpeed();
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer && !localPlayerAuthority) return;

        if (isServer && !Data.DEBUG) return;

        if (!_canMove) return;

        if (Input.GetKey(Data.forwardKeycode))
        {
            _rigidBody.MovePosition(_rigidBody.position + _transform.forward * playerSpeed * _currentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(Data.backwardKeycode))
        {
            _rigidBody.MovePosition(_rigidBody.position - _transform.forward * playerSpeed * _currentSpeed * Time.deltaTime);
        }

        if (Input.GetKey(Data.rightKeycode))
        {
            _rigidBody.MovePosition(_rigidBody.position - _transform.right * playerSpeed * _currentSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(Data.leftKeycode))
        {
            _rigidBody.MovePosition(_rigidBody.position + _transform.right * playerSpeed * _currentSpeed * Time.deltaTime);
        }
    }

    //call on server
    public void SetCanMove(bool newState)
    {
        _canMove = newState;
    }

    [ClientRpc]
    public void RpcForcePosition(Vector3 newPos)
    {
        if (isLocalPlayer || localPlayerAuthority)
        {
            _rigidBody.MovePosition(newPos);
        }
    }

    //call on client
    public void ForcePosition(Vector3 newPos)
    {
        _rigidBody.MovePosition(newPos);
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    //call on client
    private void ChangeSpeed()
    {
        for (int i = 0; i < playerTweak.Length; i++)
        {
            if (playerTweak[i].movement == _currentPlayerMovement)
            {
                _currentSpeed = playerTweak[i].speed;
                return;
            }
        }
    }
    #endregion
}
