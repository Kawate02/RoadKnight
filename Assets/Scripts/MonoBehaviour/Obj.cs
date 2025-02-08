using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{
    int id;

    public void SetId(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }
}
