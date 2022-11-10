using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawns;

namespace SaveAndLoad
{
    public class LevelLoader
    {
        private List<GameObject> _levelParts;
        private GameObject _finishPrefab;
        private int _levelNum;
        private Spawner _spawner;
        private SaveAndLoadService _saveAndLoadService;
        public LevelLoader(List<GameObject> levelParts, GameObject finishPrefab, Spawner spawner, SaveAndLoadService saveAndLoadService)
        {
            _levelParts = levelParts;
            _finishPrefab = finishPrefab;
            _spawner = spawner;
            _saveAndLoadService = saveAndLoadService;
            _levelNum = _saveAndLoadService.Load();
        }
        public void LoadLevel()
        {
            for (int i = 0; i < _levelNum; i++)
            {
                _spawner.SpawnPart(_levelParts[Random.Range(0, _levelParts.Count)]);
            }
            _spawner.SpawnPart(_finishPrefab);
        }
    }
}