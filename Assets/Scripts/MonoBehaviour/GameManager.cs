using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerInput input = new PlayerInput();
    Draw draw = new Draw();
    Unit unitA;
    Unit unitB;

    void Start()
    {
        Application.targetFrameRate = 60;
        unitA = new UnitA().Init();
        unitB = new UnitA().Init(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        input.OnUpdate();
        draw.OnUpdate();
    }
}
