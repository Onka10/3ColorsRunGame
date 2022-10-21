using UnityEngine;

public static class ZKeep
{
    /**  
    <summary>
    Z軸を強制的に0にする
    </summary>
    */
    public static void Z0(GameObject obj){
        Vector3 pos = obj.transform.position;
        pos.z = 0;
        obj.transform.position = pos; 
    }

    public static void ZBack(GameObject obj){
        Vector3 pos = obj.transform.position;
        pos.z = 5;
        obj.transform.position = pos; 
    }
}
