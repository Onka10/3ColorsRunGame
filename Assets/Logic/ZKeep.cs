using UnityEngine;

public static class ZKeep
{
    public static void Z(GameObject obj){
        Vector3 pos = obj.transform.position;
        pos.z = 0;
        obj.transform.position = pos; 
    }
}
