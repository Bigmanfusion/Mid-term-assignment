using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Gameover; 
    public GameObject replaybutton;
    public GameObject player;
    public GameObject BeaSpawner;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        Gameover,

    }
    GameManagerState GMState;
    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                replaybutton.SetActive(true);

                Gameover.SetActive(true);

                break;
            case GameManagerState.Gameplay:
              


                player.GetComponent<PlayerControl>().Init();

                BeaSpawner.GetComponent<BeaSpawner>().ScheduleBeaSpawner();

                break;
            
            case GameManagerState.Gameover:

               // BeaSpawner.GetComponent<BeaSpawner>().UnscheduledBeaSpawner();

                replaybutton.SetActive(true);


                Gameover.SetActive(true);

                //Invoke("ChangeToOpeningState", 2f);

                break;
        }
    }

        public void SetGameManagerState(GameManagerState state)
        {

            GMState = state; 
            UpdateGameManagerState();
        }

         public void StartGamePlay()
        {
                GMState =GameManagerState.Gameplay;
                UpdateGameManagerState();

        }

    public void ChangeToOpeningState()
    {

        SetGameManagerState(GameManagerState.Opening);

    }

   // internal void SetGameManagerState(object gameover)
   // {
     //   throw new NotImplementedException();
  //  }
}

