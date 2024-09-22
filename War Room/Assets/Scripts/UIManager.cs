using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button startServerButton;

    [SerializeField]
    private Button startHostButton;

    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private Button startGameButton;

    [SerializeField]
    private TextMeshProUGUI playerInGameCountText;

    [SerializeField]
    private GameObject nationHandler;

    int randNum;
    bool serverStarted;

    private void Awake()
    {
        Cursor.visible = true;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(0, 10);

        startHostButton.onClick.AddListener(() =>
        {
            if(NetworkManager.Singleton.StartHost())
            {
                //nationHandler.SetActive(true);
                Debug.Log("Host started");
            }
            else
            {
                Debug.Log("Host failed to start... odd");
            }
        });

        startServerButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartServer())
            {
                //nationHandler.SetActive(true);
                Debug.Log("Server started");
            }
            else
            {
                Debug.Log("Server failed to start... odd");
            }
        });

        startClientButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {
                Debug.Log("Client started");
            }
            else
            {
                Debug.Log("Client failed to start... odd");
            }
        });

        startGameButton.onClick.AddListener(() =>
        {
            if (serverStarted)
            {
                nationHandler.SetActive(true);
            }
        });

        NetworkManager.Singleton.OnServerStarted += () =>
        {
            serverStarted = true;
        };
    }

    void Update()
    {
        playerInGameCountText.text = $"Num of Players: {PlayerHandler.Instance.PlayersInGame}. Random number: {randNum}";
    }
}
