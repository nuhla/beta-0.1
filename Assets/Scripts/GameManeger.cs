using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FCG;
using VehiclePhysics;

public class GameManeger : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject trafficSystem;
    [SerializeField] GameObject HumanPrefab;
    

    public Transform CurrentPlayer;
    public Transform PrevoiusePlayer;
    public Transform NextPlayer = null;


    private void Start()
    {
        /*-------------------------------------------------
         ------------ get the current player if we --------
        ----------------have a traffic system -------------
        ---------------------------------------------------
         */
        if(trafficSystem != null)
        {

            Debug.Log(" traffic system is not null");
            CurrentPlayer = trafficSystem.GetComponent<TrafficSystem>().player;

            Debug.Log(CurrentPlayer.gameObject.name);
        }
        else if(trafficSystem == null)
        {
           trafficSystem = GameObject.Find("TrafficSystem") ;
            Debug.Log("Searched for traffic system and its value : "+ trafficSystem.gameObject.name);


            if(trafficSystem == null)
            {
                Debug.Log("attempting to create a traffic system ");
                /*------------------------------------------------------------------
                 --------------- we need to create a trafficSystem -----------------
                 -----------------------------------------------------------------*/
            }
            else
            {
                trafficSystem.gameObject.SetActive(true);
            }

        }
    }

    private void Update()
    {




        if (Input.GetKeyDown(KeyCode.O))
        {
            /** 
             * we will get the curren user and stope the cat 
             * if there is a nother care to Ride 
            **/
            if (CurrentPlayer != null)
            {
                // here we check the speed in case the user is still driving 
                if(CurrentPlayer.gameObject.GetComponentInChildren<VehicleBehaviour>().vehicle.speed > 0)
                {
                    Debug.Log(CurrentPlayer.gameObject.GetComponentInChildren<VehicleBehaviour>().vehicle.speed + " speed");

                    CurrentPlayer.gameObject.GetComponentInChildren<VehicleBehaviour>().vehicle.enabled = false;

                    exsitCar();


                }
                else
                {
                    // also show the user behind the care //
                    /// affter that we disable the whole care from the sceen .
                    ///  to Ride the secound Care
                }


            }
            else
            {
                Debug.Log("current player is null");
            }


            Debug.Log(" KEYDOWN IS E" );
            
        }


    }

    public void exsitCar() {

        Debug.Log("In Exit Care ");
        HumanPrefab.SetActive(true);
        HumanPrefab.transform.position = CurrentPlayer.gameObject.GetComponentInChildren<ChangeCare>().tt.transform.position +
        CurrentPlayer.TransformDirection(Vector3.left) + CurrentPlayer.TransformDirection(Vector3.left) + CurrentPlayer.TransformDirection(Vector3.up);


        CurrentPlayer.gameObject.GetComponentInChildren< ChangeCare >().tt.enabled= false;
        CurrentPlayer.gameObject.GetComponentInChildren<ChangeCare>().CameraController.SetActive(false);
        //CurrentPlayer = NextPlayer;
        //NextPlayer = null;

        Debug.Log("End Exit Care ");

    }



    public void EnterCre()
    {
        HumanPrefab.SetActive(false);

        /*--------------------- Switch Cars If User Wants ----------------------
             CurrentPlayer.GetComponent<ChangeCare>().CameraController.SetActive(true);
             CurrentPlayer.GetComponent<ChangeCare>().tt.enabled = true;
             */
    }


}
