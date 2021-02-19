using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Player player;
    [SerializeField] private int PlayerIndex;
    private void Awake()
    {
        var Index = playerInput.playerIndex;
        PlayerIndex = playerInput.playerIndex + 1;
        player.SetPlayerIndex(PlayerIndex);
    }

    public void OnJump(CallbackContext context)
    {
        if(player != null)
        {
            player.Test();
        }
    }
    public void OnMove(CallbackContext context)
    {
        if(player != null)
        {
            player.SetInput(context.ReadValue<Vector2>());
        }
    }
}
