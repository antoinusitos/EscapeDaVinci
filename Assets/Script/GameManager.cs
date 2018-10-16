using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour 
{
    #region Public Fields
    private Player[] _allPlayers = null;

    public int playersToStart = 1;
    public int maxPlayers = 2;
    [SyncVar]
    protected int _currentNumberPlayer = 0;

    public Player localPlayer = null; //only client side.
    public PlayerNetwork localPlayerNetwork = null; //only client side.
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    void Start()
    {
    }
 
    void Update()
    {
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion

    //------------------------------------------------------------------------------------

    protected static GameManager _instance = null;
    public static GameManager GetInstance()
    {
        return _instance;
    }

    protected void Awake()
    {
        _instance = this;
    }
}
