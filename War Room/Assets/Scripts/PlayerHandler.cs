using Unity.Netcode;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> : NetworkBehaviour
    where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var objs = FindObjectsOfType(typeof(T)) as T[];
                if (objs.Length > 0)
                {
                    _instance = objs[0];
                }
                if (objs.Length > 1)
                {
                    Debug.LogError("There is more than one " + typeof(T).Name + " in the scene!");
                }
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = string.Format("_{0}", typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}


public class PlayerHandler : Singleton<PlayerHandler>
{
    [SerializeField]
    NationSelectionManager nationSelection;

    private Dictionary<string,ulong> playerInfo = new Dictionary<string,ulong>();

    private NetworkVariable<int> playersInGame = new NetworkVariable<int>();
    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            if (IsServer)
            {
                Debug.Log("Player:" + id + " connected.");
                playersInGame.Value++;
            }
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            if (IsServer)
            {
                Debug.Log("Player:" + id + " disconnected.");
                playersInGame.Value--;
            }
        };
    }

    [Rpc(SendTo.Everyone)]
    public void ChooseNationRpc(string nationName, bool selected)
    {
        nationSelection.nationSelected(nationName, selected);
    }

    public void sendPlayerInfo(ulong clientID, string name)
    {
        playerInfo.Add(name, clientID);
    }


}


