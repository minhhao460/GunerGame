using UnityEngine;

public class LivingOB : MonoBehaviour
{

    [HideInInspector]
    public enum TypeLiving { Player, Enemy };
    public TypeLiving Keeper;
    public float StartHealth;
    public int StartMana;
    public float MoveSpeedStart;
    public float StartShield;


    // TextDamage3D
    public GameObject PosText3D;
    public float PosLechText3D;

    // ShowHead
    public Transform PosShowHealth;
    protected ShowHealth showHealth;
    protected Color Health_Color;


    protected float Health;
    protected int Mana;
    protected float MoveSpeed;
    protected float Shield;
    protected bool dead;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Health = StartHealth;
        Mana = StartMana;
        Shield = StartShield;
        MoveSpeed = MoveSpeedStart;
        ShowHealth();
    }

    protected virtual void TakeHit(int damage)
    {
        if (dead) return;
        Health -= damage;
        if (Health <= 0)
        {
            dead = true;
            Die();
        }
        showHealth.SetHealth(Health);
    }

    protected virtual void Die()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    protected void TakeHit(int damage, Color color)
    {
        if (dead) return;
        TakeHit(damage);
        HienThiDamage(damage, color);
    }

    protected void HienThiDamage(int damage, Color color)
    {
        Vector3 offset = new Vector3(Random.Range(-PosLechText3D, PosLechText3D), 0, Random.Range(-PosLechText3D, PosLechText3D)) + PosText3D.transform.position;
        FloatingText text3D = Instantiate(EffectIsHere.Instance.ShowDamage) as FloatingText;
        text3D.Set(offset, damage.ToString(), color);
    }

    protected virtual void ShowHealth() {
        showHealth = Instantiate(EffectIsHere.Instance.ShowHealth, PosShowHealth) as ShowHealth;
        showHealth.SetAll(StartHealth, Health, Health_Color);
    }
    void DesTroyThis()
    {
        Destroy(gameObject);
    }
}
