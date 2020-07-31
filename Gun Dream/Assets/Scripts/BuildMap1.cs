using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMap1 : MonoBehaviour
{
    public Vector3 posStart;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = PlayerManager.Instance.Player;
        player.transform.position = new Vector3(0, PlayerManager.Instance.posY[PlayerPrefs.GetInt("Player_int")], 0);
        CameraMain.Instance.setStart();
        if (player.GetComponent<PlayerController>().SungHienTai == null)
        {
            GunManager.Instance.getSungLuc("Random");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
