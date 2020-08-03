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
    public HienThiThongTInSung hienthi;
    public static GameObject GunFromMap;
    public static TypeSung TypeGunFromMap;
    private void Awake()
    {
            Instance = this;
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
    private void Update()
    {
        if (GunFromMap != null)
        {
            hienthi.gameObject.SetActive(true);
        } else
        {
            hienthi.gameObject.SetActive(false);
        }
    } 

    public void  getSung(TypeSung type, GameObject Sung)
    {
        if (type == TypeSung.SungLuc)
        {
            CheckGunToDesTroy();
            PlayerController playercontroller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
            AudioController.Instance.Play_ThaySung();
            GameObject sung = Instantiate(Sung, playercontroller.SpawnSungLuc.transform);
            playercontroller.setSungHienTai(sung);
            playercontroller.CamSungLuc();
        }
        if (type == TypeSung.SungTruong)
        {
            CheckGunToDesTroy();
            PlayerController playercontroller = PlayerManager.Instance.Player.GetComponent<PlayerController>();
            AudioController.Instance.Play_ThaySung();
            GameObject sung = Instantiate(Sung, playercontroller.SpawnSungTruong.transform);
            playercontroller.setSungHienTai(sung);
            playercontroller.CamSungTruong();
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
