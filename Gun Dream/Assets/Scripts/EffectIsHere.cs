using UnityEngine;

public class EffectIsHere : MonoBehaviour
{
    public static EffectIsHere Instance { get; private set; }
    public FloatingText ShowDamage;
    public ShowHealth ShowHealth;
    public ShowMienNhiem ShowMienNhiem;
    public GetGunFromMap GunSpawner;
    public GameObject[] Effect;
    [SerializeField]
    private string[] codeEF;
    public Color[] HealthColor;
    [SerializeField]
    private string[] codeHealthColor;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject SpawnEffect(GameObject ob, Transform pr, bool subofpr)
    {
        if (ob == null)
        {
            Debug.LogWarning("Effect đang làm giá trị null");
            return null;
        }
        if (pr == null)
        {
            Debug.LogWarning("Transform đang làm giá trị null");
            return null;
        }
        return Instantiate(ob, pr, !subofpr);
    }
    public GameObject SpawnEffect(GameObject ob, Transform pr, bool subofpr, float timeToDestroy)
    {
        if (ob == null)
        {
            Debug.LogWarning("Effect đang làm giá trị null");
            return null;
        }
        if (pr == null)
        {
            Debug.LogWarning("Transform đang làm giá trị null");
            return null;
        }
        GameObject a = Instantiate(ob, pr, !subofpr);
        Destroy(a, timeToDestroy);
        return a;
    }
    public GameObject getEffect(string code)
    {
        for (int i = 0; i < codeEF.Length; i++)
        {
            if (code == codeEF[i])
            {
                return getEffect(i);
            }
        }
        Debug.LogWarning("Khong ton tai ma CodeHealth " + code + " hoặc danh sách trống");
        return null;
    }
    public GameObject getEffect(int code)
    {
        return Effect[code];
    }
    public Color getHealthColor(string code)
    {
        for (int i = 0; i < codeHealthColor.Length; i++)
        {
            if (code.Equals(codeHealthColor[i]))
            {
                return getHealthColor(i);
            }
        }
        Debug.LogWarning("Khong ton tai ma CodeHealth " + code + " hoặc danh sách trống");
        return new Color();
    }
    public Color getHealthColor(int code)
    {
        return HealthColor[code];
    }

}
