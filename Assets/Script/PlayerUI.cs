using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour 
{
    #region Public Fields
    public GameObject canvasPlayer = null;
    #endregion

	#region Private Fields
    #endregion
 
    #region Unity Methods
    #endregion
 
	#region Public Methods
    //call on client
    public void ActivateCanvasPlayer(bool newState)
    {
        canvasPlayer.SetActive(newState);
    }
    #endregion

    #region Private Methods
    #endregion
}
