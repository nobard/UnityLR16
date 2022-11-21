using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// координаты точки в кривой Безье
public static class BezierPoint
{
    public static Vector3 GetBezierPoint(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float parameter)
    {
        var p12 = Vector3.Lerp(p1, p2, parameter);
        var p23 = Vector3.Lerp(p2, p3, parameter);
        var p34 = Vector3.Lerp(p3, p4, parameter);

        var p123 = Vector3.Lerp(p12, p23, parameter);
        var p234 = Vector3.Lerp(p23, p34, parameter);

        var p1234 = Vector3.Lerp(p123, p234, parameter);

        return p1234;
    }

    public static Vector3 GetBezierPoint(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, Vector3 p5, float parameter)
    {
        var p12 = Vector3.Lerp(p1, p2, parameter);
        var p23 = Vector3.Lerp(p2, p3, parameter);
        var p34 = Vector3.Lerp(p3, p4, parameter);
        var p45 = Vector3.Lerp(p4, p5, parameter);

        var p123 = Vector3.Lerp(p12, p23, parameter);
        var p234 = Vector3.Lerp(p23, p34, parameter);
        var p345 = Vector3.Lerp(p34, p45, parameter);

        var p1234 = Vector3.Lerp(p123, p234, parameter);
        var p2345 = Vector3.Lerp(p234, p345, parameter);

        var p12345 = Vector3.Lerp(p1234, p2345, parameter);

        return p12345;
    }
}