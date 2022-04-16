using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2;

    private bool positiveXMovement = true;
    private bool positiveYMovement = true;
  
 
    private void Awake()
    {
        int randomNumber = Random.Range(0, 3);

        switch (randomNumber)
        {
            case 0: 
                positiveXMovement = false;
                positiveYMovement = false;
                break;
            case 1:
                positiveXMovement=true;
                positiveYMovement=false;
                break;
            case 2:
                positiveXMovement=false;
                positiveYMovement=true;
                break;
            default:
                positiveXMovement=true;
                positiveYMovement =true;
                break;
        }
    }

    private void Update()
    {
        CalculateXDirection();
        CalculateYDirection();
        TransformPosition();
    }

    void CalculateXDirection()
    {
        if (transform.position.x > 8.25f)
        {
            positiveXMovement = false;
        }
        else if (transform.position.x < -8.1)
        {
            positiveXMovement = true;
        }
    }

    void CalculateYDirection()
    {
        if (transform.position.y > 3.8f)
        {
            positiveYMovement = false;
        }
        else if (transform.position.y < -3.8)
        {
            positiveYMovement = true;
        }
    }

    private void TransformPosition()
    {
        if(positiveYMovement && positiveXMovement)
        {
            transform.Translate((Vector2.right + Vector2.up) * movementSpeed * Time.deltaTime);
        }
        else if(!positiveYMovement && positiveXMovement)
        {
            transform.Translate((Vector2.right - Vector2.up) * movementSpeed * Time.deltaTime);
        }
        else if(positiveYMovement && !positiveXMovement)
        {
            transform.Translate((-Vector2.right + Vector2.up) * movementSpeed * Time.deltaTime);
        }
        else if (!positiveYMovement && !positiveXMovement)
        {
            transform.Translate((-Vector2.right - Vector2.up) * movementSpeed * Time.deltaTime);
        }
    }

}
