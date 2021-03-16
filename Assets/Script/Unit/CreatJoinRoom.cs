using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.UI;

public class CreatJoinRoom : NetworkBehaviour
{

    [SerializeField]
    private Button createButt = null;

    [SerializeField]
    private Button joinButt = null;

    private void OnEnable()
    {
        ClientEmb.EventClientEmbSpawned += CreateRoomRespEventClientSpawed;
    }

    private void OnDisable()
    {
        ClientEmb.EventClientEmbSpawned -= CreateRoomRespEventClientSpawed;
    }
    private void CreateRoomRespEventClientSpawed(bool obj)
    {
        Debug.Log("createroom Get event client emb spawned");
        if(obj)
        {
            if(base.hasAuthority)
            {
                createButt.interactable = true;
            }
        }
    }

    private void Awake()
    {
        createButt.interactable = false;
        joinButt.interactable = false;
    }

    private void Start()
    {
        
    }
}
