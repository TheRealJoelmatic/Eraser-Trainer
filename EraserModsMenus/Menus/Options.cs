using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EraserModsMenus.Menus
{
    public class Options
    {
        public bool isMenuShown = true;
        public bool isEorH = false;

        public bool menuMain = true;
        public bool menuRestart = false;
        public bool menuTeleport = false;
        public bool menuOther = false;

        public bool isHighJump = false;
        public float newHightJump = 12f;

        public bool killAll = false;
        public bool Splat = false;

        public void allOfMenuOff()
        {
            menuMain = false;
            menuRestart = false;
            menuTeleport = false;
            menuOther = false;
        }
    }
}
