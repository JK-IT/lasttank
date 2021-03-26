using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class UIMan : MonoBehaviour
{
    //NETWORK MANAGER
    NetworkManager netman = null;
    // CLIENT INSTANCE FOR THIS CONN
    ClientMan climan = null;

    // UI MAN INS
    public static UIMan kins = null;

    private void Awake()
    {
        netman = GameObject.Find( "KnetManager" ).GetComponent<NetworkManager>();
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( "Ima here" );
        kins = this;
    }
    // Update is called once per frame
    void Update()
    {

    }




    #region ==============================NETWORK RELATED FUNC
    public void StartServer()
    {
        netman.StartServer();
    }

    public void StopServer()
    {
        netman.StopServer();
    }

    public void StartHost()
    {
        netman.StartHost();
    }

    public void StopHost()
    {
        netman.StopHost();
    }

    public void StartClient()
    {
        netman.StartClient();
    }

    public void StopClient()
    {
        netman.StopClient();
    }

    public void Quit()
    {
        Application.Quit();
    }


    /// <summary>
    /// Create room UI
    /// --> Calling the client man who talked to server
    /// </summary>
    public void CreateRoomUI()
    {

        climan = ClientMan.ReturnClientManIns();
        if (climan != null)
        {
            climan.Cli_CreateRoom();
        }
        else
            H.klog3( "ClientMan is null- cannot create room", "red" );
    }


    #endregion
}