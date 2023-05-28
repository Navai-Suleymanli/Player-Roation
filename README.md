# RotatePlayer

This script is used to align the player's rotation with the camera's rotation on the y-axis. It allows the player to smoothly rotate to match the direction the camera is facing when the right mouse button is held down.

## Dependencies

- Unity Engine (version X.X.X or higher)

## How to Use

1. Attach the `RotatePlayer` script to the player game object in your Unity scene.
2. Assign the player game object to the `player` variable in the script via the Unity Inspector.
3. Adjust the `preciseness` variable if needed. It represents the precision threshold for aligning the player and camera rotation.
4. Run the game and hold down the right mouse button to see the player rotate to match the camera's rotation on the y-axis.

## Variables

- `player`: Reference to the player game object. Assign the player game object to this variable in the Unity Inspector.
- `preciseness`: The precision threshold for player and camera alignment. Adjust this value to control how closely the player's rotation matches the camera's rotation.
- `direction`: Unused variable.
- `CamLookDirection`: The forward direction of the camera.
- `playerLookDirection`: The forward direction of the player.

## Methods

- `OnDrawGizmos()`: Draws debug lines representing the player's forward direction (green) and the camera's forward direction (blue). This is useful for visualizing the alignment of the player and camera.

## Update Logic

The `Update()` method is called every frame and contains the logic for aligning the player's rotation with the camera's rotation.

1. It checks if the S key is being pressed but the result is not used (unused variable `backPressed`).
2. It retrieves the forward direction of the player and camera.
3. It calculates the dot product of the player's forward direction and the camera's forward direction.
4. It checks if the dot product is greater than the precision threshold (`preciseness`).
5. If the player is not looking in the same direction as the camera and the right mouse button is being held, the player's rotation is interpolated towards a new rotation that matches the camera's rotation on the y-axis. The interpolation is done over time using `Quaternion.Lerp` with a speed of 15 degrees per second.

## Notes

- Make sure the player game object has a Rigidbody component attached if you want to allow physics interactions.
- Adjust the interpolation speed (`Time.deltaTime * 15f`) in the `Update()` method to achieve the desired rotation responsiveness.

## Disclaimer

This script assumes that you have a functional player and camera setup in your Unity project. It is intended as a standalone rotation alignment component and may require modification to integrate properly into your existing codebase.
