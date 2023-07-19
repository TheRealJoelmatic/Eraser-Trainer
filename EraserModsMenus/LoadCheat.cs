using EraserModsMenus.Menus;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using EraserModsMenus.Trainers;

namespace EraserModsMenus
{
    class LoadCheat : MelonMod
    {
        Options options = new Options();
        Other other = new Other();
        Menu menu = new Menu();
        SplatInterceptor splat = new SplatInterceptor();

        bool pausemenu = false;
        int killBuffer = 0;

        public override void OnGUI()
        {
            menu.StartSetup();
            menu.CreateGUI(options);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
            options.isMenuShown = false;
            pausemenu = false;
        }

        public override void OnLateUpdate()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (Input.GetKeyDown(KeyCode.F5))
            {
                options.isMenuShown = !options.isMenuShown;
                MelonLogger.Msg($"Menu: " + options.isMenuShown);
                MelonLogger.Msg($"Hard mode: " + options.isEorH);

                mouseChecker();

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

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                splat.SplatFixer();
                if (sceneIndex == 1)
                {
                    pausemenu = !pausemenu;
                }

            }

            if (options.isHighJump)
            {
                other.highJump(options, true);
            }
            else
            {
                other.highJump(options, false);
            }
            if (options.killAll && killBuffer <= 1)
            {
                killBuffer = 10;
                other.killAll(options, "Cannon Ball");
                MelonLogger.Msg($"KILLING: Cannon Ball");
            }
            else if (options.killAll || options.Splat)
            {
                killBuffer++;
            }

            if(options.Splat)
            {
                splat.SplatFixer();
            }
            mouseChecker();
        }

        public void mouseChecker()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (pausemenu && sceneIndex == 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (options.isMenuShown && sceneIndex == 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
            if (sceneIndex != 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
