﻿using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Animator))]
public class PlayerController : LivingOB
{
    public GameObject SpawnSungLuc;
    public GameObject SpawnSungTruong;

    [HideInInspector]
    public GameObject SungHienTai;
    public GameObject Eye;
    private DieuKhien dk;
    private Rigidbody rig;
    private Animator animator;
    private bool hitting;
    private bool ismoving;
    private string anim_walk = "isWalking";
    private string anim_sung = "Masung";
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        dk = FindObjectOfType<DieuKhien>();
        rig = GetComponent<Rigidbody>();
    }

    public void Shoot()
    {
        if (SungHienTai != null)
        {
            SungHienTai.GetComponent<Shooter>().CaltoShoot();
        }
    }

    protected override void ShowHealth()
    {
        showHealth = Instantiate(EffectIsHere.Instance.ShowHealth, PosShowHealth) as ShowHealth;
        showHealth.SetAll(StartHealth, Health, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GoMap")
        {
            GameController.Instance.GoToMAP("GamePlay");
        }
        if (other.tag == "GetSung")
        {
            CVDK.Instance.GetSungButton.SetActive(true);
            GetGunFromMap a = other.GetComponentInParent<GetGunFromMap>();
            GunManager.Instance.GunFromMap = a.ThisGun;
            GunManager.Instance.TypeGunFromMap = a.TypeSung;
            GunManager.Instance.SpawnGunFromMap = a;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "GetSung")
        {
            CVDK.Instance.GetSungButton.SetActive(false);
            GunManager.Instance.GunFromMap = null;
            GunManager.Instance.TypeGunFromMap = GunManager.TypeSung.None;
            GunManager.Instance.SpawnGunFromMap = null;
        }
    }

    public bool IsMoving()
    {
        return ismoving;
    }

    public void setMove(bool ismove)
    {
        ismoving = ismove;
    }

    public void setAnimationMove(bool move)
    {
        animator.SetBool(anim_walk, move);
        setMove(move);
    }

    public void CamSungLuc()
    {
        animator.SetInteger(anim_sung, 1);
    }

    public void CamSungTruong()
    {
        animator.SetInteger(anim_sung, 2);
    }

    public float getMoveSpeed()
    {
        return MoveSpeed;
    }

    public void setSungHienTai(GameObject sung)
    {
        SungHienTai = sung;
    }

    public bool HaveGunInHand()
    {
        if (SungHienTai == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }




}
