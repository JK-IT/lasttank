using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class testscript : MonoBehaviour
{

    NetworkManager netman;

    public void CreateRoomUI()
    {

    }




    private void Awake()
    {
        netman = GameObject.Find( "KnetManager" ).GetComponent<NetworkManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( "Ima here" );
        
    }

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
