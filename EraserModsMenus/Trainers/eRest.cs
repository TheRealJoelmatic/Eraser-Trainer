using System.Collections;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace EraserModsMenus.Trainers
{
    public class eRest
    {
        public IEnumerator Rest()
        {
            MelonLogger.Msg("restarting");
            SceneManager.LoadScene(0);
            yield return new WaitForSeconds(0.001f);

            GameObject scriptsObject = GameObject.Find("scripts");
            if (scriptsObject != null)
            {
                MainMenu mainMenu = scriptsObject.GetComponent<MainMenu>();

                mainMenu.ConfirmDelete();
                SceneManager.LoadScene(1);
                MelonLogger.Msg("done 1");
            }
            else
            {
                MelonLogger.Error("Scripts object not found!");
            }
        }
    }
}
