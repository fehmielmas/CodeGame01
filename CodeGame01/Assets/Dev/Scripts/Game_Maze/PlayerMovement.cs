using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    void Start()
    {
        PrintInstructions();
    }
    void Update()
    {
        MovePlayer();
    }
    void PrintInstructions()
    {
        Debug.Log("Welcome to the game !");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls !");
    }
    // player movement
    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,0,zValue);
    }
    
}
