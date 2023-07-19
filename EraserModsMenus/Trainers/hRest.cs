using System.Collections;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace EraserModsMenus.Trainers
{
    public class hRest
    {
        public IEnumerator Rest()
        {
            MelonLogger.Msg("Started");
            SceneManager.LoadScene(0);
            yield return new WaitForSeconds(0.001f);
            MelonLogger.Msg("In scene looking for scripts");
            GameObject scriptsObject = GameObject.Find("scripts");
            GameObject playHardButton = GameObject.Find("play hard button");
            if (scriptsObject != null && playHardButton != null)
            {
                MelonLogger.Msg("Found and running functions");
                MainMenu mainMenu = scriptsObject.GetComponent<MainMenu>();

                mainMenu.ConfirmDelete();
                playHardButton.GetComponent<Button>().onClick.Invoke();
                MelonLogger.Msg("done 2");
            }
            else
            {
                MelonLogger.Msg("Scripts object not found!");
            }
        }
    }
}
