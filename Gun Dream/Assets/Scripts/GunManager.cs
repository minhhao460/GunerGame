using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    [HideInInspector]
    public enum TypeSung { None, SungLuc, SungTruong, Shotgun, Truong};


    public static GunManager Instance { get; private set; }

    public GameObject[] SungLuc;

    public static GameObject GunFromMap;
    public static TypeSung TypeGunFromMap;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public void getSungLuc(string a)
    {
        switch (a)
        {
            case "Random":
                int count = SungLuc.Length;
                int random = Random.Range(0, count);
                Instantiate(SungLuc[random], PlayerManager.Instance.Player.GetComponent<PlayerController>().SpawnSungLuc.transform);
                break;
            case "Red":
                Instantiate(SungLuc[1], PlayerManager.Instance.Player.GetComponent<PlayerController>().SpawnSungLuc.transform);
                break;
            case "Blue":
                Instantiate(SungLuc[3], PlayerManager.Instance.Player.GetComponent<PlayerController>().SpawnSungLuc.transform);
                break;
            case "Yellow":
                Instantiate(SungLuc[0], PlayerManager.Instance.Player.GetComponent<PlayerController>().SpawnSungLuc.transform);
                break;
            case "Green":
                Instantiate(SungLuc[2], PlayerManager.Instance.Player.GetComponent<PlayerController>().SpawnSungLuc.transform);
                break;
        }
    }

    public void  getSung(TypeSung type, GameObject Sung)
    {
        if (type == TypeSung.SungLuc)
        {
            CheckGunToDesTroy();
            AudioController.Instance.Play_ThaySung();
            Instantiate(Sung, PlayerManager.Instance.Player.GetComponent<PlayerController>().SpawnSungLuc.transform);
        }
    }

    public void CheckGunToDesTroy()
    {
        if (PlayerManager.Instance.Player.GetComponent<PlayerController>().SungHienTai != null)
        {
            Destroy(PlayerManager.Instance.Player.GetComponent<PlayerController>().SungHienTai);
        }
    }

    public void GetGunAfterIn()
    {
        if (GunFromMap != null)
        {
            getSung(TypeGunFromMap, GunFromMap);
        }
    }

}
