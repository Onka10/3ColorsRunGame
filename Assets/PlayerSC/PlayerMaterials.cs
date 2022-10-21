using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/PlayerMaterials")]
public class PlayerMaterials : ScriptableObject
{
    [SerializeField] public PlayerMaterial Red;
    [SerializeField] public PlayerMaterial Green;
    [SerializeField] public PlayerMaterial Blue;

}


[System.Serializable]
public struct PlayerMaterial
{

    [SerializeField] public Material Player;
    [SerializeField] public GameObject Death;
}