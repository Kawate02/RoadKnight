using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//ResourcesフォルダからSpriteをロード
public static class SpriteLoader
{
    static List<UnityEngine.Sprite> list = new List<UnityEngine.Sprite>();
    static Dictionary<string, int> pathList = new Dictionary<string, int>();

    public static UnityEngine.Sprite Load(string path)
    {
        if (path == null) return null;
        if (pathList.ContainsKey(path)) 
        {
            //ロード済みの素材だった
            return list[pathList[path]];
        }
        pathList.Add(path, list.Count);
        list.Add(Resources.Load<UnityEngine.Sprite>(path));
        return list[list.Count - 1];
    }
}

public static class MeshLoader
{
    static List<Mesh> list = new List<Mesh>();
    static Dictionary<string, int> pathList = new Dictionary<string, int>();


    public static Mesh Load(string path)
    {
        if (path == null) return null;
        if (pathList.ContainsKey(path)) return list[pathList[path]];
        list.Add(Resources.Load<Mesh>(path));
        pathList.Add(path, list.Count - 1);
        return list[list.Count - 1];
    }
}

public static class MaterialLoader
{
    static List<Material> list = new List<Material>();
    static Dictionary<string, int> pathList = new Dictionary<string, int>();


    public static Material Load(string path)
    {
        if (path == null) return null;
        if (pathList.ContainsKey(path)) return list[pathList[path]];
        pathList.Add(path, list.Count);
        list.Add(Resources.Load<Material>(path));
        return list[list.Count - 1];
    }
}