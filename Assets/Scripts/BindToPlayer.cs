using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BindToPlayer : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    [SerializeField] private PlayerJoinHandler join = null;

    public GameObject events = null;

    Scene currentScene;
    Scene menuScene;
    public void JoinGame(PlayerInput input)
    {
        int i = input.playerIndex;
        players.Add(input.gameObject);
        GameManager.instance.NumberOfPlayers.Add(input.gameObject);
        input.gameObject.GetComponent<PlayerInputHandler>().SetInput(input);
        input.gameObject.GetComponent<PlayerInputHandler>().SetPlayerIndex(i);
        DontDestroyOnLoad(input.gameObject);
    }

    private void OnEnable()
    {
        menuScene = SceneManager.GetSceneByBuildIndex(0);
        currentScene = SceneManager.GetActiveScene();

        if(currentScene != SceneManager.GetActiveScene())
        {
            currentScene = SceneManager.GetActiveScene();
        }

        if(currentScene == menuScene)
        {
            join.SetPlayerBind(this);
        }
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene() == menuScene)
        {
            if(GameManager.instance.GetPlayer1Ready() == true && GameManager.instance.GetPlayer2Ready() == true)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    public void ReadyPlayer()
    {
        GameManager.instance.ReadyPlayer();
    }
}
