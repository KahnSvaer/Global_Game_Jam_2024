using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    private Animator anim;
    public Transform torso;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "torso"){
            Debug.Log("0");
        }
        
    }
    
}
