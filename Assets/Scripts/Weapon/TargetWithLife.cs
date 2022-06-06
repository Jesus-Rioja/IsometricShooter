using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWithLife : TargetBase
{
    [SerializeField] bool hasPathFind = false;
    public float Life = 1f;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public override void NotifyShot(float DamageTaken)
    {
        Life -= DamageTaken;
        Debug.Log("Me han dado");


        if (Life <= 0)
        {
            anim.SetTrigger("Dead");
            Debug.Log("Me he muerto");

            GetComponent<CapsuleCollider>().enabled = false;
            if (hasPathFind) { GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true; }
            
            Invoke("Death", 2f);
            
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
