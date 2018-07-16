using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;
    // Use this for initialization

    private const float MAX_POS = 3f;

    // Update is called once per frame
    void Update()
    {
        float positionY = gameObject.transform.position.y;
        float positionZ = gameObject.transform.position.z;
        // Vector3でマウス位置座標を取得する
        position.x = Input.mousePosition.x;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = new Vector3(screenToWorldPointPosition.x, positionY, positionZ);

        if (transform.position.x >= MAX_POS)
        {
            transform.position = new Vector3(MAX_POS, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= MAX_POS * -1)
        {
            transform.position = new Vector3(MAX_POS * -1, transform.position.y, transform.position.z);
        }
    }
}