using UnityEngine;
using UnityEditor;

public class EditorWindowSample : EditorWindow
{
    /// <summary>
    /// アセットパス
    /// </summary>
    private const string ASSET_PATH = "Assets/Stage/BlockObject.prefab";

    [MenuItem("Test/LevelDesignEdit")]
    private static void Create()
    {
        // 生成
        GetWindow<EditorWindowSample>("LevelDesignEdit");
    }

    private void OnGUI()
    {
        using (new GUILayout.HorizontalScope())
        {
            // 書き込みボタン
            if (GUILayout.Button("生成"))
            {
                Export();
            }
        }
    }

    private void Export()
    {
        // // 新規の場合は作成
        // if (!AssetDatabase.Contains(_sample as UnityEngine.Object))
        // {
        //     string directory = Path.GetDirectoryName(ASSET_PATH);
        //     if (!Directory.Exists(directory))
        //     {
        //         Directory.CreateDirectory(directory);
        //     }
        //     // アセット作成
        //     AssetDatabase.CreateAsset(_sample, ASSET_PATH);
        // }
        // // インスペクターから設定できないようにする
        // _sample.hideFlags = HideFlags.NotEditable;
        // // 更新通知
        // EditorUtility.SetDirty(_sample);
        // // 保存
        // AssetDatabase.SaveAssets();
        // // エディタを最新の状態にする
        // AssetDatabase.Refresh();
    }
}