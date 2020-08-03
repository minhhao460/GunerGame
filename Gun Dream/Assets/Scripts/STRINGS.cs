using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STRINGS : MonoBehaviour
{
    public static STRINGS Instance { get; private set; }

    [HideInInspector]
    public string SungLuc_InfoChoang = "Hệ Ánh Sáng: Mục tiêu có thể bị choáng khi trúng đạn.";
    [HideInInspector]
    public string SungLuc_InfoLua = "Hệ Lửa: Mục tiêu có thể bị thiêu đốt khi trúng đạn.";
    [HideInInspector]
    public string SungLuc_InfoDoc = "Hệ Độc: Mục tiêu có thể bị nhiễm độc khi trúng đạn.";
    [HideInInspector]
    public string SungLuc_InfoBang = "Hệ Băng: Mục tiêu sẽ bị làm chậm khi trúng đạn.";
    [HideInInspector]
    public string InfoNone = "Không sở hữu hệ nào cả.";

    [HideInInspector]
    public string SungLuc_Name_Doc = "Lục Độc";
    [HideInInspector]
    public string SungLuc_Name_Choang = "Lục Ánh Sáng";
    [HideInInspector]
    public string SungLuc_Name_Lua = "Lục Lửa";
    [HideInInspector]
    public string SungLuc_Name_Băng = "Lục Băng";
    [HideInInspector]

    public string SungLuc_Info = "Một cây súng lục bình thường";
    [HideInInspector]

    public string SungTr_AK47_Info = "Một loại súng máy mạnh mẽ";
    [HideInInspector]
    public string SungTr_AK47_Name = "AK-47";
    void Awake()
    {
        Instance = this;
    }
}
