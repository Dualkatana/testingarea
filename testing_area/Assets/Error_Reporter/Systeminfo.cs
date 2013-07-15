using UnityEngine;
using System.Collections;

public class Systeminfo : MonoBehaviour
{
	void Start()
	{
		Debug.Log( "deviceModel:"+SystemInfo.deviceModel );
		Debug.Log( "deviceName:"+SystemInfo.deviceName );
		Debug.Log( "deviceType:"+SystemInfo.deviceType );
		Debug.Log( "systemMemorySize:"+SystemInfo.systemMemorySize );
		Debug.Log( "deviceUniqueIdentifier:"+SystemInfo.deviceUniqueIdentifier );
		Debug.Log( "graphicsDeviceID:"+SystemInfo.graphicsDeviceID );
		Debug.Log( "graphicsDeviceName:"+SystemInfo.graphicsDeviceName );
		Debug.Log( "graphicsDeviceVendor:"+SystemInfo.graphicsDeviceVendor );
		Debug.Log( "graphicsDeviceVendorID:"+SystemInfo.graphicsDeviceVendorID );
		Debug.Log( "graphicsDeviceVersion:"+SystemInfo.graphicsDeviceVersion );
		Debug.Log( "graphicsMemorySize:"+SystemInfo.graphicsMemorySize );
		Debug.Log( "graphicsPixelFillrate:"+SystemInfo.graphicsPixelFillrate );
		Debug.Log( "graphicsShaderLevel:"+SystemInfo.graphicsShaderLevel );
		Debug.Log( "operatingSystem:"+SystemInfo.operatingSystem );
		Debug.Log( "processorCount:"+SystemInfo.processorCount );
		Debug.Log( "processorType:"+SystemInfo.processorType );
		Debug.Log( "supportedRenderTargetCount:"+SystemInfo.supportedRenderTargetCount );
		Debug.Log( "supportsAccelerometer:"+SystemInfo.supportsAccelerometer );
		Debug.Log( "supportsGyroscope:"+SystemInfo.supportsGyroscope );
		Debug.Log( "supportsImageEffects:"+SystemInfo.supportsImageEffects );
		Debug.Log( "supportsLocationService:"+SystemInfo.supportsLocationService );
		Debug.Log( "supportsRenderTextures:"+SystemInfo.supportsRenderTextures );
		Debug.Log( "supportsShadows:"+SystemInfo.supportsShadows );
		Debug.Log( "supportsVertexPrograms:"+SystemInfo.supportsVertexPrograms );
		Debug.Log( "supportsVibration:"+SystemInfo.supportsVibration );

	}

	void Update()
	{
	
		
	}
}
