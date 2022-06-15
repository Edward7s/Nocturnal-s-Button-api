using MelonLoader;
using UnityEngine;
using System;
namespace Nocturnal.Apis.qm.Example
{
    internal class GenerateButtons
    {
        public GenerateButtons()
        {
            //The first parameter of the page its a string which will be the name, I recommend to change it
            //Second Parameter its the image if u won't add anything there will be just a blank image.
            new Page("Example", Download_Images._PageIcon);

            //Now we want to do a submenu where we will place the buttons.

            //Second Parameter its if your submenu its in another submenu u will want to put there the parent submenu.
            //Third one its if u want to Move the buttons where ever u want and not let them layout themself.
            GameObject Menu = submenu.Create("Example",null,true);
            //We want to set this menu active since this will be the main submenu.
            Menu.SetActive(true);

            //Creating a button with custom placement its like this:
              new NButton(Menu.Getmenu(), "Test Button", () =>
              {
                //Here u will put what u want to happen.
                MelonLogger.Msg("Test");
              }, false, null,0,0);
            //Under it will be a half button which u will make almost the same but the Y value u need to make it times 2,
            //Be cause u can fit 2 half buttons in a normal button place

            //U can also do a lambda expression like this ()=> but u can only call one thing.
            new NButton(Menu.Getmenu(), "Half Button", () => MelonLoader.MelonLogger.Msg("Half")
            ,true, null, 0, 2);

            //Now we are going to do a toggle.
            new NToggle("Example Toggle",Menu.Getmenu(), () => 
            {
                MelonLogger.Msg("On");
                Console.WriteLine("----");
            },()=> 
            {
                MelonLogger.Msg("Off");
                Console.WriteLine("----");
            },false /*Here is the pre value so if u have like a bool u can put it here and also
                     * change the values above*/,false,1,1);

            new NToggle("Toggle 2", Menu.Getmenu(), () =>
            {
                MelonLogger.Msg("On");
                Console.WriteLine("----");
            }, () =>
            {
                MelonLogger.Msg("Off");
                Console.WriteLine("----");
            },false,true,1,2);
            //The Toggles are very similar to a normal button the only diffirence's are that
            //U can put a pre value and u also have 2 Actions instead of one.

            //Now we going to do a MiniButton also u can place every button where ever u want, but if
            //u are going to place it in a Nocturnal Submenu u will need to do the gameobject.Getmenu() as we did above.
            new Minibuttn(Misc._QMexpand.transform.parent.gameObject, "Example Small Button"
                ,() => MelonLogger.Msg("Small Button"), Download_Images._ClipBoardIcon);


            //Now We are going to do a SmallButton this one u will need to get the position where to put it with unityexplorer or something.
            GameObject QuickMenuWindow = UnityEngine.GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject;
            GameObject SmallButtonTest = null;
            new SmallButton(out SmallButtonTest, QuickMenuWindow, () => MelonLogger.Msg("test"));
            //U can use the Out Parameter on a Button to, the out parameter returns u the button gameobject.
            SmallButtonTest.transform.localPosition = new Vector3(-607, -673, 0);

            //Here we going to make a new submenu.
            //This menu will aling objects by itself.
            //Also all button can let u add a imag to it, its a optional parameter on most of them.
            GameObject worldsubmenu = submenu.Create("World", Menu);
            //Now we are going to do a submenu button.
            //The last 2 parameters are requered be cause we are not using self aling.
            new Submenubutton(Menu.Getmenu(), "World", worldsubmenu, Download_Images._WorldIcon, false, 3, 0);


            // We do not need to put the extra parameters now since the Gridlayout will just align them.
            new NButton(worldsubmenu.Getmenu(), "Test 1", () => MelonLogger.Msg("1"));
            new NButton(worldsubmenu.Getmenu(), "Test 2", () => MelonLogger.Msg("2"));

            //Here is a example just on how to do a basic toggle for a bool u also can do from this ()=> 
            //to this ()=> {  } so u can do actions and change the value to. 
            bool testbool = true;
            new NToggle("Test 3", worldsubmenu.Getmenu(), () => testbool = true, () => testbool = true, testbool);
            new NButton(worldsubmenu.Getmenu(), "Test 4", () => MelonLogger.Msg("4"));

            //Now we are going to do sliders.
            //The slider does not require the last 2 values from the next slider but I added them for example.
            float value = 0.2f;
            new Slider(worldsubmenu.Getmenu(), val => value = val, value, () => MelonLogger.Msg(value));
            //Now We are going to do a slider with a title its almost the same thing just add a string at the end.
            float value2 = 0.2f;
            new Slider(worldsubmenu.Getmenu(), val => value2 = val, value, () => MelonLogger.Msg(value2),"Test");

        }

    }
}
