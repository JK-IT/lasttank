using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetAssit : NetworkBehaviour
{

    public static NetAssit _knetAssit = null;

    


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log( "NetAssit is running" );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
