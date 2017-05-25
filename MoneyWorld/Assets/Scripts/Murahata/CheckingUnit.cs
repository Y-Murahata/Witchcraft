//=======================================
//  CheckingUnit
//  親に自分と当たっているユニットの属性を返す
//
//=======================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingUnit : MonoBehaviour {

    //  親オブジェクト
    GameObject parent;
    //  親のどちらに設置されているか
    bool isRight;

    //  範囲内に入ってるオブジェクトの属性を取得する

	// Use this for initialization
	void Start () {
        //  親を取得する
        parent = transform.parent.gameObject;

        if (transform.localPosition.x >= 0)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
              
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //  接触しているオブジェクトを取得する
    private void OnCollisionStay(Collision collision)
    {
        GameObject unitChild =  collision.gameObject;

        Debug.Log(transform.name.ToString() + "がオブジェクトを発見");

        //  そのオブジェクトがマナファクトリータイプだったら
        if (unitChild.tag == "ManaFactory")
        {
            if (isRight)
            {
                parent.GetComponent<Turret>().attribution[0] = (int)unitChild.GetComponent<ManaFactory>().attribution;
            }
            else
            {
                parent.GetComponent<Turret>().attribution[1] = (int)unitChild.GetComponent<ManaFactory>().attribution;
            }

        }
    }

    //  接触していなかったら属性値を初期化する
    private void OnCollisionExit(Collision collision)
    {
        if (isRight)
        {
            parent.GetComponent<Turret>().attribution[0] = 0;
        }
        else
        {
            parent.GetComponent<Turret>().attribution[1] = 0;
        }
    }
}
