using UnityEngine;
using Mirror;
using System.Collections.Generic;
using System;

/*
	Documentation: https://mirror-networking.com/docs/Guides/NetworkBehaviour.html
	API Reference: https://mirror-networking.com/docs/api/Mirror.NetworkBehaviour.html
*/

public class ClientMan : NetworkBehaviour
{
    #region ============================ Start & Stop Callbacks

    /// <summary>
    /// This is invoked for NetworkBehaviour objects when they become active on the server.
    /// <para>This could be triggered by NetworkServer.Listen() for objects in the scene, or by NetworkServer.Spawn() for objects that are dynamically created.</para>
    /// <para>This will be called for objects on a "host" as well as for object on a dedicated server.</para>
    /// </summary>
    public override void OnStartServer() { }

    /// <summary>
    /// Invoked on the server when the object is unspawned
    /// <para>Useful for saving object data in persistent storage</para>
    /// </summary>
    public override void OnStopServer() { }

    /// <summary>
    /// Called on every NetworkBehaviour when it is activated on a client.
    /// <para>Objects on the host have this function called, as there is a local client on the host. The values of SyncVars on object are guaranteed to be initialized correctly with the latest state from the server when this function is called on the client.</para>
    /// </summary>
    public override void OnStartClient() {
        EventClientEmbStart?.Invoke( base.connectionToClient );
    }

    /// <summary>
    /// This is invoked on clients when the server has caused this object to be destroyed.
    /// <para>This can be used as a hook to invoke effects or do client specific cleanup.</para>
    /// </summary>
    public override void OnStopClient() {
        EventClientEmbStop?.Invoke( base.connectionToClient );
    }

    /// <summary>
    /// Called when the local player object has been set up.
    /// <para>This happens after OnStartClient(), as it is triggered by an ownership message from the server. This is an appropriate place to activate components or functionality that should only be active for the local player, such as cameras and input.</para>
    /// </summary>
    public override void OnStartLocalPlayer() { }

    /// <summary>
    /// This is invoked on behaviours that have authority, based on context and <see cref="NetworkIdentity.hasAuthority">NetworkIdentity.hasAuthority</see>.
    /// <para>This is called after <see cref="OnStartServer">OnStartServer</see> and before <see cref="OnStartClient">OnStartClient.</see></para>
    /// <para>When <see cref="NetworkIdentity.AssignClientAuthority">AssignClientAuthority</see> is called on the server, this will be called on the client that owns the object. When an object is spawned with <see cref="NetworkServer.Spawn">NetworkServer.Spawn</see> with a NetworkConnection parameter included, this will be called on the client that owns the object.</para>
    /// </summary>
    public override void OnStartAuthority() 
    {
        _kclientman = this;
        base.OnStartAuthority();
    }

    /// <summary>
    /// This is invoked on behaviours when authority is removed.
    /// <para>When NetworkIdentity.RemoveClientAuthority is called on the server, this will be called on the client that owns the object.</para>
    /// </summary>
    public override void OnStopAuthority() { }

    #endregion


    public static Action<NetworkConnection> EventClientManActive;

    #region ============================== CLIENT MAN VARIABLE - FUNCTION

    public static  ClientMan _kclientman = null;
    public static System.Action<NetworkConnection> EventClientEmbStart;
    public static System.Action<NetworkConnection> EventClientEmbStop;

    public static  ClientMan ReturnClientManIns(NetworkConnection conn = null)
    {
        if (NetworkServer.active && conn != null)
        {
            GameObject cligo = null;
            if (KnetMan.clientlist.TryGetValue( conn, out cligo ))
            {
                Debug.Log( $" --- Return CLIENT EMB from SERVER GAMEOBJECT" );
                return ( cligo.GetComponent<ClientMan>() );
            }
            else
                return null;
        }
        else
        {
            return _kclientman;
        }
    }


    //                                                          ----------===============------------------

    public void Cli_CreateRoom()
    {
        CmdCreateRoom();
        
    }

    [Command]
    private void CmdCreateRoom() // passin nothing will auto send the network connection on server, server keep track of who command him
    {
        H.klog3( $"Sever received request to create room , conn {connectionToClient}" );
        foreach(KeyValuePair<NetworkConnection, GameObject> ele in KnetMan.clientlist)
        {
            H.klog1( $"{ele.Key} --- {ele.Value}" );
        }
        string genid = H.GenerateIds();
        H.klog1($"returnning service {genid}");
    }


    #endregion




    #region ==============================  Unity Callbacks

    /// <summary>
    ///----------------- Set Singleton
    /// </summary>
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    #endregion
}
