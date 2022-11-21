using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[ExecuteInEditMode]

// провода платформы индуктора
public class PlatformWires : MonoBehaviour
{
    [SerializeField] GameObject placeToConnect;
    [SerializeField] Material material;
    [SerializeField] GameObject helpPoint;
    
    LineRenderer lr;
    Vector3[] points;
    int PointsCount = 60;
    Transform End;
    Transform start;


    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        End = placeToConnect.transform;
        start = gameObject.transform;
        lr.startWidth = 0.028f;
        lr.endWidth = 0.028f;
        lr.material = material;
        lr.positionCount = PointsCount;
        ConnectSlots(End);
    }

    void FixedUpdate()
    {
        ConnectSlots(placeToConnect.transform);
    }

    // соединение коннекторов
    void ConnectSlots(Transform end)
    {
        if (points == null || points.Length != PointsCount)
            points = new Vector3[PointsCount];
 
        Lerp(start, end, PointsCount);
        lr.SetPositions(points.ToArray());
    }
 
    // заполнение массива точками, "координаты" всего провода в пространстве
    private void Lerp(Transform Start, Transform end, int count)
    {
        var L = (Start.position - end.position);
        var D = L.magnitude + 0.001f;
        var P0 = Start.position;
        var P1 = Start.position + Start.forward;
        var P2 = helpPoint.transform.position;
        var P3 = end.position + end.forward * D / 5;
        var P4 = end.position;
 
        for (int i = 0; i < count; i++)
        {
            var parameter = (float)i / (count - 1);   
            var P1234 = BezierPoint.GetBezierPoint(P0, P1, P2, P3, P4, parameter);

            points[i] = P1234;
        }
    }
}
