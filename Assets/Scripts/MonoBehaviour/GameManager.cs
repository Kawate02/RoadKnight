using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerInput input = new PlayerInput();
    main main = new main();
    Draw draw = new Draw();    

    void Awake()
    {
        Application.targetFrameRate = 60;
        input.Init();
        main.Init();
        draw.Init();
    }

    // Update is called once per frame
    void Update()
    {
        input.OnUpdate();
        main.OnUpdate();
        draw.OnUpdate();
    }
}
