using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocCreator : MonoBehaviour
{

    [SerializeField]
    Vector2 START_POS = new Vector2(0, 0);
    [SerializeField]
    Vector2 MAX_POS = new Vector2(10, 10);
    [SerializeField]
    List<int> type = new List<int>();    

    void Start()
    {
        RadomCreate();
    }

    void RadomCreate()
    {
        for (int i = (int)START_POS.x; i < MAX_POS.x; i++)
        {
            for (int k = (int)START_POS.y; k < MAX_POS.y; k++)
            {
                // ランダムでタイプ選択
                int createType = type[Random.Range(0, type.Count)];
                // プレハブを取得
                GameObject prefab = Resources.Load("Prefab/Bloc_" + createType) as GameObject;
                // プレハブからインスタンスを生成
                GameObject obj = Instantiate(prefab) as GameObject;
                obj.transform.position = new Vector3(obj.transform.localScale.x * i, obj.transform.localScale.y * k, obj.transform.position.z);
            }
        }
    }
}
