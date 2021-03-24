using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAssit : MonoBehaviour
{

    public static NetAssit _knetAssit = null;


    private void Awake()
    {
        if(_knetAssit == null)
        {
            _knetAssit = this;
        }
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
