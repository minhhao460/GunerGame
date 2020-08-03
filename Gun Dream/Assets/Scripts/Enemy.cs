using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Enemy : LivingOB
{
    public enum TypeElementEnemy { None, Stun, Fire, Poision, Freeze }
    protected TypeElementEnemy typeElement;
    public GameObject posShoot;
    public GameObject posSpawnEffect;
    public bool PermitMove = true;
    public float Time_Relax;

    public float shield_Lua;
    public float shield_Doc;
    public float shield_Choang;
    public float shield_Bang;

    [SerializeField]
    private bool PhanLoai = true;
    private Animator anim;
    // Lửa
    bool firing = false;
    int damage_Lua;
    int damageDes_Lua;
    GameObject Ecf_Fire;
    float lastTime_Lua;

    // Độc
    bool poisioning;
    int damage_Doc;
    int damageDes_Doc;
    GameObject Ecf_Poison;
    float lastTime_Doc;

    // Choáng
    float time_Choang;
    bool stuning;
    GameObject Ecf_Stun;

    // Băng
    bool freezing; // Đang nhiễm băng
    float time_bang; // Số lần đóng băng còn lại
    GameObject Ecf_Freeze;

    // di chuyen
    private NavMeshAgent nav;
    float time_lastMoved;
    bool moving;
    bool relaxing;
    Vector3 des;
    protected override void Start()
    {
        if (PhanLoai)
        {
            setTypeElement_Shield_ColorHealth();
        }
        base.Start();
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        time_lastMoved = Time.time + UnityEngine.Random.Range(-Time_Relax, 0);
    }
    
    protected override void Die()
    {
        base.Die();
        anim.SetBool("Die", dead);
        anim.speed = 1;
        FindEnemy.Instance.Find();
    }
    private void Update()
    {
        UpdateEffect();
        UpdateMove();
    }
    
    // Xử lý sác thương nhân vào
    public void NhanDam(BulletManager.TypeDan typeDan, int damage)
    {
        if (dead) return;
        int damageMain;
        int min = Mathf.CeilToInt((damage * 80) / 100);
        int max = Mathf.CeilToInt((damage * 120) / 100);
        damage = UnityEngine.Random.Range(min, max);
        switch (typeDan)
        {
            case (BulletManager.TypeDan.None):
                damageMain = TakeHitAfterResist(damage, Shield);
                TakeHit(damageMain, BulletManager.color_Default);
                break;

            case (BulletManager.TypeDan.Lua):
                damageMain = TakeHitAfterResist(damage, shield_Lua);
                TakeHit(damageMain, BulletManager.color_Lua);
                NhanLua();
                break;

            case (BulletManager.TypeDan.Doc):
                damageMain = TakeHitAfterResist(damage, shield_Doc);
                TakeHit(damageMain, BulletManager.color_Doc);
                NhanDoc();
                break;

            case (BulletManager.TypeDan.Bang):
                damageMain = TakeHitAfterResist(damage, shield_Bang);
                TakeHit(damageMain, BulletManager.color_Bang);
                NhanBang();
                break;

            case (BulletManager.TypeDan.Choang):
                damageMain = TakeHitAfterResist(damage, shield_Choang);
                TakeHit(damageMain, BulletManager.color_Choang);
                NhanChoang();
                break;
        }
    }
    protected override void TakeHit(int damage)
    {
        base.TakeHit(damage);
    }
    int TakeHitAfterResist(int damage, float shield)
    {
        return Mathf.CeilToInt(Mathf.Max(damage - shield * damage, 0));
    }
    float TakeTimeAfterResist(float damage, float shield)
    {
        return (Mathf.Max(damage - shield * damage, 0));
    }
    int TakeHitAfterResist(float tiledamage, float shield)
    {
        return Mathf.CeilToInt((tiledamage * StartHealth) - (tiledamage * StartHealth * shield));
    }
    void UpdateEffect()
    {
        if (dead) return;
        firing = (damage_Lua > 0);
        poisioning = (damage_Doc > 0);
        stuning = (time_Choang > 0);
        freezing = (time_bang > 0);
        float tilemove = 1;
        float tilemove_anim = 1;
        if (firing && Time.time - lastTime_Lua > BulletManager.Timedelay_Lua)
        {
            DeCreaseLua();
        } else
        if (poisioning && Time.time - lastTime_Doc > BulletManager.TimeDelay_Doc)
        {
            DeCreaseDoc();
        } else
        if (freezing)
        {
            tilemove_anim = BulletManager.Tile_DeMove;
            tilemove = BulletManager.Tile_DeMove;
            DeCreaseBang();
        } else
        if (stuning)
        {
            tilemove = 0;
            tilemove_anim = 0;
            DeCreaseChoang();
        }
        MoveSpeed = tilemove * MoveSpeedStart;
        nav.speed = MoveSpeed;
        anim.speed = tilemove_anim;
    }

    void DeCreaseLua()
    {
        int dam = Mathf.Min(damage_Lua, damageDes_Lua);
        TakeHit(dam, BulletManager.color_Lua);
        damage_Lua -= dam;
        lastTime_Lua = Time.time;
        if (!Damaging_Effect())
        {
            ResetAllEffect();
        }
    }
    void DeCreaseDoc()
    {
        int dam = Mathf.Min(damage_Doc, damageDes_Doc);
        TakeHit(dam, BulletManager.color_Doc);
        damage_Doc -= dam;
        lastTime_Doc = Time.time;
        if (!Damaging_Effect())
        {
            ResetAllEffect();
        }
    }
    void DeCreaseBang()
    {
        time_bang -= Time.deltaTime;
        if (!Damaging_Effect())
        {
            ResetAllEffect();
        }
    }
    void DeCreaseChoang()
    {
        time_Choang -= Time.deltaTime;
        if (!Damaging_Effect())
        {
            ResetAllEffect();
        }
    }

    void NhanLua()
    {
        if (!GameController.SacXuat(BulletManager.TiLe_Lua))
        {
            return;
        }
        if (typeElement == TypeElementEnemy.Fire)
        {
            MienNhiem(BulletManager.color_Lua);
            return;
        }
        if (!(damage_Lua > 0))
        {
            ResetAllEffect();
            Ecf_Fire = Instantiate(EffectIsHere.Instance.Fire, posSpawnEffect.transform);
        }
        damage_Lua = TakeHitAfterResist(BulletManager.Lua, shield_Lua);
        damageDes_Lua = TakeHitAfterResist(BulletManager.dama_everyTime_Lua, shield_Lua);
    }
    void NhanDoc()
    {
        if (!GameController.SacXuat(BulletManager.Tile_Doc))
            return;
        if (typeElement == TypeElementEnemy.Poision)
        {
            MienNhiem(BulletManager.color_Doc);
            return;
        }
        if (!(damage_Doc > 0))
        {
            ResetAllEffect();
            Ecf_Poison = Instantiate(EffectIsHere.Instance.Poision, posSpawnEffect.transform);
        }
        damage_Doc = TakeHitAfterResist(BulletManager.Doc, shield_Doc);
        damageDes_Doc = TakeHitAfterResist(BulletManager.dama_everyTime_Doc, shield_Doc);
    }
    void NhanChoang()
    {
        if (!GameController.SacXuat(BulletManager.TiLe_Choang))
        {
            return;
        }
        if (typeElement == TypeElementEnemy.Stun)
        {
            MienNhiem(BulletManager.color_Choang);
            return;
        }
        if (!(time_Choang > 0))
        {
            ResetAllEffect();
            Ecf_Stun = Instantiate(EffectIsHere.Instance.Stun, posSpawnEffect.transform);
        }
        time_Choang = TakeTimeAfterResist(BulletManager.Time_Choang, shield_Choang);
    }
    void NhanBang()
    {
        if (!GameController.SacXuat(BulletManager.Tile_Bang))
        {
            return;
        }
        if (typeElement == TypeElementEnemy.Freeze)
        {
            MienNhiem(BulletManager.color_Bang);
            return;
        }
        if (!(time_bang > 0))
        {
            ResetAllEffect();
            Ecf_Freeze = Instantiate(EffectIsHere.Instance.Freeze, posSpawnEffect.transform);
        }
        time_bang = TakeTimeAfterResist(BulletManager.Time_Bang, shield_Bang);
    }

    void ResetLua()
    {
        damage_Lua = 0;
        lastTime_Lua = 0;
        damageDes_Lua = 0;
        if (Ecf_Fire != null)
        {
            Destroy(Ecf_Fire);
            Ecf_Fire = null;
        }
    }
    void ResetDoc()
    {
        damage_Doc = 0;
        lastTime_Doc = 0;
        damageDes_Doc = 0;
        if (Ecf_Poison != null)
        {
            Destroy(Ecf_Poison);
            Ecf_Poison = null;
        }
    }
    void ResetChoang()
    {
        time_Choang = 0;
        if (Ecf_Stun != null)
        {
            Destroy(Ecf_Stun);
            Ecf_Stun = null;
        }
    }
    void ResetBang()
    {
        time_bang = 0;
        if (Ecf_Freeze != null)
        {
            Destroy(Ecf_Freeze);
            Ecf_Freeze = null;
        }
    }
    void ResetAllEffect()
    {
        ResetBang();
        ResetChoang();
        ResetDoc();
        ResetLua();
    }

    bool Damaging_Effect()
    {
        return (damage_Lua > 0 || damage_Doc > 0 || time_Choang > 0 || time_bang > 0);
    }
    void setTypeElement_Shield_ColorHealth()
    {
        int random = UnityEngine.Random.Range(0, 4) + 1;
        switch (random)
        {
            case 1:
                typeElement = TypeElementEnemy.Stun;
                shield_Choang = Mathf.Min(shield_Choang + 0.5f, 0.9f);
                Health_Color = EffectIsHere.Instance.Health_Color_Stun;
                break;
            case 2:
                typeElement = TypeElementEnemy.Fire;
                shield_Lua = Mathf.Min(shield_Lua + 0.5f, 0.9f);
                Health_Color = EffectIsHere.Instance.Health_Color_Fire;
                break;
            case 3:
                typeElement = TypeElementEnemy.Poision;
                shield_Doc = Mathf.Min(shield_Doc + 0.5f, 0.9f);
                Health_Color = EffectIsHere.Instance.Health_Color_Poision;
                break;
            case 4:
                typeElement = TypeElementEnemy.Freeze;
                shield_Bang = Mathf.Min(shield_Bang + 0.5f, 0.9f);
                Health_Color = EffectIsHere.Instance.Health_Color_Freeze;
                break;
            default:
                typeElement = TypeElementEnemy.None;
                Health_Color = EffectIsHere.Instance.Health_Color_Default;
                break;
        }
    }
    void MienNhiem(Color color)
    {
        ShowMienNhiem mienhiem = Instantiate(EffectIsHere.Instance.ShowMienNhiem) as ShowMienNhiem;
        mienhiem.Set(PosText3D.transform.position, "Miễn nhiễm", color);
    }


    // Xử lý với tấn công Player

    // Xử lý di chuyển
    void Moveto(Vector3 a)
    {
        if (nav.SetDestination(a))
        {
            moving = true;
            SetAnimationMove(true);
        }
    }

    protected virtual void UpdateMove()
    {
        if (dead) {
            nav.ResetPath();
            return;
        }
        if (Time.time - time_lastMoved > Time_Relax && !moving)
        {
            des = MyPoint.Instance.getOnePoint(1, gameObject.transform.position, 50);
            des = GameController.FixedPosByNavMesh(des);
            Moveto(des);
        }
        bool done = Vector3.Distance(des, transform.position) < nav.stoppingDistance;
        if (done && moving)
        {
            time_lastMoved = Time.time;
            moving = false;
            SetAnimationMove(false);
        }
    }

    protected virtual void SetAnimationMove(bool a)
    {
        anim.SetBool("Move", a);
    }
}
