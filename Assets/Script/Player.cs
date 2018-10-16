using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{
    #region Public Fields
    #endregion

    #region Private Fields
    private PlayerAction _playerAction = null;
    private PlayerCamera _playerCamera = null;
    private PlayerMovement _playerMovement = null;
    private PlayerNetwork _playerNetwork = null;
    private PlayerUI _playerUI = null;

    private bool _init = false;
    #endregion

    #region Unity Methods
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Init();

        _playerUI.ActivateCanvasPlayer(true);
        GameManager.GetInstance().localPlayer = this;
    }

    private void Start()
    {
        Init();
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Init()
    {
        if (_init) return;
        _init = true;

        _playerAction = GetComponent<PlayerAction>();
        _playerCamera = GetComponent<PlayerCamera>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerNetwork = GetComponent<PlayerNetwork>();
        _playerUI = GetComponent<PlayerUI>();
    }
    #endregion
}
