using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance { get; private set; }

    [HideInInspector]
    public enum TypeDan { None, Choang, Lua, Doc, Bang };

    // Fire
    public Color color_Lua = Color.red;
    public float Lua = 0.4f;
    public float Timedelay_Lua = 0.5f;
    public float dama_everyTime_Lua = 0.05f;
    public float TiLe_Lua = 0.3f;


    // Poison
    public Color color_Doc = Color.green;
    public float Doc = 0.6f;
    public float TimeDelay_Doc = 2f;
    public float dama_everyTime_Doc = 0.2f;
    public float Tile_Doc = 0.4f;

    // Stun
    public Color color_Choang = Color.yellow;
    public float Time_Choang = 3f;
    public float TiLe_Choang = 0.3f;

    // Freeze
    public Color color_Bang = Color.blue;
    public float Time_Bang = 5f; // Thời gian đóng băng
    public float Tile_Bang = 1;
    public float Tile_DeMove = 0.5f;

    public Color color_Default = new Color(5.2f, 2.2f, 1.2f);

    private void Awake()
    {
            Instance = this;
    }
}
