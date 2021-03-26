using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static  class H
{
    private static readonly System.Random _ran = new System.Random();

    public static void klog1( string ins )
    {
        Debug.Log( $"=========>>>>>>>>  {ins}  ::  <<<<<<<============== {DateTime.Now.ToString( "HH:mm" )} == {DateTime.Now.Millisecond}" );
    }

    public static void klog2( string ins,  string name = "" )
    {
        Debug.Log( $"--------------++++++++ <b> {name} </b>:::: {ins}   ++++++++-----------------{DateTime.Now.ToString("HH:mm")} == {DateTime.Now.Millisecond}" );
    }

    public static void klog3( string ins, string color = "teal", string name = "noname" )
    {
        Debug.Log( $"<color={color}>======  <b>{name}</b> :::::  {ins} =========</color>{DateTime.Now.ToString( "HH:mm" )} == {DateTime.Now.Millisecond}" );
    }

    public static string GenerateIds()
    {
        string res = "";
        char up = 'A';
        char low = 'a';
        for (int i = 0; i < 2; i++)
        {
            res += ((char)_ran.Next( low, low + 26 )).ToString();
        }
        res += ((char) _ran.Next( 33, 38 ) ).ToString();
        for(int i = 0; i < 2; i++)
        {
            res += ((char) _ran.Next( 48, 57 ) ).ToString();
        }
        res += ((char) _ran.Next( up, up + 26 ) ).ToString();
        return res;
    }

    
}

