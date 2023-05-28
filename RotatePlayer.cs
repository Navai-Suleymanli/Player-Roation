using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player game object
    public float preciseness = 0.95f; // The precision threshold for player and camera alignment
    public Vector3 direction; // Unused variable
    public Vector3 CamLookDirection; // The forward direction of the camera
    public Vector3 playerLookDirection; // The forward direction of the player

    private void OnDrawGizmos()
    {
        Vector3 playerPos = player.transform.position; // Get the player's position
        playerLookDirection = player.transform.forward; // Get the player's forward direction
        CamLookDirection = transform.forward; // Get the camera's forward direction

        Gizmos.color = Color.green;
        Gizmos.DrawLine(playerPos, playerPos + playerLookDirection); // Draw a green line representing the player's forward direction
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(playerPos, playerPos + CamLookDirection); // Draw a blue line representing the camera's forward direction
    }

    void Update()
    {
        bool backPressed = Input.GetKey(KeyCode.S) ? true : false; // Check if the S key is being pressed (unused)

        Vector3 playerLookDirection = player.transform.forward; // Get the player's forward direction
        Vector3 CamLookDirection = transform.forward; // Get the camera's forward direction

        float DotProduct = Vector3.Dot(playerLookDirection, CamLookDirection); // Calculate the dot product of player and camera forward directions

        bool isLooking = DotProduct > preciseness; // Check if the dot product exceeds the precision threshold

        if (!isLooking && Input.GetKey(KeyCode.Mouse1)) // If the player is not looking in the same direction as the camera and the right mouse button is being held
        {
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(player.transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y, player.transform.rotation.eulerAngles.z), Time.deltaTime * 15f);
            // Interpolate the player's rotation towards a new rotation that matches the camera's rotation on the y-axis
            // The new rotation is calculated using Euler angles, preserving the original x and z rotation values of the player
            // The interpolation occurs over time using Lerp with a speed of 15 degrees per second
        }
    }
}
