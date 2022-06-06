using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigateToTransform : MonoBehaviour
{
    [SerializeField] Transform transformGoTo;

    NavMeshAgent navMeshAgent;
    Animator animator;
    
    // Start is called before the first frame update
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.velocity != Vector3.zero)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);

        if (transformGoTo)
        {
            navMeshAgent.SetDestination(transformGoTo.position);
        }

        FaceTarget();
    }

    void FaceTarget()
    {
        var turnToTarget = navMeshAgent.steeringTarget;

        Vector3 direction = (turnToTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

}
