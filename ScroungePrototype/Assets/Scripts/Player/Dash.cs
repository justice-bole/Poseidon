using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool IsDashing = false;

    [SerializeField] private float dashForce = 100f;
    [SerializeField] private float dashCooldown = 5f;
    [SerializeField] private float dashDuration = 1;
    private Transform dashPoint;

    private bool canDash = true;
    private Rigidbody2D rb;
    private PlayerController playerController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        dashPoint = GameObject.Find("DashPoint").transform;
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canDash)
            {
                StartCoroutine(DashCooldownCoroutine());
                DoDash();
            }
        }
    }

    private void DoDash()
    {
        var lerpDashForce = Mathf.Lerp(1, dashForce, .9f);
        //rb.AddForce(dashPoint.right.normalized * dashForce * Time.deltaTime);
        rb.velocity = dashPoint.right.normalized * lerpDashForce * Time.deltaTime;
    }

    IEnumerator DashCooldownCoroutine()
    {
        IsDashing = true;
        yield return new WaitForSeconds(dashDuration);
        canDash = false;
        IsDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
