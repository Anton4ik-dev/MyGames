using Player;
using StateSystem.GameStates;
using StateSystem.PlayerStates;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace StateSystem
{
    public class StateInitializer
    {
        public Dictionary<int, AStatePlayer> playerStates;
        public Dictionary<Type, AStateGame> gameStates;
        public StateInitializer(PlayerStateMachine playerStateMachine, GameStateMachine gameStateMachine, 
            TextMeshProUGUI stateText, Transform firePoint, GameObject bullet,
            GameObject redZone, SpriteRenderer playerSprite, PlayerInput playerInput)
        {
            InitializePlayerStates(playerStateMachine, stateText, firePoint, bullet, redZone, playerSprite);
            InitializeGameStates(playerStateMachine, gameStateMachine, stateText, redZone, playerSprite, playerInput);
        }
        private void InitializePlayerStates(PlayerStateMachine playerStateMachine, TextMeshProUGUI stateText,
            Transform firePoint, GameObject bullet, 
            GameObject redZone, SpriteRenderer playerSprite)
        {
            playerStates = new Dictionary<int, AStatePlayer>();
            playerStates.Add(0, new ShootState(playerStateMachine, stateText, firePoint, bullet));
            playerStates.Add(1, new RedZoneState(playerStateMachine, stateText, redZone));
            playerStates.Add(2, new InvinsibleState(playerStateMachine, stateText, playerSprite));
        }
        private void InitializeGameStates(PlayerStateMachine playerStateMachine, GameStateMachine gameStateMachine,
            TextMeshProUGUI stateText, GameObject redZone, 
            SpriteRenderer playerSprite, PlayerInput playerInput)
        {
            gameStates = new Dictionary<Type, AStateGame>();
            gameStates.Add(typeof(Game), new Game(gameStateMachine, playerInput));
            gameStates.Add(typeof(Pause), new Pause(gameStateMachine));
            gameStates.Add(typeof(Final), new Final(gameStateMachine, new FinalPlayerState(playerStateMachine, stateText, playerSprite, redZone)));
        }
    }
}