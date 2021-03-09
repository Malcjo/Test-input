using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class UIInput : MonoBehaviour
{

    public Vector2 Input;
    private PlayerInputHandler inputHandler;

    private void Update()
    {
        MoveButtonSelected();
    }

    public void GetUIMoveInput(CallbackContext context)
    {
        Input = context.ReadValue<Vector2>();
    }

    public void AssignInputHandler(PlayerInputHandler handler)
    {
        inputHandler = handler;
    }

    private void MoveButtonSelected()
    {
        if (Input.x == 1)//Right
        {
            print("player" + inputHandler.GetPlayerIndex() + "right");
        }
        if (Input.x == -1) //left
        {
            print("player" + inputHandler.GetPlayerIndex() + "left");
        }
        if (Input.y == 1) // up
        {
            print("player" + inputHandler.GetPlayerIndex() + "up");
        }
        if (Input.y == -1)//down
        {
            print("player" + inputHandler.GetPlayerIndex() + "down");
        }
    }
}
