using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour 
{
    #region Public Fields
    [SyncVar]
    public string playerName = "UNKNOWN";
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        GameManager.GetInstance().localPlayerNetwork = this;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
