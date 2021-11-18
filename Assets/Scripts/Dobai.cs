using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dobai : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        AnimatorIsPlaying();
        AnimatorIsPlaying("AndarDobai1");
    }

    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    bool AnimatorIsPlaying(string stateName)
    {
        Debug.Log("SEILA");
        return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
        
    } 
}
