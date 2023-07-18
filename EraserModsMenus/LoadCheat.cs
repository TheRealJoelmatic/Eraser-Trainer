using EraserModsMenus.Menus;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

namespace EraserModsMenus
{
    class LoadCheat : MelonMod
    {
        Options options = new Options();

        public override void OnGUI()
        {
            Menu menu = new Menu();
            menu.CreateGUI(options);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
            options.isMenuShown = false;
        }

        public override void OnLateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                options.isMenuShown = !options.isMenuShown;
                MelonLogger.Msg($"Menu: " + options.isMenuShown);
                MelonLogger.Msg($"Hard mode: " + options.isEorH);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                MelonLogger.Msg("Restart pressed");


                if (options.isEorH)
                {
                    var hRestInstance = new Trainers.hRest();
                    MelonCoroutines.Start(hRestInstance.Rest());
                }
                else
                {
                    var eRestInstance = new Trainers.eRest();
                    MelonCoroutines.Start(eRestInstance.Rest());
                }
            }
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (options.isMenuShown && sceneIndex == 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }

            if(sceneIndex != 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
