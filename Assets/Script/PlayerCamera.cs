using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerCamera : NetworkBehaviour 
{
    #region Public Fields
    public Transform cameraPlayer = null;
    #endregion

    #region Private Fields
    private float verticalSpeed = 50.0f;
    private float horizontalSpeed = 150.0f;

    private float _currentAngle = 0;

    private Transform _transform = null;
    #endregion

    #region Unity Methods
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        cameraPlayer.gameObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);
    }

    void Start()
    {
        _transform = transform;
    }
 
    void Update()
    {
        if (!isLocalPlayer && !hasAuthority) return;

        if (isServer && !Data.DEBUG) return;

        float x = Input.GetAxis("Mouse X") * Time.deltaTime * horizontalSpeed;
        float z = Input.GetAxis("Mouse Y") * Time.deltaTime * verticalSpeed;
        if (z > 0 && _currentAngle < 89)
            _currentAngle += z;
        else if (z < 0 && _currentAngle > -89)
            _currentAngle += z;
        if (_currentAngle > 89) _currentAngle = 89;
        else if (_currentAngle < -89) _currentAngle = -89;

        cameraPlayer.rotation = Quaternion.Euler(-_currentAngle, 0, 0);

        _transform.Rotate(0, x, 0);
    }
    #endregion

    #region Public Methods
    //call on client
    public void SetCursorLocked(bool newState)
    {
        if (newState)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
    #endregion

    #region Private Methods
    #endregion
}
