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
    [SerializeField] List<GameObject> CarsList;

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

            if (CarsList.Count != 0)
            {

                foreach (GameObject car in CarsList)
                {

                    car.gameObject.GetComponentInChildren<ChangeCare>().tt.enabled = false;
                    car.gameObject.GetComponentInChildren<ChangeCare>().CameraController.SetActive(false);
                    //car.gameObject.GetComponentInChildren<VPVehicleController>().enabled = false;

                }

            }
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



            CurrentPlayer.gameObject.GetComponentInChildren<VehicleBehaviour>().vehicle.enabled = false;
            //CurrentPlayer.gameObject.GetComponentInChildren<VPVehicleController>().enabled = false;

            exsitCar();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(" KEYDOWN IS E");
            EnterCare();


        }


    }

    public void exsitCar() {


        HumanPrefab.transform.parent.gameObject.SetActive(true);
        Debug.Log(CurrentPlayer.gameObject.tag + " uuuuuuuuuuuuuuuuus");
        HumanPrefab.transform.position = CurrentPlayer.position +
        CurrentPlayer.TransformDirection(Vector3.left) + CurrentPlayer.TransformDirection(Vector3.up);


        CurrentPlayer.gameObject.GetComponentInChildren< ChangeCare >().tt.enabled= false;
        CurrentPlayer.gameObject.GetComponentInChildren<ChangeCare>().CameraController.SetActive(false);
        //CurrentPlayer.gameObject.SetActive(false);
        CurrentPlayer = null;
        //NextPlayer = null;

        Debug.Log("End Exit Care ");



    }



    public void EnterCare()
    {
        Debug.Log("In the Enter Care ");
        if (NextPlayer != null)
        {
            Debug.Log("Necxt Player Is Not Null");
            CurrentPlayer = NextPlayer;
            NextPlayer = null;
            HumanPrefab.transform.parent.gameObject.SetActive(false);
            CurrentPlayer.gameObject.GetComponentInChildren<ChangeCare>().tt.enabled = true;
            CurrentPlayer.gameObject.GetComponentInChildren<ChangeCare>().CameraController.SetActive(true);

            trafficSystem.GetComponent<TrafficSystem>().player = CurrentPlayer.parent.transform;

        }



    }


}
