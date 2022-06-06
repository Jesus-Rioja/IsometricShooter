using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public enum WeaponUseType
    {
        Shot,
        ContinuousShot,
        Undefined,
    };

    public virtual WeaponUseType GetUseType() { return WeaponUseType.Undefined; }
    public virtual void Shot()
    {
        Debug.Log("Shot called in WeaponBase");
    }

    public virtual void StartShooting()
    {

    }

    public virtual void StopShooting()
    {

    }
}
