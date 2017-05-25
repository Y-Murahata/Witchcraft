﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//
//  ミサイルを発射するタレット
//  タレットを継承する
public class Missile : MonoBehaviour
{
    //  属性
    enum ATTRIBUTION
    {
        NONE,
        FIRE,
        ICE,
        THUNDER
    }

    public string EnemyTag;

    //  タレットステータス
    [SerializeField]
    private int m_hp;           //  HP
    [SerializeField]
    private float m_power;        //  攻撃力
    [SerializeField]
    public float m_range;       //  射程
    [SerializeField]
    private float coolTime;     //  クールタイム      
    private float coolTimer;    //  現在のクールタイム  
    [SerializeField]
    private float force;        //  弾に与える力

    private GameObject expEffect;
    private GameObject enemy;   //  敵

    //  タレットの左右にあるオブジェクトを取得
    public int[] attribution = new int[2];

    //====================================================================================

    // Use this for initialization
    void Start () {
        coolTimer = 0;
        expEffect = transform.FindChild("Head/Flame1").gameObject;
    }
	
    //===================================================================================
	// Update is called once per frame
	void Update () {

        //  敵を索敵する
        enemy = serchEnemy(EnemyTag);

        //  クールタイムを終えていたら
        if (coolTimer >= coolTime)
        {
            //  敵を認識できたら
            if (enemy != null)
            {
                //  射程距離内にいたら攻撃をする
                if (Vector3.Distance(transform.position, enemy.transform.position) <= m_range)
                {
                    //  攻撃する
                    Attack(enemy);
                    //  クールタイマーをリセットする
                    coolTimer = 0;
                }

            }
        }

        coolTimer += Time.deltaTime;
    }

    //============================
    //  敵に向かって攻撃
    //  敵
    //  なし
    //============================
    void Attack(GameObject enemy)
    {
        for (float i = 0; i < 3; i++)
        {
            //  敵の中心を取得
            GameObject enemyBody = enemy.transform.FindChild("Body").gameObject;

            //  プレハブの弾丸を作成する
            GameObject bullet = Instantiate((GameObject)Resources.Load("Bullet"));

            //  属性値を計算する
            bullet.GetComponent<Bullet>().SetAttribution(attribution[0], attribution[1]);

            //  弾に攻撃力を渡す
            bullet.GetComponent<Bullet>().m_power = m_power;

            //  親タレットの砲身を取得する
            GameObject barrel = transform.FindChild("Head").gameObject;

            //  敵との角度を出す
            var rad = enemyBody.transform.position - barrel.transform.position;
            var dis = rad.magnitude;
            var direction = rad / dis;

            //  バレルを敵の方向に向ける
            barrel.transform.LookAt(enemyBody.transform);

            //  座標を設定
            bullet.transform.position = new Vector3(barrel.transform.position.x, barrel.transform.position.y, barrel.transform.position.z);

            //  射程距離を渡す
            bullet.GetComponent<Bullet>().GetRange(m_range);

            //  発射する
            Sequence missileSeq = DOTween.Sequence();
            //  上に発射するアクション
            missileSeq.Append(bullet.transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 1.0f));
            //  敵の方向に飛ばすアクション
            missileSeq.Append(bullet.transform.DOMove(enemyBody.transform.position, 1.0f));
            //  弾をずらす
            missileSeq.SetDelay(i / 10);


            //  エフェクトを出す
            expEffect.GetComponent<ParticleSystem>().Play();
        }
      

    }

    // ===========================
    //  一番近い敵を取得
    //============================
    GameObject serchEnemy(string tagName)
    {
        float dis = 0;           //距離
        float nearDis = 0;          //最も近いオブジェクトの距離        
        GameObject targetObj = null; //オブジェクト

        //  指定したタグのオブジェクトをすべて取得する
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag(tagName))
        {
            //  自身と取得したオブジェクトの距離を取得
            dis = Vector3.Distance(this.transform.position, obj.transform.position);
            dis = fabsf(dis);

            //  より近いオブジェクトか、距離が０のオブジェクトなら更新
            if (nearDis > dis || nearDis == 0)
            {
                nearDis = dis;          //  距離を保存            
                targetObj = obj;        //  ターゲットを更新

            }
        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }

    //  絶対値にして返す
    public float fabsf(float i)
    {
        //  絶対値を返す
        return (i >= 0) ? i : -i;
    }
}
