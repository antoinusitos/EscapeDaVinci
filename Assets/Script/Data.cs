using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerMovement
{
    RUNNING,
    WALKING,
    CROUCH,
}

[System.Serializable]
public struct SPlayerMovementTweak
{
    public EPlayerMovement movement;
    public float speed;
}

public static class Data 
{
    #region Public Fields
    public static bool DEBUG = true;
           
    public static KeyCode forwardKeycode = KeyCode.Z;
    public static KeyCode backwardKeycode = KeyCode.S;
    public static KeyCode rightKeycode = KeyCode.Q;
    public static KeyCode leftKeycode = KeyCode.D;
    public static KeyCode fireKeycode = KeyCode.Mouse0;
    public static KeyCode reload = KeyCode.R;
    public static KeyCode leanLeft = KeyCode.A;
    public static KeyCode leanRight = KeyCode.E;
    public static KeyCode action = KeyCode.F;
    public static KeyCode jump = KeyCode.Space;
    public static KeyCode menu = KeyCode.Escape;
    public static KeyCode validate = KeyCode.Return;
    #endregion

    #region Private Fields
    #endregion

    #region Unity Methods
    #endregion
 
	#region Public Methods
    #endregion

    #region Private Methods
    #endregion
}
