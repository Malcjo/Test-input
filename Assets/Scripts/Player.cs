using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    private float speed = 5;
    public Vector2 Input;
    [SerializeField] private GameObject PlayerPrefab = null;
    [SerializeField] private int playerIndex = 0;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 DisplayVelocity;


    public void Test()
    {
        Debug.Log("Test Jump: " + GetPlayerIndex());
    }
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    public void SetPlayerIndex(int var)
    {
        playerIndex = var;
    }


    public void GetMoveInput(CallbackContext context)
    {
        Input = context.ReadValue<Vector2>();
    }
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (rb != null)
        {
            rb.velocity = new Vector3(Input.x, 0, Input.y) * speed;
            DisplayVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        }
    }
}
