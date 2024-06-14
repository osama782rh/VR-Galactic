using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem  particles;
    public LayerMask layerMask;
    public Transform shootSoucre;
    public float distance=10;

    private bool rayActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInterable = GetComponent<XRGrabInteractable>();
        grabInterable.activated.AddListener(x => Startshoot());
        grabInterable.deactivated.AddListener(x => Stopshoot());
    }

    public void Startshoot(){
        particles.Play();
        rayActivate = true;
    }

    public void Stopshoot(){
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rayActivate)
            RaycastCheck();
    }

    void RaycastCheck(){
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSoucre.position, shootSoucre.forward, 
            out hit, distance, layerMask);

        if(hasHit){
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);

        }
    }
}
