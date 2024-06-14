using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class DisableGrabbingHandComponent : MonoBehaviour
{

    public GameObject LeftHandModel;
    public GameObject RightHandModel;


    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInterable = GetComponent<XRGrabInteractable>();
        grabInterable.selectEntered.AddListener(HideGrabbingHand);
        grabInterable.selectExited.AddListener(ShowGrabbingHand);

    }

    public void HideGrabbingHand(SelectEnterEventArgs args){

            if(args.interactorObject.transform.tag == "Left Hand"){
                LeftHandModel.SetActive(false);
            }else if(args.interactorObject.transform.tag == "Right Hand"){
                RightHandModel.SetActive(false);
            }
    }

    public void ShowGrabbingHand(SelectExitEventArgs args){
            if(args.interactorObject.transform.tag == "Left Hand"){
                LeftHandModel.SetActive(true);
            }else if(args.interactorObject.transform.tag == "Right Hand"){
                RightHandModel.SetActive(true);
            }
    }
    
}
