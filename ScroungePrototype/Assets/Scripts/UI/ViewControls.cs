using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControls : MonoBehaviour
{
    private Animator leftClick, rightClick, w, a, s, d, spaceBar, playerShoot, playerEat, playerMove, playerClear;
    private GameObject titleScreenUI, controlsScreenUI, playerMoveImage;
    private Vector3 originalPosition;

    private void Awake()
    {
        titleScreenUI = GameObject.Find("TitleScreenUI");
        controlsScreenUI = GameObject.Find("ControlsScreenUI");
    }

    private void Start()
    {
        leftClick = GameObject.Find("LeftClick").GetComponent<Animator>();
        rightClick = GameObject.Find("RightClick").GetComponent<Animator>();

        w = GameObject.Find("W").GetComponent<Animator>();
        a = GameObject.Find("A").GetComponent<Animator>();
        s = GameObject.Find("S").GetComponent<Animator>();
        d = GameObject.Find("D").GetComponent<Animator>();

        spaceBar = GameObject.Find("SpaceBar").GetComponent<Animator>();

        playerShoot = GameObject.Find("PlayerShootClip").GetComponent<Animator>();
        playerEat = GameObject.Find("PlayerEatClip").GetComponent<Animator>();
        playerMove = GameObject.Find("PlayerMoveClip").GetComponent<Animator>();
        playerMoveImage = GameObject.Find("PlayerMoveClip");
        playerClear = GameObject.Find("PlayerClearClip").GetComponent<Animator>();

        controlsScreenUI.SetActive(false);

        originalPosition = playerMoveImage.transform.position;
    }

    private void Update()
    {
        var position = playerMoveImage.transform.position;
        var x = playerMoveImage.transform.position.x;
        var y = playerMoveImage.transform.position.y;

        if (Input.GetMouseButton(0))
        {
            leftClick.SetBool("isLeftClickDown", true);
            playerShoot.SetBool("isPlayerShooting", true);
        }
        else
        {
            leftClick.SetBool("isLeftClickDown", false);
            playerShoot.SetBool("isPlayerShooting", false);
        }

        if (Input.GetMouseButton(1))
        {
            rightClick.SetBool("isRightClickDown", true);
            playerEat.SetBool("isPlayerEating", true);
        }
        else
        {
            rightClick.SetBool("isRightClickDown", false);
            playerEat.SetBool("isPlayerEating", false);
        }

        if(Input.GetKey(KeyCode.W))
        {
            w.SetBool("isWPressed", true);
            if(position.y <= originalPosition.y + 10)
            playerMoveImage.transform.position = new Vector3(x, y + 20 * Time.deltaTime, 0);
        }
        else
        {
            w.SetBool("isWPressed", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            a.SetBool("isAPressed", true);
            if (position.x >= originalPosition.x - 10)
                playerMoveImage.transform.position = new Vector3(x - 20 * Time.deltaTime, y, 0);
        }
        else
        {
            a.SetBool("isAPressed", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            s.SetBool("isSPressed", true);
            if (position.y >= originalPosition.y - 10)
                playerMoveImage.transform.position = new Vector3(x, y - 20 * Time.deltaTime, 0);
        }
        else
        {
            s.SetBool("isSPressed", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            d.SetBool("isDPressed", true);
            if(position.x <= originalPosition.x + 10)
            playerMoveImage.transform.position = new Vector3(x + 20 * Time.deltaTime, y, 0);
        }
        else
        {
            d.SetBool("isDPressed", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            spaceBar.SetBool("isSpaceBarDown", true);
            playerClear.SetBool("isPlayerClear", true);
        }
        else
        {
            spaceBar.SetBool("isSpaceBarDown", false);
            playerClear.SetBool("isPlayerClear", false);
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            playerMove.SetBool("isPlayerMoving", true);
        }
        else
        {
            playerMove.SetBool("isPlayerMoving", false);
        }

    }

    public void ShowTitleScreen()
    {
        if (titleScreenUI != null)
        {
            titleScreenUI.SetActive(true);
        }
    }

    public void HideTitleScreen()
    {
        if (titleScreenUI != null)
        {
            titleScreenUI.SetActive(false);
        }
    }

    public void ShowControlsScreen()
    {
        if(controlsScreenUI != null)
        {
            controlsScreenUI.SetActive(true);
            HideTitleScreen();
        }
    }

    public void HideControlsScreen()
    {
        if(controlsScreenUI != null)
        {
           controlsScreenUI.SetActive(false);
            ShowTitleScreen();
        }
    }    

}
