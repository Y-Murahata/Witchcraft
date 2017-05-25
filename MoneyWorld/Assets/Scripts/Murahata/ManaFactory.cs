using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;     
#endif

public class ManaFactory : MonoBehaviour {

    public enum ATTRIBUTION:int
    {
        NONE,
        FIRE,
        ICE,
        THUNDER
    }

    public ATTRIBUTION attribution = (int)ATTRIBUTION.NONE;

    // Use this for initialization
    void Start () {
        ChengeMaterialColor();
    }
	
	// Update is called once per frame
	void Update () {

       
    }

    //  モデルの色を変える関数
    void ChengeMaterialColor()
    {
        //  プレハブの弾丸を作成する
        GameObject effect;

        //  現在の属性の色を取得
        switch ((int)attribution)
        {
            case (int)ATTRIBUTION.NONE:
                break;
            case (int)ATTRIBUTION.FIRE:
                effect = GameObject.Instantiate((GameObject)Resources.Load("ManaEffectRed"));
                effect.transform.parent = gameObject.transform;
                effect.transform.position = gameObject.transform.position;
                break;
            case (int)ATTRIBUTION.ICE:
                effect = GameObject.Instantiate((GameObject)Resources.Load("ManaEffectBlue"));
                effect.transform.parent = gameObject.transform;
                effect.transform.position = gameObject.transform.position;
                break;
            case (int)ATTRIBUTION.THUNDER:
                effect = GameObject.Instantiate((GameObject)Resources.Load("ManaEffectYellow"));
                effect.transform.parent = gameObject.transform;
                effect.transform.position = gameObject.transform.position;
                break;
        }
        

        


    }

    /* ---- ここから拡張コード ---- */
#if UNITY_EDITOR
    /**
     * Inspector拡張クラス
     */
    [CustomEditor(typeof(ManaFactory))]               
    public class CharacterEditor : Editor
    {
        bool folding = false;

        public override void OnInspectorGUI()
        {
            ManaFactory unit = target as ManaFactory;

            /* -- カスタム表示 -- */

            //  属性
            unit.attribution = (ATTRIBUTION)EditorGUILayout.EnumPopup("属性", unit.attribution);

        }
    }
#endif



}

