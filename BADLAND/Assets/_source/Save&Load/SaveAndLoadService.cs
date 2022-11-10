using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveAndLoad
{
    public class SaveAndLoadService
    {
        private const string LEVEL_NUM_NAME = "levelNum";
        public int Load()
        {
            /*PlayerPrefs.SetInt(LEVEL_NUM_NAME, 1);
            PlayerPrefs.Save();*/ 
            // needed for tests
            return PlayerPrefs.GetInt(LEVEL_NUM_NAME, 1);
        }
        public void SaveAlive()
        {
            PlayerPrefs.SetInt(LEVEL_NUM_NAME, Load() + 1);
            PlayerPrefs.Save();
        }
        public void SaveDeath()
        {
            PlayerPrefs.SetInt(LEVEL_NUM_NAME, Load());
            PlayerPrefs.Save();
        }
    }
}