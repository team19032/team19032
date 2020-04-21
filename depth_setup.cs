using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class depth_setup : MonoBehaviour {

    private Material _material;
	private RenderTexture _renderTexture;

	// Use this for initialization
	void Start () {
        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth;
        //_renderTexture = new RenderTexture(171, 224, 1);
        //cam.targetTexture = _renderTexture;
        //RenderTexture.active = _renderTexture;
        Matrix4x4 viewMat = cam.worldToCameraMatrix;
        Matrix4x4 projMat = GL.GetGPUProjectionMatrix(cam.projectionMatrix, false);
        Matrix4x4 viewProjMat = (projMat * viewMat);
        Shader.SetGlobalMatrix("_ViewProjInv", projMat.inverse);

        _material = new Material(Shader.Find("Custom/DepthShader"));
	}
	
	// Update is called once per frame
	void Update () {
		//if (!_renderTexture.IsCreated())
		//{
		//	_renderTexture.Create();
		//}

	}
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination,_material);
    }
}
