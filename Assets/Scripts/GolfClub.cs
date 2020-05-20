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

    private Vector2 hitVector;





    void Start()
    {

    }


    void Update()
    {

    }

    public void ProcessDrag(TouchUserInput tui)
    {
        if(tui.InputState == TouchUserInput.State.Up)
        {
            hitVector = tui.InputPos - tui.InputPosLastDown;
            hitValue.Value = hitpower * hitVector;

        }
       else if (tui.InputState == TouchUserInput.State.Up)
        {
            
            ballRb2D.AddForce(hitValue.Value, ForceMode2D.Impulse);
            hitValue.Value = Vector2.zero;
        }
    }
}
