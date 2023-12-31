using System.Runtime.InteropServices;
/// <summary>
/// Class with a JS Plugin functions for WebGL.
/// </summary>
public static class WebGLPluginJS
{
    // Importing "CallFunction"
    [DllImport("__Internal")]
    public static extern void CallFunction();
    //Importing SetLeder
    [DllImport("__Internal")]
    public static extern void SetLeder(int best);
    
    //Importing GetAuth
    [DllImport("__Internal")]
    public static extern string GetAuth();
    //Importing GetAdsOpen
    [DllImport("__Internal")]
    public static extern string GetAdsOpen();
    // Importing SetAuth
    [DllImport("__Internal")]
    public static extern void SetAuth();
    // Importing "Hello"
    [DllImport("__Internal")]
    public static extern void Hello();
    // Importing "ShareFunction" add ksimaster
    [DllImport("__Internal")]
    public static extern void ShareFunction();
    // Importing "RewardFunction" add ksimaster
    [DllImport("__Internal")]
    public static extern void RewardFunction();
    // Importing "InterstitialFunction" add ksimaster
    [DllImport("__Internal")]
    public static extern void InterstitialFunction();
    // Importing "PassTextParam"
    [DllImport("__Internal")]
    public static extern void PassTextParam(string text);

    [DllImport("__Internal")]
    public static extern void PassNumberParam(int number);
    // Importing "GetTextValue"
    [DllImport("__Internal")]
    public static extern string GetTextValue();
    // Importing "GetNumberValue"
    [DllImport("__Internal")]
    public static extern int GetNumberValue();

    //Importing GetTypeDevice
    [DllImport("__Internal")]
    public static extern string GetTypeDevice();
}