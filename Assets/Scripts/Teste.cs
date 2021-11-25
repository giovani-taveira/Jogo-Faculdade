using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
    Vector3 LookPos;
    Animator anim;
    Vector3 move;
    Vector3 moveInput;

    float forwardAmount;
    float turnAmount;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetupAnimator();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        move = vertical * Vector3.forward + horizontal * Vector3.right; 

        if(move.magnitude > 1)
        {
            move.Normalize();
        }

        Move(move);

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.AddForce(movement * speed / Time.deltaTime);
        //transform.TransformPoint(movement * speed * Time.deltaTime);
        // anim.SetFloat("Vertical", vertical);
        // anim.SetFloat("Horizontal", horizontal);

    }

    void Update()
    {
        Ray  ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 100))
        {
            LookPos = hit.point;
        }

        Vector3 lookDir = LookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);

        ConvertMoveInput();
        UpdateAnimator();

    }

    void SetupAnimator()
    {
        anim = GetComponent<Animator>();

        foreach(var childAnimator in GetComponentsInChildren<Animator>())
        {
            if(childAnimator != anim)
            {
                anim.avatar = childAnimator.avatar;
                Destroy(childAnimator);
                break;
            }
        }
    }

    void Move(Vector3 move)
    {
        if(move.magnitude > 1)
        {
            move.Normalize();
        }

        this.moveInput = move;
    }

    void ConvertMoveInput()
    {
        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;
        forwardAmount = localMove.z;

    }

    void UpdateAnimator()
    {
        anim.SetFloat("Horizontal", forwardAmount, 0.1f, Time.deltaTime);
        anim.SetFloat("Vertical", turnAmount, 0.1f, Time.deltaTime);

    }
}
