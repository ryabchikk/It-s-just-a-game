using UnityEngine;

public static class FPS
{
    public static void LockAt(int target)
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    public static void Unlock()
    {
        QualitySettings.vSyncCount = 4;
        Application.targetFrameRate = 1000;
    }
}
