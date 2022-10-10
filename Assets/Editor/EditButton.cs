using UnityEditor;
using UnityEngine;

public interface IEdit{
    void Do();
}


[CustomEditor(typeof(BlockCore),true)] // 拡張するクラスを指定
public class EditButton : Editor {
  public override void OnInspectorGUI()
  {
      // 元のインスペクター部分を表示
      base.OnInspectorGUI();

      // targetを変換して対象を取得
      BlockCore block = target as BlockCore;

      // publicなメソッドを実行するボタン
      if (GUILayout.Button("リロード!"))
      {
        block.Do();
      }
  }
}