using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGunFromMap : MonoBehaviour
{
    public Transform AnimationSung;
    public GunManager.TypeSung TypeSung;
    public Shooter ThisGun;
    public Vector3 localScale;
    public bool DestroyOnGet;

    public void CheckToDestroy()
    {
        if (DestroyOnGet)
        {
            Destroy(this.gameObject);
        }
    }
    public void AddGun(Shooter ThisGun, bool DestroyOnGet)
    {
        this.ThisGun = ThisGun;
        TypeSung = ThisGun.LoaiSung;
        localScale = ThisGun.SpawnSung.localScale;
        this.DestroyOnGet = DestroyOnGet;
        Spawn();
    }

    public void Spawn()
    {
        Instantiate(ThisGun, AnimationSung, false).transform.localScale = localScale;
    }
}
