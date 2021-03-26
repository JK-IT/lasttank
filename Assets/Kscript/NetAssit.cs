using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class NetAssit : NetworkBehaviour
{

    public static NetAssit _knetAssit = null;


    #region ----------------------------------------------  EVENT SUBCRIBER-----------------------

    /**
     * 
     * ``````````````````````````````````` SUBCRIBE TO EVENT
     */
    private void OnEnable()
    {
        ClientMan.EventClientEmbStart += OkClientEmbStart;
        ClientMan.EventClientEmbStop += OkClientEmbStop;
    }

    private void OnDisable()
    {
        ClientMan.EventClientEmbStart -= OkClientEmbStart;
        ClientMan.EventClientEmbStop -= OkClientEmbStop;
        if (this.gameObject != null &&  this.gameObject.scene.name == "DontDestroyOnLoad") {
            //SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene() );
            _knetAssit = null;
            Destroy( this.gameObject );

        };
    }

    private void OkClientEmbStart(NetworkConnection conn)
    {
        H.klog2( $"Connection Emb Spawned {conn.connectionId}", this.name );
    }

    private void OkClientEmbStop(NetworkConnection conn)
    {
        H.klog2( $"Connection Emb Stop {conn.connectionId}", this.name );
    }
    #endregion







    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        
    }

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( "NetAssit is running" );
        if(_knetAssit == null)
        {
            _knetAssit = this;
            DontDestroyOnLoad( this );
        } else
        {
            Destroy( this );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
