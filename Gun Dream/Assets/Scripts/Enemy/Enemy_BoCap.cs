using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BoCap : Enemy
{
    public GameObject boxcollider;

    protected override void setLayer(string a)
    {
        boxcollider.layer = LayerMask.NameToLayer(a);
    }
}
