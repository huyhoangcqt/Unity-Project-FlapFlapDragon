using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math : Singleton<Math>
{
    public static float Max(float a, float b){
        if (a > b) {
            return a;
        }
        else 
            return b;
    }
}
