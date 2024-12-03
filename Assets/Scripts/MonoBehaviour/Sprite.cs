using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public static class SpriteLoader
{
    static List<Sprite> list = new List<Sprite>();
    static Dictionary<string, int> pathList = new Dictionary<string, int>();

    public static Sprite Load(string path)
    {
        Debug.Log(path);
        if (pathList.ContainsKey(path)) return list[pathList[path]];
        pathList.Add(path, list.Count);
        list.Add(Resources.Load<Sprite>(path));
        Debug.Log(list[list.Count - 1]);
        return list[list.Count - 1];
    }
}