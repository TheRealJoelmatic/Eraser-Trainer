using MelonLoader;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using EraserModsMenus.Menus;

namespace EraserModsMenus.Trainers
{
    public class teleportPlayer
    {
        SplatInterceptor splat = new SplatInterceptor();
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
                splat.SplatFixer();
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
            tpPlayer(new Vector3(5f, 1.22f, 5f));
            yield return new WaitForSeconds(2.5f);
            tpPlayer(new Vector3(4.4445f, 208.22f, 24.4925f));
            yield return new WaitForSeconds(2.5f);
            tpPlayer(new Vector3(4.4445f, 470.22f, 24.4925f));
            yield return new WaitForSeconds(2.5f);
            tpPlayer(new Vector3(18.4745f, 386.22f, 12.5002f));
        }
    }
}
