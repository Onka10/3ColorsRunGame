using UnityEngine;

namespace Section4
{
    [CreateAssetMenu(menuName = "ScriptableObject/Breed(Section4)")]
    public class PlayerAsset : ScriptableObject
    {
        /// <summary>
        /// 親系統
        /// </summary>
        [SerializeField] private PlayerAsset _Parent = null;

        /// <summary>
        /// 系統名
        /// </summary>
        public string Name
        {
            get
            {
                // UnityEngine.Objectクラスを継承したものは != null 不要
                if (_Parent)
                {
                    // ここで「Name」を取得しているので
                    // "親系統が更に親系統を持っていても" 最終的な親から系統名を取得できる
                    // 再帰処理
                    return _Parent.Name;
                }
                return _Name;
            }
        }
        [SerializeField] private string _Name = "";

        /// <summary>
        /// 攻撃メッセージ
        /// </summary>
        public string AttackMessage
        {
            get
            {
                if (_OverrideAttackMessage || !_Parent)
                {
                    return _AttackMessage;
                }
                return _Parent.AttackMessage;
            }
        }
        [SerializeField] private bool _OverrideAttackMessage = false;
        [SerializeField] private string _AttackMessage = "";


#if UNITY_EDITOR

#endif
    }
}