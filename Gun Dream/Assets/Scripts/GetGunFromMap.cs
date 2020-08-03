using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGunFromMap : MonoBehaviour
{
    public Transform AnimationSung;
    public GunManager.TypeSung TypeSung;
    public GameObject ThisGun;
    public Vector3 localScale;

    private void Start()
    {
        Instantiate(ThisGun, AnimationSung, false).transform.localScale = localScale;
    }
}
