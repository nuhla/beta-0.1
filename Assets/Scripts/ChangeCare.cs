using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FCG;
using VehiclePhysics;



public class ChangeCare : MonoBehaviour
{



    public GameObject trafficSystem;

    public Behaviour tt;

    public GameObject CameraController;

    private GameObject destenation;







    /// <summary>
    /// Tage to Use Is In Use Care ((InUseCare ))
    /// </summary>

    // Start is called before the first frame update
 

    private void CopyComponent(GameObject Colider)
    {



        this.trafficSystem.GetComponent<TrafficSystem>().player = Colider.transform.parent.transform;
        CameraController.SetActive(false);
        tt.enabled = false;
        Colider.GetComponent<ChangeCare>().CameraController.SetActive(true);
        destenation.GetComponent<ChangeCare>().tt.enabled = true;

        Destroy(this);

    }
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.transform.parent.gameObject.tag + "555555");
        if (other.transform.parent.gameObject.tag == "InUseCare")
        {
            destenation = other.transform.gameObject;
            CopyComponent(other.transform.gameObject);

            Debug.Log(" in If ");
        }
    }

    private void OnDestroy()
    {

    }
}
