using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ClientEmb : NetworkBehaviour
{


    public static ClientEmb Instance;
    public static System.Action<bool> EventClientEmbSpawned;



    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        Instance = this;
        Debug.Log("This is local player");
        EventClientEmbSpawned?.Invoke(true);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
    }

    

    public static ClientEmb ReturnClientEmb(NetworkConnection conn = null)
    {
        if(NetworkServer.active && NetworkClient.active && conn != null)
        {
            NetworkIdentity localclient;
            if (KnetManager.clientEmbDic.TryGetValue(conn, out localclient))
            {
                return localclient.GetComponent<ClientEmb>();
            }
            else
                return null;
        } else
        {
            return Instance;
        }
    }

    private void Start()
    {
        Debug.Log("is server " + base.isServer);
        Debug.Log("is client " + base.isClient);
        Debug.Log("has authority " + base.hasAuthority);
        Debug.Log("network identity connection to client " + this.GetComponentInParent<NetworkIdentity>().connectionToClient);
        Debug.Log("base connection to client " + base.connectionToClient);
    }
}
