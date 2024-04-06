using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FCG;
using VehiclePhysics;



public class ChangeCare : MonoBehaviour
{



    public GameObject trafficSystem;
    [SerializeField] GameObject gameManeger;

    public Behaviour tt;

    public GameObject CameraController;

    private GameObject destenation;

    private GameObject Player;







    /// <summary>
    /// Tage to Use Is In Use Care ((InUseCare ))
    /// </summary>

    // Start is called before the first frame update


    private void SetCarOrder(GameObject Colider)
    {


        Debug.Log("Start Set Order ");
        trafficSystem.GetComponent<TrafficSystem>().player = Colider.transform.transform;
        //CameraController.SetActive(false);
        //tt.enabled = false;


        //gameManeger.GetComponent<GameManeger>().NextPlayer = destenation.transform;

        gameManeger.GetComponent<GameManeger>().CurrentPlayer = this.transform.parent.transform;



        Debug.Log("End Set Order ");


    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform != null)
        {

            // if (other.transform.parent.gameObject.tag == "InUseCare")
            // {
            //     destenation = other.transform.parent.gameObject;
            //     SetCarOrder(other.transform.parent.gameObject);

            //     Debug.Log("OnTriggerEnter");
            // }

            if (other.transform.parent.gameObject.tag == "PlayerChar")
            {
                Player = other.transform.parent.gameObject;
                destenation = transform.parent.gameObject;
                gameManeger.GetComponent<GameManeger>().NextPlayer = transform.parent;

                Debug.Log("PlayerChar Trigger");
            }
        }
    }


}
