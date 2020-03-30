using UnityEngine;
using UnityEngine.Events;


    public class Events
    {

        [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }

        [System.Serializable] public class EventLocalPlayerJoined : UnityEvent<MainPlayerNetworkState> { };



    }
