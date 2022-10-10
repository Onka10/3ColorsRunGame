using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/BlockMaterials")]
public class BlockMaterial : ScriptableObject
{
    public Materials Red => _red;
    [SerializeField] private Materials _red;
    [SerializeField] public Materials Green;
    [SerializeField] public Materials Blue;

}


[System.Serializable]
public struct Materials
{

    [SerializeField] public Material On;
    [SerializeField] public Material Off;
}