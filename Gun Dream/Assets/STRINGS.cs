using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STRINGS : MonoBehaviour
{
    public static STRINGS Instance { get; private set; }

    public string SungLuc_InfoChoang = "Hệ Ánh Sáng: Mục tiêu có thể bị choáng khi bị bắn.";
    public string SungLuc_InfoLua = "Hệ Lửa: Mục tiêu có thể bị thiêu đốt khi bị bắn.";
    public string SungLuc_InfoDoc = "Hệ Độc: Mục tiêu có thể bị nhiễm độc khi bị bắn.";
    public string SungLuc_InfoBang = "Hệ Băng: Mục tiêu sẽ bị làm chậm khi bị bắn.";
    public string InfoNone = "Không sở hữu hệ nào cả.";

    
    public string SungLuc_Name_Doc = "Lục Độc";
    public string SungLuc_Name_Choang = "Lục Ánh Sáng";
    public string SungLuc_Name_Lua = "Lục Lửa";
    public string SungLuc_Name_Băng = "Lục Băng";

    public string SungLuc_Info = "Một cây súng lục bình thường";
    void Awake()
    {
        Instance = this;
    }
}
