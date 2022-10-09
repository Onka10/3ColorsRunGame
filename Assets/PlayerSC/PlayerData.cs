using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/PlayerStates")]
public class PlayerData : ScriptableObject
{

    [SerializeField]public float jumpPower=1000;
    [SerializeField] public float speed = 10f;

}
