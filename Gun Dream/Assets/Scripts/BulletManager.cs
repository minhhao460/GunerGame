using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance { get; private set; }

    [HideInInspector]
    public enum TypeDan { None, Choang, Lua, Doc, Bang };

    // Fire
    public static Color color_Lua = Color.red;
    public static float Lua = 0.4f;
    public static float Timedelay_Lua = 0.2f;
    public static float dama_everyTime_Lua = 0.05f;
    public static float TiLe_Lua = 0.3f;


    // Poison
    public static Color color_Doc = Color.green;
    public static float Doc = 0.6f;
    public static float TimeDelay_Doc = 2f;
    public static float dama_everyTime_Doc = 0.2f;
    public static float Tile_Doc = 0.4f;

    // Stun
    public static Color color_Choang = Color.yellow;
    public static float Time_Choang = 3f;
    public static float TiLe_Choang = 0.3f;

    // Freeze
    public static Color color_Bang = Color.blue;
    public static float Time_Bang = 5f; // Thời gian đóng băng
    public static float Tile_Bang = 1;
    public static float Tile_DeMove = 0.5f;

    public static Color color_Default = new Color(255, 255, 189);

    private void Awake()
    {
            Instance = this;
    }
}
