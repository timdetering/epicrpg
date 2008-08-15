using System;
using System.Collections.Generic;
using System.Text;
using EpicRPG.Util;
using Microsoft.Xna.Framework;
using EpicRPG.Interface;
using EpicRPG.Entities.Configuration;

namespace EpicRPG.Managers
{
    public class MenuManager : Singleton<MenuManager>
    {
        private State.MenuState _menuState;

        public State.MenuState menuState{
            get{return this._menuState;}
            set{if(value != State.MenuState.NULL) this._menuState = value;}
        }

        private Menu currentMenu,
                     mainMenu,
                     newGameMenu,
                     epicMenu,
                     inventoryMenu;

        public void initializeMenuManager(){
            this.mainMenu = new Menu("Eternal Passage into Chaos",
                new MenuItem("New Game", State.MenuState.NEW_GAME),
                new MenuItem("Load Game", State.MenuState.NULL),
                new MenuItem("Credits", State.MenuState.NULL),
                new MenuItem("Exit", State.MenuState.EXIT_GAME));

            this.newGameMenu = new Menu("Create Your Hero",
                new MenuItemWithInput("Name"),
                new MenuItem("Begin Epic RPG", State.MenuState.START_NEW_GAME),
                new MenuItem("Cancel", State.MenuState.MAIN_MENU));

            this.epicMenu = new Menu("EPIC Menu",
                new MenuItem("Inventory", State.MenuState.EPIC_MENU_INVENTORY),
                new MenuItem("Abilities", State.MenuState.NULL),
                new MenuItem("Party", State.MenuState.NULL),
                new MenuItem("Save Game", State.MenuState.NULL),
                new MenuItem("Back", State.MenuState.NONE),
                new MenuItem("Quit", State.MenuState.EXIT_GAME));
<<<<<<< .mine

            this.battleMenu = new Menu("Pick Action",
                new MenuItem("Attack", State.MenuState.NONE),
                new MenuItem("Magic", State.MenuState.NONE),
                new MenuItem("Item", State.MenuState.NONE),
                new MenuItem("Run", State.MenuState.NONE));
=======

            this.inventoryMenu = new Menu("Inventory",
                new MenuItem("This", State.MenuState.NULL),
                new MenuItem("That", State.MenuState.NULL),
                new MenuItem("The other", State.MenuState.NULL),
                new MenuItem("Back", State.MenuState.EPIC_MENU));
>>>>>>> .r29
        }

        public void Update(GameTime gameTime){
            switch(this.menuState){
                case State.MenuState.CREDITS:
                    break;

                case State.MenuState.EXIT_GAME:
                    EpicRPG.getInstance().Exit();
                    break;

                case State.MenuState.LOAD_GAME:
                    break;

                case State.MenuState.MAIN_MENU:
                    this.setCurrentMenu(ref this.mainMenu);
                    break;

                case State.MenuState.NEW_GAME:
                    this.setCurrentMenu(ref this.newGameMenu);
                    break;

                case State.MenuState.EPIC_MENU:
                    this.setCurrentMenu(ref this.epicMenu);
                    break;

                case State.MenuState.EPIC_MENU_INVENTORY:
                    this.setCurrentMenu(ref this.inventoryMenu);
                    break;

                case State.MenuState.START_NEW_GAME:
                    CampaignManager.getInstance().initializeNewGame(this.newGameMenu.getInputValueWithName("Name"));
                    break;

                case State.MenuState.SAVE_GAME:
                    break;

                case State.MenuState.NONE:
                    EpicRPG.getInstance().CurrentState = State.GameState.IN_PLAY_NORMAL;
                    break;

                default: break;
            }

            this.currentMenu.Update(gameTime);
        }

        public void DrawCurrentMenu(){
            this.currentMenu.Draw();
        }

        private void setCurrentMenu(ref Menu menu){
            this.currentMenu = menu;
        }
    }
}