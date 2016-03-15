using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuButtonsPanel : MonoBehaviour
{
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Text matchedText;

    public void OnTapTestButton1()
    {
        button1.enabled = false;
        GameController.Instance.MatchingClient.StartMatching (1, onMatched:() => {
            matchedText.text = "Room1 マッチング成功！";
        }, onFailed: () => {
            matchedText.text = "接続失敗...";
        });
    }

    public void OnTapTestButton2()
    {
        button2.enabled = false;
        GameController.Instance.MatchingClient.StartMatching (2, onMatched: () => {
            matchedText.text = "Room2 マッチング成功！";
        }, onFailed: () => {
            matchedText.text = "接続失敗...";
        });
    }
}
