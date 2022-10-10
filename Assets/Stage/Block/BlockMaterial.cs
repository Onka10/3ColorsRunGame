using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/BlockMaterials")]
public class BlockMaterial : ScriptableObject
{
    [SerializeField] public Materials Red;
    [SerializeField] public Materials Green;
    [SerializeField] public Materials Blue;

}


[System.Serializable]
public struct Materials
{

    [SerializeField] public Material On;
    [SerializeField] public Material Off;
}