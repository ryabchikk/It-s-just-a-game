using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    Side,
    Forward
}

public class Controls
{
    public static KeyCode Left { get; private set; } = KeyCode.A;
    public static KeyCode Right { get; private set; } = KeyCode.D;
    public static KeyCode Jump => KeyCode.Space;
    public static KeyCode Forward { get; private set; } = KeyCode.W;
    public static KeyCode Backward { get; private set; } = KeyCode.S;
    public static KeyCode PickUp { get; private set; } = KeyCode.E;

    public static void Invert(Axis axis)
    {
        switch (axis)
        {
            case Axis.Side:
                (Left, Right) = (Right, Left);
                break;
            case Axis.Forward:
                (Forward, Backward) = (Backward, Forward);
                break;
        }
    }
}
