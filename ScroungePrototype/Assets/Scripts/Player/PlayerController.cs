using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 MousePos;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mousePlayerDeadZone = 0.5f;
    private Camera cam;
    private Dash dash;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        dash = GetComponent<Dash>();
        spriteRenderer = GameObject.Find("PlayerAnimation").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        DefineMovement();
        GetMousePosition();
        FlipSpriteY();
    }

    private void FixedUpdate()
    {

        FixedMove();
        if (CalculateMouseDistance() < mousePlayerDeadZone) return; //optional deadzone
        
        FaceMousePosition();
    }

    private void DefineMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedMove()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void GetMousePosition()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private float CalculateMouseDistance()
    {
        float mouseDistance = Vector2.Distance(transform.position, MousePos);
        return mouseDistance;
    }

    private void FaceMousePosition()
    {
        Vector3 lookDir = MousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void FlipSpriteY() //prevent sprite from swimming on its back
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }

}
