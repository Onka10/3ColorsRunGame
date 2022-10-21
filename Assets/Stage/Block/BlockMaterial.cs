using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/BlockMaterials")]
public class BlockMaterial : ScriptableObject
{
    public BlockMaterials Red => _red;
    [SerializeField] private BlockMaterials _red;
    [SerializeField] public BlockMaterials Green;
    [SerializeField] public BlockMaterials Blue;

}


[System.Serializable]
public struct BlockMaterials
{

    [SerializeField] public Material On;
    [SerializeField] public Material Off;
}