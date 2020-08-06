using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EffectIsHere : MonoBehaviour
{
    public static EffectIsHere Instance { get; private set; }
    public FloatingText ShowDamage;
    public ShowHealth ShowHealth;
    public ShowMienNhiem ShowMienNhiem;
    public GetGunFromMap GunSpawner;
    [SerializeField]
    private Effect[] effect;
    [SerializeField]
    private ColorOfHealth[] colorOfHealth;
    #region Class
    [Serializable]
    public class ColorOfHealth
    {
        public string code;
        public Color color;
    }
    [Serializable]
    public class Effect
    {
        public string code;
        public GameObject effect;
    }
    #endregion
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
        for (int i = 0; i < effect.Length; i++)
        {
            if (code == effect[i].code)
            {
                return getEffect(i);
            }
        }
        Debug.LogWarning("Khong ton tai ma CodeHealth " + code + " hoặc danh sách trống");
        return null;
    }
    public GameObject getEffect(int code)
    {
        return effect[code].effect;
    }
    public Color getHealthColor(string code)
    {
        for (int i = 0; i < colorOfHealth.Length; i++)
        {
            if (code == colorOfHealth[i].code)
            {
                return getHealthColor(i);
            }
        }
        Debug.LogWarning("Khong ton tai ma CodeHealth " + code + " hoặc danh sách trống");
        return new Color();
    }
    public Color getHealthColor(int code)
    {
        return colorOfHealth[code].color;
    }

}
