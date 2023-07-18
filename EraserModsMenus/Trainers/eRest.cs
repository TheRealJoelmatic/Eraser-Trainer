using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Diagnostics;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using EraserModsMenus.Menus;
using UnityEngine.UI;
using System.Threading.Tasks;

namespace EraserModsMenus.Trainers
{
    public class eRest
    {
        public IEnumerator Rest()
        {
            MelonLogger.Msg("restarting");
            SceneManager.LoadScene(0);
            yield return new WaitForSeconds(0.00001f);

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
                MelonLogger.LogError("Scripts object not found!");
            }
        }
    }
}
