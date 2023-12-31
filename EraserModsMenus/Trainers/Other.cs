﻿using UnityEngine;
using EraserModsMenus.Menus;

namespace EraserModsMenus.Trainers
{
    public class Other
    {
        public void highJump(Options options, bool Change)
        {
            GameObject playerObject = GameObject.Find("player");
            PlayerController playercontroller = playerObject.GetComponent<PlayerController>();
            if (!Change)
            {
                if(playercontroller.jumpSpeed == options.newHightJump)
                {
                    return;
                }
                else
                {
                    playercontroller.jumpSpeed = options.newHightJump;
                }
            }
            else
            {
                if(playercontroller.jumpSpeed == 12f)
                {
                    return;
                }
                else
                {
                    playercontroller.jumpSpeed = 12f;
                    return;
                }
            }
        }
        public void changeFov(Options options, bool Change)
        {
            GameObject playerObject = GameObject.Find("player");
            PlayerController playercontroller = playerObject.GetComponent<PlayerController>();
            if (!Change)
            {
                if (playercontroller.cameraDistance == options.newFov)
                {
                    return;
                }
                else
                {
                    playercontroller.cameraDistance = options.newFov;
                }
            }
            else
            {
                if (playercontroller.cameraDistance == 6.7f)
                {
                    return;
                }
                else
                {
                    playercontroller.cameraDistance = 6.7f;
                    return;
                }
            }
        }

        public void killAll(Options options, string name)
        {
            //Cannon Ball
            if (options.killAll)
            {
                GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

                foreach (GameObject obj in allObjects)
                {
                    if (obj.name.IndexOf(name, System.StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        obj.SetActive(false);
                    }
                }

            }
        }
    }
}
