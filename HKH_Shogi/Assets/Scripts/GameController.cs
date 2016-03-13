using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] CanvasScaler rootCanvasScaler; // TODO 別階層のオブジェクト参照をやめる

    void Awake()
    {
        Initialize ();
    }
        
    void Initialize()
    {
#if UNITY_WEBGL
        rootCanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
#elif UNITY_EDITOR
        rootCanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        #else 
        rootCanvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
#endif
    }
}
