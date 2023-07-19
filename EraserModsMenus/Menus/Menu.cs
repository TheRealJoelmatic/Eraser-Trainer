using MelonLoader;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using EraserModsMenus.Trainers;

namespace EraserModsMenus.Menus
{
    public class Menu
    {
        private GUIStyle boxStyle;
        private GUIStyle buttonStyle;
        private GUIStyle tabStyle;
        private GUIStyle textFieldStyle;

        private Texture2D blackTexture;
        private Texture2D topLineTexture;
        private Texture2D whiteTexture;
        private Texture2D grayTexture;
        private Texture2D lineTexture;

        teleportPlayer TP = new teleportPlayer();
        Other other = new Other();

        string inputValue = "120";

        public void StartSetup()
        {
            blackTexture = new Texture2D(1, 1);
            blackTexture.SetPixel(0, 0, new Color(5f / 255f, 24f / 255f, 33f / 255f));
            blackTexture.Apply();

            topLineTexture = new Texture2D(1, 1);
            topLineTexture.SetPixel(0, 0, new Color(38f / 255f, 104f / 255f, 103f / 255f));
            topLineTexture.Apply();

            whiteTexture = new Texture2D(1, 1);
            whiteTexture.SetPixel(0, 0, new Color(26f / 255f, 70f / 255f, 69f / 255f));
            whiteTexture.Apply();

            grayTexture = new Texture2D(1, 1);
            grayTexture.SetPixel(0, 0, Color.gray);
            grayTexture.Apply();

            lineTexture = new Texture2D(1, 1);
            lineTexture.SetPixel(0, 0,  new Color(38f / 255f, 104f / 255f, 103f / 255f));
            lineTexture.Apply();

            // Create a custom box style
            boxStyle = new GUIStyle(GUI.skin.box);
            boxStyle.fontSize = 15;
            boxStyle.alignment = TextAnchor.UpperLeft;
            boxStyle.normal.textColor = new Color(245f / 255f, 136f / 255f, 0f / 255f);
            boxStyle.normal.background = blackTexture; // Use a black texture for the background
            boxStyle.border = new RectOffset(10, 10, 10, 10);

            // Create a custom button style
            buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 14;
            buttonStyle.padding = new RectOffset(10, 10, 5, 5);
            buttonStyle.normal.textColor = Color.white;
            buttonStyle.normal.background = whiteTexture; // Use a white texture for the background
            buttonStyle.hover.background = topLineTexture; // Use a gray texture for the hover background
            buttonStyle.border = new RectOffset(10, 10, 10, 10);

            // Create a custom button style
            tabStyle = new GUIStyle(GUI.skin.button);
            tabStyle.fontSize = 20;
            tabStyle.normal.textColor = Color.white;
            tabStyle.normal.background = whiteTexture; // Use a white texture for the background
            tabStyle.hover.background = topLineTexture; // Use a gray texture for the hover background
            tabStyle.border = new RectOffset(10, 10, 10, 10);


        }
        public void CreateGUI(Options options)
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (options.isMenuShown)
            {
                if (options == null || !options.isMenuShown)
                {
                    // Handle null options object
                    return;
                }

                float boxWidth = 700;
                float boxHeight = 370;
                float boxX = (Screen.width - boxWidth) / 2;
                float boxY = (Screen.height - boxHeight) / 2;
                Rect boxRect = new Rect(boxX, boxY, boxWidth, boxHeight);

                GUI.Box(boxRect, "Eraser Trainer - Made by Joelmatic#8817", boxStyle);

                Vector2 textSize = GUI.skin.label.CalcSize(new GUIContent("Eraser Trainer - Made by Joelmatic#8817"));

                // Tabs
                float tabsWidth = 100;
                float tabsHeight = 30;
                float tabsX = (Screen.width - tabsWidth) / 2;
                float tabsY = boxY + textSize.y + 30; // Adjust the Y position to be below the text

                GUILayout.BeginArea(new Rect(boxX, tabsY, boxWidth, boxHeight - textSize.y - 0));

                GUILayout.BeginHorizontal(); // Start a horizontal layout for the tabs

                GUILayout.FlexibleSpace(); // Add flexible space before the tabs

                
                if (GUILayout.Button("About", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                {
                    options.allOfMenuOff();
                    options.menuMain = true;
                }

                GUILayout.Space(10); // Add spacing between tabs

                if (GUILayout.Button("Restart", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                {
                    options.allOfMenuOff();
                    options.menuRestart = true;
                }

                GUILayout.Space(10); // Add spacing between tabs

                if (GUILayout.Button("Teleport", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                {
                    options.allOfMenuOff();
                    options.menuTeleport = true;
                }

                GUILayout.Space(10); // Add spacing between tabs

                if (GUILayout.Button("Other", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                {
                    options.allOfMenuOff();
                    options.menuOther = true;
                }

                GUILayout.FlexibleSpace(); // Add flexible space after the tabs

                GUILayout.EndHorizontal(); // End the horizontal layout for the tabs

                GUILayout.EndArea(); // End the box area

                float lineWidth = boxWidth;
                float lineHeight = 15;
                Rect lineRect = new Rect(boxX + (boxWidth - lineWidth) / 2, boxY + textSize.y + 5, lineWidth, lineHeight);
                GUI.DrawTexture(lineRect, lineTexture);

                // Calculate the position and size of the first button
                float buttonWidth = 200;
                float buttonHeight = 30;
                float buttonX = (boxWidth - buttonWidth) / 2;
                float buttonY = 120;
                Rect buttonRect1 = new Rect(boxX + buttonX, boxY + buttonY, buttonWidth, buttonHeight);

                //About
                if (options.menuMain)
                {
                    float labelWidth = 600;
                    float labelHeight = 200;
                    float labelX = (Screen.width - labelWidth) / 2;
                    float labelY = (Screen.height - labelHeight) / 2;
                    Rect labelRect = new Rect(labelX, labelY, labelWidth, labelHeight);

                    // Set the text content and style for the label
                    GUIContent labelText = new GUIContent("Thank you for downloading Eraser Trainer. If you find any bugs open a issue on github and ill try and fix it.\n\n (Known bugs!)Kill all Balls is buggy atm");
                    GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
                    labelStyle.alignment = TextAnchor.MiddleCenter;
                    labelStyle.fontSize = 20;

                    // Draw the text label
                    GUI.Label(labelRect, labelText, labelStyle);

                    return;
                }

                // Restart
                if (options.menuRestart)
                {

                    float labelWidth = 600;
                    float labelHeight = 200;
                    float labelX = (Screen.width - labelWidth) / 2;
                    float labelY = (Screen.height - labelHeight) / 2;
                    Rect labelRect = new Rect(labelX, labelY, labelWidth, labelHeight);

                    // Set the text content and style for the label
                    GUIContent labelText = new GUIContent("Press 'R' to fast reset (good for speed running)");
                    GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
                    labelStyle.alignment = TextAnchor.MiddleCenter;
                    labelStyle.fontSize = 20;

                    // Draw the text label
                    GUI.Label(labelRect, labelText, labelStyle);

                    if (options.isEorH)
                    {
                        if (GUI.Button(buttonRect1, "Set quick rest to easy mode", buttonStyle))
                        {
                            options.isEorH = false;
                        }
                    }
                    else
                    {
                        if (GUI.Button(buttonRect1, "Set quick rest to hard mode", buttonStyle))
                        {
                            options.isEorH = true;
                        }
                    }
                    return;
                }

                //deal with later
                if (options.menuTeleport)
                {
                    if (sceneIndex != 1)
                    {
                        float labelWidth = 600;
                        float labelHeight = 200;
                        float labelX = (Screen.width - labelWidth) / 2;
                        float labelY = (Screen.height - labelHeight) / 2;
                        Rect labelRect = new Rect(labelX, labelY, labelWidth, labelHeight);

                        // Set the text content and style for the label
                        GUIContent labelText = new GUIContent("Teleport only workings in game!");
                        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
                        labelStyle.alignment = TextAnchor.MiddleCenter;
                        labelStyle.fontSize = 20;

                        // Draw the text label
                        GUI.Label(labelRect, labelText, labelStyle);
                        return;
                    }
                    // Calculate the position and size of the second button
                    Rect buttonRect2 = new Rect(boxX + buttonX, boxY + buttonY + buttonHeight - 40, buttonWidth, buttonHeight);

                    // Calculate the position and size of the third button
                    Rect buttonRect3 = new Rect(boxX + buttonX, buttonRect2.yMax + 10, buttonWidth, buttonHeight);

                    // Calculate the position and size of the fourth button
                    Rect buttonRect4 = new Rect(boxX + buttonX, buttonRect3.yMax + 10, buttonWidth, buttonHeight);

                    // Calculate the position and size of the fifth button
                    Rect buttonRect5 = new Rect(boxX + buttonX, buttonRect4.yMax + 10, buttonWidth, buttonHeight);

                    // Calculate the position and size of the sixth button
                    Rect buttonRect6 = new Rect(boxX + buttonX, buttonRect5.yMax + 10, buttonWidth, buttonHeight);

                    // Calculate the position and size of the seventh button
                    Rect buttonRect7 = new Rect(boxX + buttonX, buttonRect6.yMax + 10, buttonWidth, buttonHeight);


                    if (GUI.Button(buttonRect2, "Spawn Point", buttonStyle))
                    {
                        options.isMenuShown = !options.isMenuShown;
                        TP.tpPlayer(new Vector3(5f, 1.22f, 5f));
                    }

                    if (GUI.Button(buttonRect3, "Cannon Room", buttonStyle))
                    {
                        options.isMenuShown = !options.isMenuShown;
                        TP.tpPlayer(new Vector3(28.8316f, 103.22f, 22.3747f));
                    }

                    if (GUI.Button(buttonRect4, "Bird Room", buttonStyle))
                    {
                        options.isMenuShown = !options.isMenuShown;
                        TP.tpPlayer(new Vector3(18.3064f, 215.22f, 13.7295f));
                    }

                    if (GUI.Button(buttonRect5, "Caution", buttonStyle))
                    {
                        options.isMenuShown = !options.isMenuShown;
                        TP.tpPlayer(new Vector3(28.2139f, 283.22f, 12.6936f));
                    }

                    if (GUI.Button(buttonRect6, "Safe Room", buttonStyle))
                    {
                        options.isMenuShown = !options.isMenuShown;
                        TP.tpPlayer(new Vector3(4.4445f, 208.22f, 24.4925f));
                    }

                    // Draw the seventh button
                    if (GUI.Button(buttonRect7, "Noah's Arms", buttonStyle))
                    {
                        options.isMenuShown = !options.isMenuShown;
                        //MelonCoroutines.Start(NoahsArms());
                        TP.tpPlayer(new Vector3(4.4445f, 208.22f, 24.4925f));
                        TP.tpPlayer(new Vector3(18.4745f, 386.22f, 12.5002f));
                    }
                    return;

                }

                if (options.menuOther)
                {
                    if (sceneIndex != 1)
                    {
                        float labelWidth = 600;
                        float labelHeight = 200;
                        float labelX = (Screen.width - labelWidth) / 2;
                        float labelY = (Screen.height - labelHeight) / 2;
                        Rect labelRect = new Rect(labelX, labelY, labelWidth, labelHeight);

                        // Set the text content and style for the label
                        GUIContent labelText = new GUIContent("Teleport only workings in game!");
                        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
                        labelStyle.alignment = TextAnchor.MiddleCenter;
                        labelStyle.fontSize = 20;

                        // Draw the text label
                        GUI.Label(labelRect, labelText, labelStyle);
                        return;
                    }

                    Rect buttonRect2 = new Rect(boxX + buttonX, boxY + buttonY + buttonHeight - 40, buttonWidth, buttonHeight);
                    if (options.isHighJump)
                    {
                        if (GUI.Button(buttonRect2, "Custom Jump hight on (" + options.newHightJump + ")", buttonStyle))
                        {
                            options.isHighJump = !options.isHighJump;
                        }
                    }
                    else
                    {
                        if (GUI.Button(buttonRect2, "Custom Jump hight off (" + options.newHightJump + ")", buttonStyle))
                        {
                            options.isHighJump = !options.isHighJump;
                        }
                    }


                    GUILayout.BeginArea(new Rect(boxX, tabsY + 100, boxWidth, boxHeight - textSize.y - 100));

                    GUILayout.BeginHorizontal(); // Start a horizontal layout for the tabs

                    GUILayout.FlexibleSpace(); // Add flexible space before the tabs


                    if (GUILayout.Button("0", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                    {
                        options.newHightJump = 0;
                    }

                    GUILayout.Space(10); // Add spacing between tabs

                    if (GUILayout.Button("6", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                    {
                        options.newHightJump = 6;
                    }

                    GUILayout.Space(10); // Add spacing between tabs

                    if (GUILayout.Button("12", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                    {
                        options.newHightJump = 12;
                    }

                    GUILayout.Space(10); // Add spacing between tabs

                    if (GUILayout.Button("16", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                    {
                        options.newHightJump = 16;
                    }

                    GUILayout.Space(10); // Add spacing between tabs

                    if (GUILayout.Button("50", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                    {
                        options.newHightJump = 50;
                    }

                    GUILayout.Space(10); // Add spacing between tabs

                    if (GUILayout.Button("120", tabStyle, GUILayout.Width(tabsWidth), GUILayout.Height(tabsHeight)))
                    {
                        options.newHightJump = 120;
                    }

                    GUILayout.FlexibleSpace(); // Add flexible space after the tabs

                    GUILayout.EndHorizontal(); // End the horizontal layout for the tabs

                    GUILayout.EndArea(); // End the box area

                    //options.newHightJump;
                    Rect buttonRect4 = new Rect(boxX + buttonX, boxY + buttonY + buttonHeight + 40, buttonWidth, buttonHeight);
                    if (options.killAll)
                    {
                        if (GUI.Button(buttonRect4, "Kill all Balls is on", buttonStyle))
                        {
                            options.killAll = !options.killAll;
                        }
                    }
                    else
                    {
                        if (GUI.Button(buttonRect4, "Kill all Balls is off", buttonStyle))
                        {
                            options.killAll = !options.killAll;
                        }
                    }

                    Rect buttonRect5 = new Rect(boxX + buttonX, boxY + buttonY + buttonHeight + 80, buttonWidth, buttonHeight);
                    if (options.Splat)
                    {
                        if (GUI.Button(buttonRect5, "Anti Splat is on", buttonStyle))
                        {
                            options.Splat = !options.Splat;
                        }
                    }
                    else
                    {
                        if (GUI.Button(buttonRect5, "Anti Splat is off", buttonStyle))
                        {
                            options.Splat = !options.Splat;
                        }
                    }
                }
            }
        }

        private IEnumerator NoahsArms()
        {
            TP.tpPlayer(new Vector3(5f, 1.22f, 5f));
            yield return new WaitForSeconds(2.5f);
            TP.tpPlayer(new Vector3(4.4445f, 208.22f, 24.4925f));
            yield return new WaitForSeconds(2.5f);
            TP.tpPlayer(new Vector3(4.4445f, 470.22f, 24.4925f));
            yield return new WaitForSeconds(2.5f);
            TP.tpPlayer(new Vector3(18.4745f, 386.22f, 12.5002f));
        }
    }
}