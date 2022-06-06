using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBase : MonoBehaviour
{
    public virtual void NotifyShot()
    {
        Debug.Log("Me hitearon");
    }

    public virtual void NotifyShot(float DamageTaken)
    {
        Debug.Log("Me hitearon y me quitaron " + DamageTaken + " de vida");
    }
}
