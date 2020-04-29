using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityAtoms.Mobile;
using UnityEngine;

public class GolfClub : MonoBehaviour

{
    public FloatReference hitpower;
    public Vector2Variable hitValue;
    public Rigidbody2D ballRb2D;






    void Start()
    {

    }


    void Update()
    {

    }

    public void ProcessDrag(TouchUserInput tui)
    {

        if (tui.InputState == TouchUserInput.State.Up)
        {
            Vector2 hitVector = tui.InputPos - tui.InputPosLastDown;
            hitValue.Value = hitpower * hitVector;
            ballRb2D.AddForce(hitValue.Value);
        }
    }
}
