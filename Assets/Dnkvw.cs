using System;
using System.Runtime.InteropServices;

using DnkvwHandle = System.IntPtr;


public class Dnkvw
{
    
    //Lets make our calls from the Plugin
    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern DnkvwHandle dnkvw_createContext();

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_freeContext(IntPtr context);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_setLogLevel(DnkvwHandle context, int logLevel);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_setInternalLogLevel(DnkvwHandle context, int internalLogLevel);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern int dnkvw_selectHaarTracker(DnkvwHandle context);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern int dnkvw_selectDnnTracker(DnkvwHandle context);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern int dnkvw_startTracking(DnkvwHandle context, int cameraId);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_stopTracking(DnkvwHandle context);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_stopTrackingAsync(DnkvwHandle context);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_configureFrustum(DnkvwHandle context, float aspectRatio, float nearPlane);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_calibrate(DnkvwHandle context);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_loadFrustum(DnkvwHandle context, ref float left, ref float right, ref float top, ref float bottom);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_loadEyeOffset(DnkvwHandle context, ref float x, ref float y, ref float z);

    [DllImport("dnkvw", CallingConvention = CallingConvention.Cdecl)]
    public static extern void dnkvw_loadFps(DnkvwHandle context, ref float fps);

}
