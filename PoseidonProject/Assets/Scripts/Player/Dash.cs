using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public bool IsDashing = false;
    public Slider dashSlider;

    [SerializeField] private float dashForce = 100f;
    [SerializeField] private float dashCooldown = 5f;
    [SerializeField] private float dashDuration = 1f;
    private Transform dashPoint;

    private bool canDash = true;
    private float dashCDCurrent;
    private Rigidbody2D rb;
    private PlayerController playerController;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        dashPoint = GameObject.Find("DashPoint").transform;
    }

    private void Start()
    {
        dashCDCurrent = 5;
    }

    private void Update()
    {
        UpdateDashSlider();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && canDash)
        {

            StartCoroutine(DashCooldownCoroutine());
            DoDash();

        }
    }

    private void DoDash()
    {
        var lerpDashForce = Mathf.Lerp(1, dashForce, .9f);
        rb.velocity = dashPoint.right.normalized * lerpDashForce * Time.deltaTime;
    }

    private void UpdateDashSlider()
    {
        if (!IsDashing)
        {
            dashCDCurrent += Time.deltaTime;
            dashCDCurrent = Mathf.Clamp(dashCDCurrent, 0.0f, dashCooldown);
        }
        else
        {
            dashCDCurrent = 0;
        }

        dashSlider.value = dashCDCurrent / dashCooldown;
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
