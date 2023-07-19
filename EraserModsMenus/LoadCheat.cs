using EraserModsMenus.Menus;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using EraserModsMenus.Trainers;

namespace EraserModsMenus
{
    class LoadCheat : MelonMod
    {
        Options options = new Options();
        Other other = new Other();
        Menu menu = new Menu();
        SplatInterceptor splat = new SplatInterceptor();

        int killBuffer = 0;

        bool oldCursorV;
        CursorLockMode oldCursorM;

        public override void OnGUI()
        {
            menu.CreateGUI(options);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            MelonLogger.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
            options.isMenuShown = false;
        }

        private Trainers.hRest hRestInstance;
        private Trainers.eRest eRestInstance;

        public override void OnLateInitializeMelon()
        {
            hRestInstance = new Trainers.hRest();
            eRestInstance = new Trainers.eRest();
        }

        public override void OnLateUpdate()
        {
            //toggle menu
            if (Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.Y))
            {
                options.isMenuShown = !options.isMenuShown;
                if (options.isMenuShown)
                {
                    oldCursorV = Cursor.visible;
                    oldCursorM = Cursor.lockState;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.visible = oldCursorV;
                    Cursor.lockState = oldCursorM;
                }
                
                MelonLogger.Msg($"Menu: {options.isMenuShown}");
            }
             if (Input.GetKeyDown(KeyCode.R))
            {
                MelonLogger.Msg("Restart pressed");

                if (options.isEorH)
                    MelonCoroutines.Start(hRestInstance.Rest());
                else
                    MelonCoroutines.Start(eRestInstance.Rest());
            }

            // Kill all balls (buggy)
            if (options.killAll && killBuffer == 0)
            {
                killBuffer = 10;
                other.killAll(options, "Cannon Ball");
                MelonLogger.Msg("KILLING: Cannon Ball");
            }
            else if (options.killAll || options.Splat)
            {
                killBuffer++;
            }

            // Checks if hit
            if (options.Splat)
            {
                splat.SplatFixer();
            }

        }
    }
}