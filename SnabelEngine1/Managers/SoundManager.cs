using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Snabel_Engine.Managers
{
    public class SoundManager
    {

        public SoundEffect _walkFX;
        public SoundEffect _jumpFX;
        public SoundEffect _sprintFX;
        public SoundEffect _damageFX;
        public SoundEffect _sneakFX;
        
        public SoundEffect _menuSelect;
        public SoundEffect _menuSelected;

        public Song _menuBGSong;

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        //Get Set, Volume etc.
        public string menuBGid = "ID";
        public float mediaVolume = 0.4f;

        //Constructor
        public SoundManager()
        {
         
            //Effekter
             _walkFX = null;
             _jumpFX = null;
             _sprintFX = null;
             _damageFX = null;
             _sneakFX = null;
             _menuSelect = null;
             _menuSelected = null;
            
            //---

            //Musik, 
            
            _menuBGSong = null;
            
            //---
        }

        public void LoadContent()
        {

        }
    }
}