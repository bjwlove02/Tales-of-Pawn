using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathProblem
{ 

    private static MathProblem p_instance=null;
    public static MathProblem Instance()
    {
        if(p_instance == null)
        {
            p_instance=new MathProblem();
        }
        return p_instance;
    }
    public void angleCal(Transform targetTr, Vector3 moveDir)
    {
        float angle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
        targetTr.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}

