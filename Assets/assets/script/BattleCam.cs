using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCam : MonoBehaviour
{
    public Camera mainCam;
    public Transform mainCamTrans;
    public Transform polyTrans;
    public GameObject polyObj;
    public Transform foeTrans;
    public GameObject foeObj;
    public Vector3 targetPosition;
    public float smoothTime = 0.4f;
    private Vector3 velocity = Vector3.zero;
    private float zeroVelo = 0.0f;
    public float camSize = 1;
    public GameObject battleObject;
    public enum TargetStatus {LookPoly, LookFoe, LookInbetween,}
    public enum ZoomSize {Default, LowZoomIn, MediumZoomIn, HighZoomIn, LowZoomOut, MediumZoomOut, HighZoomOut}
    public TargetStatus TStatus = TargetStatus.LookInbetween;
    public ZoomSize zoomStatus = ZoomSize.Default;
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, TargetSDamp(), ref velocity, smoothTime);
        mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, CamSize(), ref zeroVelo, smoothTime);
    }

    float CamSize()
    {
        switch (zoomStatus)
        {
            case ZoomSize.Default:
                return 1f;

            case ZoomSize.LowZoomIn:
                return 0.75f;

            case ZoomSize.MediumZoomIn:
                return 0.5f;

            case ZoomSize.HighZoomIn:
                return 0.25f;

            case ZoomSize.LowZoomOut:
                return 1.25f;

            case ZoomSize.MediumZoomOut:
                return 1.5f;

            case ZoomSize.HighZoomOut:
                return 1.75f;

            default:
                return 1f;
        }
    }

    Vector3 TargetSDamp()
    {
        switch(TStatus)
        {
            case TargetStatus.LookPoly:
                return new Vector3(polyTrans.position.x, polyTrans.position.y, -10);

            case TargetStatus.LookFoe:
                return new Vector3(foeTrans.position.x, foeTrans.position.y, -10);

            case TargetStatus.LookInbetween:
                return new Vector3(-714.8f, -264.88f, -10f);

            default:
                Debug.Log("camera dun goofed");
                return new Vector3(0, 0, 0);
        }
    }
}
