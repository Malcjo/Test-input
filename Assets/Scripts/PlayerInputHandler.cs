using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    public bool ready = false;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Player player;
    [SerializeField] private int PlayerIndex;

    [SerializeField] Scene currentScene;
    [SerializeField] Scene menuScene;
    GameObject playerCharacter = null;
    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        menuScene = SceneManager.GetSceneByBuildIndex(0);
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(playerCharacter == null)
        {
            if(SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByBuildIndex(1).buildIndex)
            {
                currentScene = SceneManager.GetActiveScene();
                StartGame();
            }
        }
    }

    public void MoveInput(CallbackContext context)
    {
        if(player != null)
        {
            player.Input = context.ReadValue<Vector2>();
            player.GetMoveInput(context);
        }
    }
    public void StartGame()
    {
        playerCharacter = Instantiate(playerPrefab);
        player = playerCharacter.GetComponent<Player>();
    }
    public void SetInput(PlayerInput input)
    {
        this.playerInput = input;
    }

    public void OnJump(CallbackContext context)
    {
        if (player != null)
        {
            player.Test();
        }
    }
}
