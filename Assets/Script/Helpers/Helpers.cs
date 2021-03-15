using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace KHELPERS
{
    public static class Helpers
    {
        public static string GetRandomeIds()
        {
            string res = "";
            for (int i = 0; i < 5; i++)
            {
                res += (Random.Range(0, 255)).ToString();
            }
            return res;
        }
    }


} // END OF KHELPERS