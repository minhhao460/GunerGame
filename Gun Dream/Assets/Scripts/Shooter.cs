using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float doGiat;
    public int Damage;
    public float TocDoBay;
    public GameObject spawnDan;
    public float TocDoBan;
    public GunManager.TypeSung LoaiSung;
    public BulletManager.TypeDan LoaiDan;
    public VienDan[] viendan;
    private GameObject player;
    private float m_BanLanCuoi_Time;
    private DieuKhien dk;
    // Start is called before the first frame update
    private void Start()
    {
        player = PlayerManager.Instance.Player;
        dk = FindObjectOfType<DieuKhien>();
        m_BanLanCuoi_Time = Time.time;
    }
    

    public void Shoot()
    {
        if (Time.time - m_BanLanCuoi_Time < 1 / TocDoBan)
        {
            return;
        }
        PlayAudioShoot();
        Vector3 a;
        if (FindEnemy.Instance.HaveEnemy())
        {
            Vector3 huong = (FindEnemy.Instance.getPosEnemy() - spawnDan.transform.position);
            a = Quaternion.LookRotation(huong).eulerAngles;
        } else
        {
            a = dk.getHuong().eulerAngles;
        }
        float giat = doGiat;
        if (!player.GetComponent<PlayerController>().IsMoving())
        {
            giat /= 2;
        }
        a.y = a.y + Random.Range(-giat, giat);
        a.x = a.x + Random.Range(-giat, giat);
        VienDan dan = Instantiate(viendan[Random.Range(0, viendan.Length)], spawnDan.transform.position, Quaternion.Euler(a)) as VienDan;
        dan.setSpeed(TocDoBay);
        dan.setDamage(Damage);
        m_BanLanCuoi_Time = Time.time;
    }

    protected virtual void PlayAudioShoot()
    {
        AudioController.Instance.PlayAudio("SungLuc");
    }


}
