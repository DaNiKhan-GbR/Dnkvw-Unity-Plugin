using UnityEngine;
using System;

using DnkvwHandle = System.IntPtr;

public class DnkvwCamera : MonoBehaviour
{
    public int cameraId = 0;

    public Camera targetCamera;

    private DnkvwHandle dnkvw;

    // Start is called before the first frame update
    void Start()
    {
        // create and configure a new dnkvw context
        dnkvw = Dnkvw.dnkvw_createContext();
        Dnkvw.dnkvw_selectDnnTracker(dnkvw);
        Dnkvw.dnkvw_configureFrustum(dnkvw, Screen.width / (float) Screen.height, targetCamera.nearClipPlane);

        // start tracking
        Dnkvw.dnkvw_startTracking(dnkvw, cameraId);

        // initial calibration. Not required, but improves user experience.
        Dnkvw.dnkvw_calibrate(dnkvw);
    }

    void Update()
    {
        float left = 0, right = 0, top = 0, bottom = 0;
        float x = 0, y = 0, z = 0;

        // read and apply eyeOffset
        Dnkvw.dnkvw_loadEyeOffset(dnkvw, ref x, ref y, ref z);
        Vector4 eyePos = new Vector3(x, y, z);
        
        Dnkvw.dnkvw_loadFrustum(dnkvw, ref left, ref right, ref top, ref bottom);

        Matrix4x4 P = Matrix4x4.Frustum(left, right, bottom, top, targetCamera.nearClipPlane, targetCamera.farClipPlane);

        //Translation to eye position        
        //Matrix4x4 T = Matrix4x4.Translate(eyePos);
        //Matrix4x4 T = Matrix4x4.Translate(eyePos);

        // TODO: Verzerrungslösung?
        //Matrix4x4 R = Matrix4x4.Rotate(
        //    Quaternion.Inverse(transform.rotation) * ProjectionScreen.transform.rotation);

        //targetCamera.worldToCameraMatrix = Matrix4x4.identity * T;

        targetCamera.transform.localPosition = eyePos;

        targetCamera.projectionMatrix = P;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dnkvw.dnkvw_calibrate(dnkvw);
        }

    }    

    void OnDestroy()
    {
        // stop & cleanup        
        Dnkvw.dnkvw_stopTracking(dnkvw);
        unsafe
        {
            void* dnkvwPtr = dnkvw.ToPointer();
            Dnkvw.dnkvw_freeContext(new IntPtr(&dnkvwPtr));
        }

    }

}

