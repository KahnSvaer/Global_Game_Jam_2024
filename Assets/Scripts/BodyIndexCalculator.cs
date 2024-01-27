using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BodyIndexCalculator : MonoBehaviour
{
    int prevIndex = 0;
    int newIndex = 0;

    Movement2 movementScript;

    [SerializeField] bool part1;
    [SerializeField] bool part2;
    [SerializeField] bool part3;
    [SerializeField] bool part4;
    [SerializeField] bool part5; 

    void Start()
    {
        movementScript = GetComponent<Movement2>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBools();
    }

    void CheckBools()
    {   
        CalculateBuildIndex();
        if(prevIndex!=newIndex)
        {
            movementScript.SetBodyIndex(newIndex);
        }
    }

    private void CalculateBuildIndex()
    {
        
    }
}
