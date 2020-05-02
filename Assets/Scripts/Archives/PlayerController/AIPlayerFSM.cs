﻿/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CardInfo;
using TerrainScanning;

namespace GameLogic
{
    public class AIPlayerFSM : Player
    {

        #region Public Property
        /// <summary>
        /// CardInfo Reader
        /// </summary>
        public GetCardInstruction myCardDataBase;

        /// <summary>
        /// The Array of HexMap
        /// </summary>
        public Transform HexMap;
        #endregion

        #region Private Variable
        /// <summary>
        /// myState record the states of the player
        /// </summary>
        private PlayerStates myState = PlayerStates.Init;

        /// <summary>
        /// Only Init when game start
        /// </summary>
        private bool _bInit = false;

        /// <summary>
        /// Store the time when this state began
        /// </summary>
        private float stateBeginTime;

        ///<summary>
        /// A random card generated by database
        ///</summary>
        private Cards CardToUsed;

        ///<summary>
        /// A random hex index to place new monster
        ///</summary>
        private int HexToPlaceIndex;
        #endregion

        #region Unreal Function
        /// <summary>
        /// Start is called before the first frame update
        /// Inherited from PlayerFSM
        /// </summary>
        public void Start()
        {
            if (!_bInit)
            {
                ChangeState(PlayerStates.Init);
                _bInit = true;
            }
            //Event Init
            if (Event_PlayerTurnStart == null)
            {
                Event_PlayerTurnStart = new UnityEvent();
            }
            Event_PlayerTurnStart.AddListener(PlayerTurnStartInvoke);
            if (Event_ScanFinished == null)
            {
                Event_ScanFinished = new UnityEvent();
            }
            Event_ScanFinished.AddListener(ScanFinishedInvoke);
            PlayedCard += PlayedCardInvoked;
        }
        
        /// <summary>
        /// Update is called once per frame
        /// Non-inherited from PlayerFSM
        /// </summary>
        public void Update()
        {
            float nowTime = Time.time;
            switch (myState)
            {
                case (PlayerStates.Init):
                    //Init For AI Player
                    break;
                case (PlayerStates.WaitForStart):
                    break;
                case (PlayerStates.Main_Phase):
                    if (nowTime - stateBeginTime < 2) break; //Wait 2 seconds.
                    Debug.Log("Now Is AI Main_Phase, AI will randomly choose A card.");
                    CardToUsed = myCardDataBase.GetRandomCard();
                    Debug.Log(("Now AI want to use {0}, ATK: {1}, HP: {2}, SPEED: {3}, SPECIAL EFFECT: {4}", CardToUsed.CardName, CardToUsed.Attack, CardToUsed.HP, CardToUsed.Speed, CardToUsed.SpecialEffect));
                    ChangeState(PlayerStates.Confirm_Phase);
                    break;
                case (PlayerStates.Confirm_Phase):
                    if (nowTime - stateBeginTime < 2) break; //Wait 2 seconds.
                    Debug.Log("Now Is AI Confirm_Phase, AI will randomly choose A hex to place.");
                    { //TODO: Replace with a function in HexTileMap that ensure it can be place in a available tile.
                        int n = HexMap.childCount;
                        int k = (int) (Random.value * n);
                        while(n==k)
                        {
                            k = (int) (Random.value * n);
                        }
                        HexToPlaceIndex = k;
                        if (HexMap.GetChild(k).GetComponent<HexTile>() == null) break;
                        else
                        {
                            if (HexMap.GetChild(k).GetComponent<HexTile>().getAccessible() == false) break;
                        }
                    }
                    Debug.LogFormat("Now AI want to place the Monster in {0} Hex, Name: {1}", HexToPlaceIndex, HexMap.GetChild(HexToPlaceIndex).name);
                    ChangeState(PlayerStates.Spawn_Phase);
                    break;
                case (PlayerStates.Spawn_Phase):
                    if (nowTime - stateBeginTime < 2) break;
                    //GameObject monsterClass = Resources.Load<GameObject>(CardToUsed.PrefabPath);
                    //GameObject NewMonster = Instantiate(monsterClass, HexMap.GetChild(HexToPlaceIndex));
                    PlayedCard(PlayerId, CardToUsed.id, HexToPlaceIndex);
                    ChangeState(PlayerStates.End);
                    break;
                case (PlayerStates.End):
                    Debug.Log("Now AI is in the end step, return the control back to Main Logic");
                    PlayerEnd(PlayerId);
                    ChangeState(PlayerStates.WaitForStart);
                    break;
                default:
                    Debug.Log("AIPlayerFSM_Update(): Should Not Go to Default State.");
                    break;
            }
        }
        #endregion

        #region Private Function
        /// <summary>
        /// Set myState to dstStates
        /// Set stateBeginTime to current Time
        /// </summary>
        /// <param name="dstStates">
        /// Set myState to this dstStates
        /// </param>
        private void ChangeState(PlayerStates dstStates)
        {
            Debug.LogFormat("Game Manager: Now Change to " + dstStates);
            myState = dstStates;
            stateBeginTime = Time.time;
        }
        #endregion

        #region Event Handler
        /// <summary>
        /// Call this function when Event_PlayerTurnStart invoke
        /// Change User state from WaitForStart to Main_Phase
        /// </summary>
        private void PlayerTurnStartInvoke()
        {
            if (myState == PlayerStates.WaitForStart)
            {
                myState = PlayerStates.Main_Phase;
            }
        }

        /// <summary>
        /// Call this function when Event_ScanFished invoke
        /// Change User state from Init to WaitForStart
        /// </summary>
        private void ScanFinishedInvoke()
        {
            if (myState == PlayerStates.Init)
            {
                myState = PlayerStates.WaitForStart;
            }
        }

        /// <summary>
        /// Invoked when the player is playing card
        /// </summary>
        /// <param name="PlayerId">The player id of the played card.</param>
        /// <param name="CardIndex">The played card index</param>
        /// <param name="HexIndex">The hex that card has been place on</param>
        private void PlayedCardInvoked(int PlayerId, int CardIndex, int HexIndex)
        {
            Debug.LogFormat("AIPlayer {0} playing card {1} in hex {2}", PlayerId, CardIndex, HexIndex);
            return;
        }
        #endregion
    }
}
*/
