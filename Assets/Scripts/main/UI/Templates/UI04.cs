// public class UI04 : Popup
// {
//     UI ui02;
//     UI ui03;
//     public UI Init(int _sort, float x = 0, float y = 0, UI parent = null)
//     {
//         ui02 = new UI02().Init(_sort + 2, 350, 450, this);
//         ui03 = new UI03().Init(_sort + 3, 330, 30, this);
//         base.Init(true, _sort, x, y, 600, 600, parent);
//         return this;
//     }

//     public override void Destroy()
//     {
//         ui02.Destroy();
//         ui03.Destroy();
//         base.Destroy();
//     }
// }