using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    const string spritePath = "Prefabs/Sprite";
    const string modelPath = "Prefabs/Model";
    List<GameObject> spriteList = new List<GameObject>(); //Sprite表示用Objectのリスト
    List<GameObject> modelList = new List<GameObject>();
    List<Object> sprites = new List<Object>(); //SpriteObjectのリストコピー
    List<Object> models = new List<Object>();

    List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    public void OnUpdate()
    {
        sprites = SpriteList.GetList();
        models = ModelList.GetList();

        while (spriteList.Count != sprites.Count) //リストの長さを揃える
        {
            int n = spriteList.Count;
            if (spriteList.Count > sprites.Count)
            {
                Destroy(spriteList[n]);
                spriteList.RemoveAt(n);
                renderers.RemoveAt(n);
            }
            else if (spriteList.Count < sprites.Count)
            {
                spriteList.Add(null);
                renderers.Add(null);
            }
            n--;
        }

        for (int i = 0; i < sprites.Count; i++) //Spriteの状態を反映させる
        {
            if (spriteList[i] == null) //Objectが無い場合、空のObjectを生成
            {
                spriteList[i] = (GameObject)Instantiate(Resources.Load(spritePath));
                renderers[i] = spriteList[i].GetComponent<SpriteRenderer>();
            }
            renderers[i].sprite = SpriteLoader.Load(sprites[i].image);
            spriteList[i].transform.position = ConvertToVector(sprites[i].pos);
            spriteList[i].transform.rotation = Quaternion.Euler(ConvertToVector(sprites[i].rot));
            spriteList[i].transform.localScale = ConvertToVector(sprites[i].scale);

        }
    }

    Vector3 ConvertToVector(Position pos)
    {
        Vector3 vec = new Vector3();
        vec.x = pos.x;
        vec.y = pos.y;
        vec.z = pos.z;
        return vec;
    }
}