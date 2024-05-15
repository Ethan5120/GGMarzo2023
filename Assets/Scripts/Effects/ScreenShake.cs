using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance { get; private set; }
    private CinemachineVirtualCamera virtualCamera;
    private float force;
    private float ShakeTimer;

    void Awake()
    {
        Instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    
    public void ShakeCamera(float intensity, float timer)
    {
        force = intensity;
        CinemachineBasicMultiChannelPerlin virtualCameraChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        virtualCameraChannel.m_AmplitudeGain = force;

        ShakeTimer = timer;
    }


    private void Update()
    {
        if(ShakeTimer > 0)
        {
            ShakeTimer -= Time.deltaTime;
        }
        if (ShakeTimer <= 0f)
        {
            force = 0f;
            CinemachineBasicMultiChannelPerlin virtualCameraChannel = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            virtualCameraChannel.m_AmplitudeGain = force;
        }
    }
}
