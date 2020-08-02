using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set;}
    public GameObject[] listPlayer;
    public float[] posY;
    public GameObject Player;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        if (Player != null)
        {
            Destroy(Player);
            Player = null;
        }
        int int_player = PlayerPrefs.GetInt("Player_int");
        Player = Instantiate(listPlayer[int_player]);
        DontDestroyOnLoad(Player);
    }
}
