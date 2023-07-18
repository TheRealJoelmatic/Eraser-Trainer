using MelonLoader;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EraserModsMenus.Menus
{
    public class Menu
    {

        public void CreateGUI(Options options)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (options.isMenuShown)
            {
                float boxWidth = 300;
                float boxHeight = 320;
                float boxX = (Screen.width - boxWidth) / 2;
                float boxY = (Screen.height - boxHeight) / 2;
                Rect boxRect = new Rect(boxX, boxY, boxWidth, boxHeight);

                // Make a background box
                GUI.skin.box.fontSize = 15;
                GUI.Box(boxRect, "Eraser Trainer - Made by Joelmatic#8817");

                // Calculate the position and size of the first button
                float buttonWidth = 200;
                float buttonHeight = 30;
                float buttonX = (boxWidth - buttonWidth) / 2;
                float buttonY = 40;
                Rect buttonRect1 = new Rect(boxX + buttonX, boxY + buttonY, buttonWidth, buttonHeight);

                // Draw the first button
                if (options.isEorH)
                {
                    if (GUI.Button(buttonRect1, "Set quick rest to easy mode"))
                    {
                        options.isEorH = false;
                    }
                }
                else
                {
                    if (GUI.Button(buttonRect1, "Set quick rest to hard mode"))
                    {
                        options.isEorH = true;
                    }
                }

                if (sceneIndex == 1)
                {

                    // Calculate the position and size of the second button
                    float buttonX2 = (boxWidth - buttonWidth) / 2;
                    float buttonY2 = 80;
                    Rect buttonRect2 = new Rect(boxX + buttonX2, boxY + buttonY2, buttonWidth, buttonHeight);

                    // Draw the second button
                    if (GUI.Button(buttonRect2, "Spawn Point"))
                    {
                        tpPlayer(new Vector3(5f, 1.22f, 5f));
                    }

                    // Calculate the position and size of the second button
                    float buttonX3 = (boxWidth - buttonWidth) / 2;
                    float buttonY3 = 120;
                    Rect buttonRect3 = new Rect(boxX + buttonX3, boxY + buttonY3, buttonWidth, buttonHeight);

                    // Draw the second button
                    if (GUI.Button(buttonRect3, "Cannon Room"))
                    {
                        tpPlayer(new Vector3(28.8316f, 103.22f, 22.3747f));
                    }

                    // Calculate the position and size of the second button
                    float buttonX4 = (boxWidth - buttonWidth) / 2;
                    float buttonY4 = 160;
                    Rect buttonRect4 = new Rect(boxX + buttonX4, boxY + buttonY4, buttonWidth, buttonHeight);

                    // Draw the second button
                    if (GUI.Button(buttonRect4, "Bird Room"))
                    {
                        tpPlayer(new Vector3(18.3064f, 215.22f, 13.7295f));
                    }

                    // Calculate the position and size of the second button
                    float buttonX5 = (boxWidth - buttonWidth) / 2;
                    float buttonY5 = 200;
                    Rect buttonRect5 = new Rect(boxX + buttonX5, boxY + buttonY5, buttonWidth, buttonHeight);

                    // Draw the second button
                    if (GUI.Button(buttonRect5, "Caution"))
                    {
                        tpPlayer(new Vector3(28.2139f, 283.22f, 12.6936f));
                    }

                    // Calculate the position and size of the second button
                    float buttonX6 = (boxWidth - buttonWidth) / 2;
                    float buttonY6 = 240;
                    Rect buttonRect6 = new Rect(boxX + buttonX6, boxY + buttonY6, buttonWidth, buttonHeight);

                    // Draw the second button
                    if (GUI.Button(buttonRect6, "Safe Room"))
                    {
                        tpPlayer(new Vector3(4.4445f, 208.22f, 24.4925f));
                    }

                    // Calculate the position and size of the second button
                    float buttonX7 = (boxWidth - buttonWidth) / 2;
                    float buttonY7 = 280;
                    Rect buttonRect7 = new Rect(boxX + buttonX7, boxY + buttonY7, buttonWidth, buttonHeight);

                    // Draw the second button
                    if (GUI.Button(buttonRect7, "Noah's Arms"))
                    {
                        MelonCoroutines.Start(NoahsArms());
                    }
                }
            }
        }
        public void tpPlayer(Vector3 newPosition)
        {
            GameObject playerObject = GameObject.Find("player");
            if (playerObject != null)
            {
                MelonLogger.Msg("Starting tp");

                // Get the player's transform component
                Transform playerTransform = playerObject.transform;

                // Get the player's collider component
                Collider playerCollider = playerObject.GetComponent<Collider>();

                // Disable the collider temporarily
                if (playerCollider != null)
                {
                    playerCollider.enabled = false;
                }

                // Start the movement coroutine
                MelonCoroutines.Start(MovePlayerSmoothly(playerTransform, newPosition, playerCollider));

                MelonLogger.Msg("Tp initiated");
            }
            else
            {
                MelonLogger.LogError("Player object not found.");
            }
        }

        private IEnumerator MovePlayerSmoothly(Transform playerTransform, Vector3 targetPosition, Collider playerCollider)
        {
            float moveDuration = 1.0f; // Duration of the movement in seconds
            float elapsedTime = 0f;

            Vector3 initialPosition = playerTransform.position;

            while (elapsedTime < moveDuration)
            {
                // Calculate the normalized time value (0 to 1)
                float t = elapsedTime / moveDuration;

                // Interpolate the position smoothly
                playerTransform.position = Vector3.Lerp(initialPosition, targetPosition, t);

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            // Set the final position precisely
            playerTransform.position = targetPosition;

            // Re-enable the collider, if necessary
            if (playerCollider != null)
            {
                playerCollider.enabled = true;
            }

            MelonLogger.Msg("Tp complete");
        }

        private IEnumerator NoahsArms()
        {
            tpPlayer(new Vector3(4.4445f, 208.22f, 24.4925f));
            yield return new WaitForSeconds(2.5f);
            tpPlayer(new Vector3(4.4445f, 500.22f, 24.4925f));
            yield return new WaitForSeconds(2.5f);
            tpPlayer(new Vector3(18.4745f, 386.22f, 12.5002f));
        }
    }
}