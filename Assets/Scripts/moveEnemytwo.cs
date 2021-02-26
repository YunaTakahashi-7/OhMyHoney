using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveEnemytwo : MonoBehaviour
{
    private MoveEnemy moveEnemy;
    // Start is called before the first frame update
    void Start()
    {
        moveEnemy = GetComponentInParent<MoveEnemy>();
    }

    void OnTriggerStay(Collider col)
    {
        //　プレイヤーキャラクターを発見
        if (col.tag == "Player")
        {
            //　敵キャラクターの状態を取得
            MoveEnemy.EnemyState state = moveEnemy.GetState();
            //　敵キャラクターが追いかける状態でなければ追いかける設定に変更
            if (state != MoveEnemy.EnemyState.Chase)
            {
                Debug.Log("プレイヤー発見");
                moveEnemy.SetState(MoveEnemy.EnemyState.Chase, col.transform);
            }
        }
    }
}
