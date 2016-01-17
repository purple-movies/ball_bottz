using UnityEngine;
using System.Collections;
using System;

public class HintZoneUi : CollisionZone2d.CollisionZone2dListenerBase
{
    Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    override public void onEnter(Collider2D collider)
    {
        canvas.enabled = true;
    }

    override public void onStay(Collider2D collider)
    {
        canvas.enabled = true;
    }

    override public void onExit(Collider2D collider)
    {
        canvas.enabled = false;
    }
}
