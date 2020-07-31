using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMapGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.Instance.Player.transform.position = new Vector3(0, PlayerManager.Instance.posY[PlayerPrefs.GetInt("Player_int")], 40);
    }

}
