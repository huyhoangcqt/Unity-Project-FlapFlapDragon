using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private static Vector3 lastPos;


    public static Vector3 GetLastPosition(){
        return lastPos;
    }

    public static void SavedPosition(Vector3 pos){
        lastPos = pos;
        Debug.Log("Saved position: " + pos.x + ", " + pos.y + ", " + pos.z);
    }
}
