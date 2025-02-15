using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    const string spritePath = "Prefabs/Sprite";
    const string modelPath = "Prefabs/Model";
    const string imagePath = "Prefabs/Image";
    const string textPath = "Prefabs/Text";
    List<GameObject> spriteList = new List<GameObject>(); //Sprite表示用Objectのリスト
    List<GameObject> modelList = new List<GameObject>();
    List<GameObject> imageList = new List<GameObject>();
    List<GameObject> textList = new List<GameObject>();
    List<Object> sprites = new List<Object>(); //SpriteObjectのリストコピー
    List<Object> models = new List<Object>();
    List<UIBase> images = new List<UIBase>();
    List<Text> texts = new List<Text>();
    Canvas canvas;

    List<MeshFilter> meshes = new List<MeshFilter>();
    List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    List<SpriteRenderer> renderers = new List<SpriteRenderer>();
    List<BoxCollider> spriteColliders = new List<BoxCollider>();
    List<BoxCollider> modelColliders = new List<BoxCollider>();
    List<UnityEngine.UI.Image> images2D = new List<UnityEngine.UI.Image>();
    List<RectTransform> imageTransform = new List<RectTransform>();
    List<TMPro.TextMeshProUGUI> texts2D = new List<TMPro.TextMeshProUGUI>();
    List<RectTransform> textTransform = new List<RectTransform>();

    UnityEngine.Camera cam;

    public void Init()
    {
        cam = UnityEngine.Camera.main;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void OnUpdate()
    {
        sprites = SpriteList.GetList();
        models = ModelList.GetList();
        images = ImageList.GetList();
        texts = TextList.GetList();

        cam.transform.position = ConvertToVector(Cam.pos);
        cam.transform.rotation = Quaternion.Euler(ConvertToVector(Cam.rot));
        while (modelList.Count != models.Count) //リストの長さを揃える
        {
            int n = modelList.Count - 1;
            if (modelList.Count > models.Count)
            {
                Destroy(modelList[n]);
                modelList.RemoveAt(n);
                meshes.RemoveAt(n);
                meshRenderers.RemoveAt(n);
                modelColliders.RemoveAt(n);
            }
            else if (modelList.Count < models.Count)
            {
                modelList.Add(null);
                meshes.Add(null);
                meshRenderers.Add(null);
                modelColliders.Add(null);
            }
        }

        for (int i = 0; i < models.Count; i++)
        {
            if (modelList[i] == null)
            {
                modelList[i] = (GameObject)Instantiate(Resources.Load(modelPath));
                modelList[i].GetComponent<Obj>().SetId(i);
                meshes[i] = modelList[i].GetComponent<MeshFilter>();
                meshRenderers[i] = modelList[i].GetComponent<MeshRenderer>();
                modelColliders[i] = modelList[i].GetComponent<BoxCollider>();
            }
            meshes[i].mesh = MeshLoader.Load(models[i].image);
            meshRenderers[i].material = MaterialLoader.Load(models[i].material);
            modelList[i].transform.position = ConvertToVector(models[i].pos);
            modelList[i].transform.rotation = Quaternion.Euler(ConvertToVector(models[i].rot));
            modelList[i].transform.localScale = ConvertToVector(models[i].scale);
            modelColliders[i].size = ConvertToVector(models[i].collisonSize);
        }

//------------------------------------------------------------------------------------------------------

        while (spriteList.Count != sprites.Count) //リストの長さを揃える
        {
            int n = spriteList.Count - 1;
            if (spriteList.Count > sprites.Count)
            {
                Destroy(spriteList[n]);
                spriteList.RemoveAt(n);
                renderers.RemoveAt(n);
                spriteColliders.RemoveAt(n);
            }
            else if (spriteList.Count < sprites.Count)
            {
                spriteList.Add(null);
                renderers.Add(null);
                spriteColliders.Add(null);
            }
        }

        for (int i = 0; i < sprites.Count; i++) //Spriteの状態を反映させる
        {
            if (spriteList[i] == null) //Objectが無い場合、空のObjectを生成
            {
                spriteList[i] = (GameObject)Instantiate(Resources.Load(spritePath));
                renderers[i] = spriteList[i].GetComponent<SpriteRenderer>();
                spriteColliders[i] = spriteList[i].GetComponent<BoxCollider>();
            }
            renderers[i].sprite = SpriteLoader.Load(sprites[i].image);
            spriteList[i].transform.position = ConvertToVector(sprites[i].pos);
            spriteList[i].transform.rotation = Quaternion.Euler(ConvertToVector(sprites[i].rot));
            spriteList[i].transform.localScale = ConvertToVector(sprites[i].scale);
        }
//------------------------------------------------------------------------------------------------------
        while (imageList.Count != images.Count)
        {
            int n = imageList.Count - 1;
            if (imageList.Count > images.Count)
            {
                Destroy(imageList[n]);
                imageList.RemoveAt(n);
                imageTransform.RemoveAt(n);
                images2D.RemoveAt(n);
            }
            else if (imageList.Count < images.Count)
            {
                imageList.Add(null);
                imageTransform.Add(null);
                images2D.Add(null);
            }
        }

        for (int i = 0; i < images.Count; i++)
        {
            if (imageList[i] == null)
            {
                imageList[i] = (GameObject)Instantiate(Resources.Load(imagePath));
                imageList[i].transform.parent = canvas.transform;
                imageList[i].GetComponent<Canvas>().sortingOrder = images[i].sort;
                imageTransform[i] = imageList[i].GetComponent<RectTransform>();
                images2D[i] = imageList[i].GetComponent<UnityEngine.UI.Image>();
            }
            if (images[i].state == UIState.Inactive) 
            {
                images2D[i].sprite = null;
                imageTransform[i].sizeDelta = ConvertToVector(new Vector2(0, 0));
            }
            else if (images[i].state == UIState.Active) 
            {
                images2D[i].sprite = SpriteLoader.Load(images[i].image);
                imageTransform[i].sizeDelta = ConvertToVector(images[i].size);
            }
            imageTransform[i].position = ConvertToVector(images[i].pos);
        }
//------------------------------------------------------------------------------------------------------
        while (textList.Count != texts.Count)
        {
            int n = textList.Count - 1;
            if (textList.Count > texts.Count)
            {
                Destroy(textList[n]);
                textList.RemoveAt(n);
                textTransform.RemoveAt(n);
                texts2D.RemoveAt(n);
            }
            else if (textList.Count < texts.Count)
            {
                textList.Add(null);
                textTransform.Add(null);
                texts2D.Add(null);
            }
        }

        for (int i = 0; i < texts.Count; i++)
        {
            if (textList[i] == null)
            {
                textList[i] = (GameObject)Instantiate(Resources.Load(textPath));
                textList[i].transform.parent = canvas.transform;
                textList[i].GetComponent<Canvas>().sortingOrder = texts[i].sort;
                textTransform[i] = textList[i].GetComponent<RectTransform>();
                texts2D[i] = textList[i].GetComponent<TMPro.TextMeshProUGUI>();
            }
            if (texts[i].state == UIState.Inactive) texts2D[i].text = "";
            else if (texts[i].state == UIState.Active) 
            {
                UnityEngine.Color color = new UnityEngine.Color(texts[i].color.R, texts[i].color.G, texts[i].color.B, texts[i].color.A);
                texts2D[i].fontSize = texts[i].fontSize;
                texts2D[i].text = texts[i].text;
                texts2D[i].color = color;
            }
            textTransform[i].position = ConvertToVector(texts[i].pos);
            textTransform[i].sizeDelta = ConvertToVector(texts[i].size);
        }
    }

    UnityEngine.Vector3 ConvertToVector(Vector3 pos)
    {
        UnityEngine.Vector3 vec = new UnityEngine.Vector3();
        vec.x = pos.x;
        vec.y = pos.y;
        vec.z = pos.z;
        return vec;
    }
    UnityEngine.Vector2 ConvertToVector(Vector2 pos)
    {
        UnityEngine.Vector2 vec = new UnityEngine.Vector2();
        vec.x = pos.x;
        vec.y = pos.y;
        return vec;
    }
}