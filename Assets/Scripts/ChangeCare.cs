using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FCG;
using VehiclePhysics;



public class ChangeCare : MonoBehaviour
{



    public GameObject trafficSystem;

    public Behaviour tt;

    public GameObject destroyBehv;

    public GameObject CameraController;

    private GameObject destenation;







    /// <summary>
    /// Tage to Use Is In Use Care ((InUseCare ))
    /// </summary>

    // Start is called before the first frame update
 

    private void CopyComponent(GameObject Colider)
    {



        if (transform != null)
        {


            trafficSystem.GetComponent<TrafficSystem>().player = Colider.transform.transform;
            CameraController.SetActive(false);
            tt.enabled = false;

            Debug.Log(Colider.transform.tag + "555555");

            //Colider.GetComponent<ChangeCare>().GetComponent<TrafficSystem>().player = Colider.transform.transform;
            destenation.GetComponent<ChangeCare>().CameraController.SetActive(true);
        destenation.GetComponent<ChangeCare>().tt.enabled = true;
            
            this.transform.parent.gameObject.SetActive(false);
            // Destroy(this);


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform != null)
        {


            if (other.transform.parent.gameObject.tag == "InUseCare")
            {
                destenation = other.transform.gameObject;
                CopyComponent(other.transform.parent.gameObject);

                Debug.Log(" in If ");
        }
    }
    }

    private void OnDestroy()
    {

    }
}
