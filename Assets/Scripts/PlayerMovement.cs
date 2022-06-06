using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] bool orientateToCamera = false;
    [SerializeField] LayerMask layerMaskAimingDetection;

    CharacterController characterController;
    Animator animator;
    Vector3 movementFromInput;
    Vector3 movementOnPlane;
    float gravity = -9.8f;
    float speedY;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        UpdateMovement();
        UpdateOrientation();
    }


    void UpdateMovement()
    {
        movementFromInput = Vector3.zero;
        if(Input.GetKey(KeyCode.A)){movementFromInput += Vector3.left;}
        if(Input.GetKey(KeyCode.W)){movementFromInput += Vector3.forward;}
        if(Input.GetKey(KeyCode.S)){movementFromInput += Vector3.back;}
        if(Input.GetKey(KeyCode.D)){movementFromInput += Vector3.right;}
        movementFromInput.Normalize();

        movementOnPlane = Camera.main.transform.TransformDirection(movementFromInput);
        movementOnPlane = Vector3.ProjectOnPlane(movementOnPlane, Vector3.up);
        movementOnPlane.Normalize();

        speedY += gravity  * Time.deltaTime;
        movementOnPlane.y = speedY;
        characterController.Move(movementOnPlane * moveSpeed * Time.deltaTime);

        if(characterController.isGrounded) {speedY = 0;}   
    }


    void UpdateOrientation()
    {
        Vector3 desiredForward = Vector3.zero;
        bool performOrientation = false;
        if(orientateToCamera)
        {
            if(movementFromInput.sqrMagnitude > (0.01f * 0.01f))
            {
                desiredForward = Camera.main.transform.forward;
                performOrientation = true;
            }
        }
        else
        {
            //Asumimos orientacion hacia cursor
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskAimingDetection))
            {
                desiredForward = hit.point - transform.position;
                //desiredForward.y = transform.position.y;
                performOrientation = true;
            }
        }
        
        if(performOrientation)
        {
            desiredForward = Vector3.ProjectOnPlane(desiredForward, Vector3.up);
            desiredForward.Normalize();

            Quaternion desiredRotation = Quaternion.LookRotation(desiredForward, Vector3.up);
            Quaternion currentRotation = transform.rotation;

            transform.rotation = Quaternion.Lerp(currentRotation, desiredRotation, 0.1f);
        }

    }
}
