using System;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour, ThongTInSungManager
{
    public float doGiat;
    public int Damage;
    public float TocDoBay;
    public GameObject spawnDan;
    public float TocDoBan;
    public GunManager.TypeSung LoaiSung;
    public BulletManager.TypeDan LoaiDan;
    public VienDan[] viendan;

    public SpawnQ SpawnSung;
    public AmThanhQ AmThanh;
    public HieuHungQ HieuHung;
    public InfoQ Info;

    #region Class Of Shooter
    [Serializable]
    public class SpawnQ
    {
        public Vector3 localScale = Vector3.one;
    }
    [Serializable]
    public class HieuHungQ
    {
        public string codeEffectShoot;
    }
    [Serializable]
    public class AmThanhQ
    {
        public string codeAudioShoot;
    }
    [Serializable]
    public class InfoQ
    {
        public Sprite HinhAnh;
        public Color colorif;
        public Color colorifh;
        public STRINGS.Name codeName;
        public STRINGS.He codeInfoHe;
    }
    #endregion

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
        ShowEffectShoot();
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
        a.y = a.y + UnityEngine.Random.Range(-giat, giat);
        a.x = a.x + UnityEngine.Random.Range(-giat, giat);
        VienDan dan = Instantiate(viendan[UnityEngine.Random.Range(0, viendan.Length)], spawnDan.transform.position, Quaternion.Euler(a)) as VienDan;
        dan.setSpeed(TocDoBay);
        dan.setDamage(Damage);
        m_BanLanCuoi_Time = Time.time;
    }

    protected virtual void PlayAudioShoot()
    {
        AudioController.Instance.PlayAudio(AmThanh.codeAudioShoot);
    }

    protected virtual void ShowEffectShoot()
    {
        EffectIsHere.Instance.SpawnEffect(EffectIsHere.Instance.getEffect(HieuHung.codeEffectShoot), spawnDan.transform, true, 0.2f);
    }

    public string getName()
    {
        return STRINGS.Instance.getNameOfGun(Info.codeName);
    }

    public float getDamage()
    {
        return Damage;
    }

    public float getAS()
    {
        return TocDoBan;
    }

    public string getInfo()
    {
        return STRINGS.Instance.getInfoOfGun(Info.codeName);
    }

    public string getInfoHe()
    {
        return STRINGS.Instance.getHeOfGun(Info.codeInfoHe);
    }

    public Sprite getImage()
    {
        return Info.HinhAnh;
    }

    public Color getColorHe()
    {
        return Info.colorif;
    }

    public Color getFixedColorHe()
    {
        return Info.colorifh;
    }
}
