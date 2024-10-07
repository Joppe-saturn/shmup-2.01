using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : Player
{
    private PlayerControls playerControls;
    private IEnumerator currentCorutine;
    [SerializeField] private float speed;

    private void Awake()
    {
        currentCorutine = lerpToPosition(transform.position, transform.position, 0);
    }

    private void Start()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();
        playerControls.Game.Shoot.performed += InputShoot;
        playerControls.Game.Movement.performed += InputMove;
    }


    private void InputShoot(InputAction.CallbackContext obj)
    {
        StartCoroutine(OutputShoot(obj));
    }

    private IEnumerator OutputShoot(InputAction.CallbackContext obj)
    {
        while (playerControls.Game.Shoot.IsPressed())
        {
            Shoot();
            yield return null;
        }
    }

    private void InputMove(InputAction.CallbackContext obj)
    {
        StartCoroutine(OutputMove(obj));
    }

    private IEnumerator OutputMove(InputAction.CallbackContext obj)
    {
        StopCoroutine(currentCorutine);
        isMoving = false;
        while (playerControls.Game.Movement.IsPressed())
        {
            if(!isMoving)
            {
                currentCorutine = lerpToPosition(transform.position, transform.position + new Vector3(obj.ReadValue<Vector2>().x / 10, 0, 0), speed);
                StartCoroutine(currentCorutine);
            }
            yield return null;
        }
        StopCoroutine(currentCorutine);
    }
}
