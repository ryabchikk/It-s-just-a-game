using UnityEngine;

public enum Axis
{
    Side,
    Forward,
    MouseHorizontal,
    MouseVertical
}

public static class Controls
{
    public static KeyCode Left { get; set; } = KeyCode.A;
    public static KeyCode Right { get; set; } = KeyCode.D;
    public static KeyCode Jump { get; set; } = KeyCode.Space;
    public static KeyCode Forward { get; set; } = KeyCode.W;
    public static KeyCode Back { get; set; } = KeyCode.S;
    public static KeyCode Interact { get; set; } = KeyCode.E;
    public static KeyCode RotateRoom { get; set; } = KeyCode.R;
    public static int MouseHorizontal { get; set; } = 1;
    public static int MouseVertical { get; set; } = 1;

    public static bool NormalJump { get; set; } = true;
    

    public static void Invert(Axis axis)
    {
        switch (axis)
        {
            case Axis.Side:
                (Left, Right) = (Right, Left);
                break;
            case Axis.Forward:
                (Forward, Back) = (Back, Forward);
                break;
            case Axis.MouseHorizontal:
                MouseHorizontal *= -1;
                break;
            case Axis.MouseVertical:
                MouseVertical *= -1;
                break;
        }
    }

    public static bool ShoulJump()
    {
        if (NormalJump)
        {
            return Input.GetKey(Controls.Jump);
        }
        else
        {
            return !Input.GetKey(Controls.Jump);
        }
    }

    public static void Reset()
    {
        Left = KeyCode.A;
        Right = KeyCode.D;
        Jump = KeyCode.Space;
        Forward = KeyCode.W;
        Back = KeyCode.S;
        Interact = KeyCode.E;
    }
}
