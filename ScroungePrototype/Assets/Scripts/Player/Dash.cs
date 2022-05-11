using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool IsDashing = false;

    [SerializeField] private float dashForce = 100f;
    [SerializeField] private float dashCooldown = 5f;
    [SerializeField] private float dashDuration = 1;

    private bool canDash = true;
    private Rigidbody2D rb;
    private PlayerController playerController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canDash)
            {
                DoDash();
                StartCoroutine(DashCooldownCoroutine());
            }
        }
    }

    private Vector2 CalculateDashDirection()
    {

        Vector2 mousePosition = playerController.MousePos;
        var dashDirection = mousePosition - rb.position;
        return dashDirection.normalized;


    }

    private void DoDash()
    {
        rb.AddForce(CalculateDashDirection() * dashForce * Time.deltaTime);
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
