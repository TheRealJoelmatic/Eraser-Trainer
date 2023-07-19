using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;
using EraserModsMenus.Menus;


namespace EraserModsMenus.Trainers
{
    public class SplatInterceptor
    {
        private PlayerController playerController;

        public enum PlayerState : byte
        {
            idle,
            run,
            jump,
            fall,
            plummet,
            charge,
            attack,
            parry,
            dodge
        }

        public void SplatFixer()
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex != 1)
            {
                return;
            }
            

            GameObject playerObject = GameObject.Find("player");
            playerController = playerObject.GetComponent<PlayerController>();

            if (playerController.currState != (PlayerController.PlayerState)PlayerState.plummet)
            {
                return;
            }

            playerController.currState = (PlayerController.PlayerState)PlayerState.jump;
            playerController.controller.enabled = true;
            playerController.plummetPose.enabled = false;
            playerController.fallPose.forceHideAndDisable();
            playerController.idlePose.forceHideAndDisable();
            //private void ChangeState(PlayerState newState)
            //playerController.ApplyState(PlayerState.idle);

        }

    }
}
