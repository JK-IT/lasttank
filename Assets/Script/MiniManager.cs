using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using Unity;
using UnityEngine.UI;
using UnityEngine.UIElements;

/**
 * TRY TO CONNECT TO SERVER
 * IF NOT SUCCESSFUL, THEN START LOCAL HOST SCREEN OPTION
 * 
 */

public class MiniManager : MonoBehaviour
{
    #region SERIALIZE FIELD
    [SerializeField]
    private GameObject k_netobject = null;
    [SerializeField]
    private UnityEngine.UI.Button hostbutton = null;
    [SerializeField]
    private GameObject hostjoinCanvas = null;
    [SerializeField]
    private GameObject roomlobbyCanvas = null;
    
    #endregion

    #region PUBLIC CALL FOR UI
    /// <summary>
    /// Function to start the server in offline mode
    /// </summary>
    public void StartLocalHost()
    {
        k_netManager.StartHost();
        hostbutton.interactable = false;
    }

    #endregion

    #region VARIABLE
    private KnetManager k_netManager = null;
    #endregion


    #region HANDLING EVENT
    private void WaitforServerHostStarted(bool started)
    {
        if(started)
        {
            Debug.Log("mini wait for server started success");
            hostjoinCanvas.SetActive(false);
            roomlobbyCanvas.SetActive(true);
            
        }else
        {
            Debug.Log("mini failed to wait for server started");
        }
    }
    #endregion

    #region START AND STOP----------------
    /// <summary>
    /// SUBCRIBE TO SERVER STARTED EVENT
    /// </summary>
    private void OnEnable()
    {
        KnetManager.OnServerHostStarted += WaitforServerHostStarted;
    }

    private void OnDisable()
    {
        KnetManager.OnServerHostStarted -= WaitforServerHostStarted;
    }


    /// <summary>
    /// Try to connect to server, if failed then show the local hosting option
    /// </summary>
    private void Awake()
    {
        k_netManager = k_netobject.GetComponent<KnetManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
