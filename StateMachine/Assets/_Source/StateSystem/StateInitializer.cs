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
        public StateInitializer(PlayerStateMachine playerStateMachine, GameStateMachine gameStateMachine, 
            TextMeshProUGUI stateText, Transform firePoint, GameObject bullet,
            GameObject redZone, SpriteRenderer playerSprite, PlayerInput playerInput)
        {
            playerStateMachine.states = new Dictionary<int, AStatePlayer>();
            playerStateMachine.states.Add(0, new ShootState(playerStateMachine, stateText, firePoint, bullet));
            playerStateMachine.states.Add(1, new RedZoneState(playerStateMachine, stateText, redZone));
            playerStateMachine.states.Add(2, new InvinsibleState(playerStateMachine, stateText, playerSprite));
            playerStateMachine.EnterNewState();

            gameStateMachine.states = new Dictionary<Type, AStateGame>();
            gameStateMachine.states.Add(typeof(Game), new Game(gameStateMachine, playerInput));
            gameStateMachine.states.Add(typeof(Pause), new Pause(gameStateMachine));
            gameStateMachine.states.Add(typeof(Final), new Final(gameStateMachine, new FinalState(playerStateMachine, stateText, playerSprite, redZone)));
        }
    }
}