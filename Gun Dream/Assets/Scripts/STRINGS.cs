﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STRINGS : MonoBehaviour
{
    public static STRINGS Instance { get; private set; }
    public enum He{ None, AnhSang, Lua, Doc, Bang, TongHop}
    public enum Name { LucAnhSang, LucLua, LucDoc, LucBang, AK47, M4A1, MP5, LucLac};
    // Name and Info and
    [SerializeField]
    private Name[] nameOfGun;
    [SerializeField]
    private He[] he;

    private string[] nameOfGunQ;
    private string[] infoOfGunQ;
    private string[] heQ;
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Set();
    }

    public string getNameOfGun(Name name)
    {
        for (int i = 0; i < nameOfGun.Length; i++)
        {
            if (nameOfGun[i] == name)
            {
                return getNameOfGun(i);
            }
        }
        Debug.LogWarning("Tên: " + name + " không được tìm thấy");
        return null;
    }
    public string getNameOfGun(int index)
    {
        if (nameOfGunQ[index] != null)
            return nameOfGunQ[index];
        Debug.LogWarning("Không tồn tại tên súng: " + nameOfGun[index]);
        return null;
    }
    public string getInfoOfGun(Name name)
    {
        for (int i = 0; i < nameOfGun.Length; i++)
        {
            if (nameOfGun[i] == name)
            {
                return getInfoOfGun(i);
            }
        }
        Debug.LogWarning("Tên: " + name + " không được tìm thấy");
        return null;
    }
    public string getInfoOfGun(int index)
    {
        if (infoOfGunQ[index] != null)
            return infoOfGunQ[index];
        Debug.LogWarning("Không tồn tại thông tin súng: " + nameOfGun[index]);
        return null;
    }
    public string getHeOfGun(He he)
    {
        for (int i = 0; i < this.he.Length; i++)
        {
            if (he == this.he[i])
            {
                return getHeoOfGun(i);
            }
        }
        Debug.LogWarning("Hệ súng: " + he.ToString() + " không được tìm thấy");
        return null;
    }
    public string getHeoOfGun(int index)
    {
        if (heQ[index] != null)
            return heQ[index];
        Debug.LogWarning("Không tồn tại thông tin hệ súng theo mã code: " + he[index]);
        return null;
    }

    void Set()
    {
        nameOfGunQ = new string[8];
        infoOfGunQ = new string[8];
        heQ = new string[6];
        nameOfGunQ[0] = "Lục Ánh Sáng";
        nameOfGunQ[1] = "Lục Lửa";
        nameOfGunQ[2] = "Lục Độc";
        nameOfGunQ[3] = "Lục Băng";
        nameOfGunQ[4] = "AK-47";
        nameOfGunQ[5] = "M4A1";
        nameOfGunQ[6] = "MP5";
        nameOfGunQ[7] = "Lục Lạc";

        infoOfGunQ[0] = "Một cây súng lục bình thường.";
        infoOfGunQ[7] = "Một cây súng lục đặc biệt.";
        infoOfGunQ[1] = "Một cây súng lục bình thường.";
        infoOfGunQ[2] = "Một cây súng lục bình thường.";
        infoOfGunQ[3] = "Một cây súng lục bình thường.";
        infoOfGunQ[4] = "Một loại súng máy mạnh mẽ.";
        infoOfGunQ[5] = "Là nổi khiếp sợ của rất nhiều quái vật vì độ chính xác cao.";
        infoOfGunQ[6] = "Sở hữu tốc độ bắn cao khiến quái vật không kịp né.";

        heQ[0] = "Không sở hữu hệ nào cả.";
        heQ[1] = "Hệ Ánh Sáng: Mục tiêu có thể bị choáng khi trúng đạn.";
        heQ[2] = "Hệ Lửa: Mục tiêu có thể bị thiêu đốt khi trúng đạn.";
        heQ[3] = "Hệ Độc: Mục tiêu có thể bị nhiễm độc khi trúng đạn.";
        heQ[4] = "Hệ Băng: Mục tiêu sẽ bị làm chậm khi trúng đạn.";
        heQ[5] = "Hệ: Bao gồm cả 4 hệ Ánh Sáng - Lửa - Độc - Băng.";
    }
}
