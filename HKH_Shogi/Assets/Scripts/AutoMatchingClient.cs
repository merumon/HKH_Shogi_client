using UnityEngine;
using System.Collections;
using System;

public class AutoMatchingClient : Photon.MonoBehaviour
{
    int roomNumber;
    Action onMatched;
    Action onFailed;

    bool isConnecting;

    public void StartMatching(int roomNumber, Action onMatched, Action onFailed)
    {
        if (isConnecting) return;

        isConnecting = true;
        this.roomNumber = roomNumber;
        this.onMatched = onMatched;
        this.onFailed = onFailed;

        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    public void StopMatching()
    {
        roomNumber = 0;
        onMatched = null;
        onFailed = null;
    }

    void SuccessMatching()
    {
        if(onMatched != null) onMatched();
    }

    // サーバーへの初期接続が確立したとき呼び出されます。
    void OnConnectedToPhoton()
    {
        Debug.Log ("Client: Connected Server.");
    }

    void OnFailedToConnectToPhoton()
    {
        if (onFailed != null) onFailed ();
        StopMatching ();
    }

    // PhotonNetwork.ConnectUsingSettingsを行うと呼ばれる
    void OnJoinedLobby()
    {
        //ランダムにルームに入る
    //    PhotonNetwork.JoinRandomRoom();
        Debug.Log("Client: In Lobby.");

        PhotonNetwork.JoinRoom (roomNumber.ToString());
    }

    // JoinRoomでルームに入れなかった
    void OnPhotonJoinRoomFailed()
    {
        Debug.Log("Client: Create Room.");

        //部屋を自分で作って入る
        PhotonNetwork.CreateRoom(roomNumber.ToString());
    }

    // ランダムにルームに入れなかった
    void OnPhotonRandomJoinFailed()
    {
        //部屋を自分で作って入る
        PhotonNetwork.CreateRoom(roomNumber.ToString());
    }

    // ルームに入室成功
    // 部屋に入った際に呼び出されます。(部屋作成時もしくは参加時)
    // これは全てのクライアント(マスタークライアント含む)で呼び出されます。
    void OnJoinedRoom()
    {
        Debug.Log ("Client: In Room.");

        if (PhotonNetwork.room.playerCount > 1)
        {
            SuccessMatching ();
        }
    }

    /// リモートプレイヤーが部屋に入ったときに呼び出されます。
    /// 入室したプレイヤーは既に PhotonNetwork.playerList に追加されています。
    /// もしあなたのゲームが特定の人数で始まる場合、このコールバックが役立ちます。
    /// Room.playerCount を確認し、開始できるか確認しましょう。
    void OnPhotonPlayerConnected()
    {
        SuccessMatching ();
    }

}
