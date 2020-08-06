using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STRINGS : MonoBehaviour
{
    public static STRINGS Instance { get; private set; }
    public enum He{ None, AnhSang, Lua, Doc, Bang}
    public enum Name { LucAnhSang, LucLua, LucDoc, LucBang, AK47, M4A1};
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
        nameOfGunQ = new string[6];
        infoOfGunQ = new string[6];
        heQ = new string[5];
        nameOfGunQ[0] = "Lục Ánh Sáng";
        nameOfGunQ[1] = "Lục Lửa";
        nameOfGunQ[2] = "Lục Độc";
        nameOfGunQ[3] = "Lục Băng";
        nameOfGunQ[4] = "AK-47";
        nameOfGunQ[5] = "M4A1";

        infoOfGunQ[0] = "Một cây súng lục bình thường";
        infoOfGunQ[1] = "Một cây súng lục bình thường";
        infoOfGunQ[2] = "Một cây súng lục bình thường";
        infoOfGunQ[3] = "Một cây súng lục bình thường";
        infoOfGunQ[4] = "Một loại súng máy mạnh mẽ";
        infoOfGunQ[5] = "M4A1 là nổi khiếp sợ của rất nhiều quái vật";

        heQ[0] = "Không sở hữu hệ nào cả.";
        heQ[1] = "Hệ Ánh Sáng: Mục tiêu có thể bị choáng khi trúng đạn.";
        heQ[2] = "Hệ Lửa: Mục tiêu có thể bị thiêu đốt khi trúng đạn.";
        heQ[3] = "Hệ Độc: Mục tiêu có thể bị nhiễm độc khi trúng đạn.";
        heQ[4] = "Hệ Băng: Mục tiêu sẽ bị làm chậm khi trúng đạn.";
    }
}
