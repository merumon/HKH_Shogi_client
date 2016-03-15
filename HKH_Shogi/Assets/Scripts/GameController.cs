using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField] CanvasScaler rootCanvasScaler; // TODO 別階層のオブジェクト参照をやめる
    [SerializeField] AutoMatchingClient autoMatchingClient;

    public AutoMatchingClient MatchingClient { get { return autoMatchingClient; } } 

    void Start()
    {
        
    }

    protected override void Awake()
    {
        base.Awake ();

        Initialize ();
    }
        
    void Initialize()
    {

    }

    void SetCanvasScaleMode()
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
