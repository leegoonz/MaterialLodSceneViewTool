using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine.Serialization;

[System.Serializable]
[ExecuteInEditMode]
public class SwitchMaterialSwapLod : MonoBehaviour
{

    public int[] matLodDistance;
    public Material[] lodMat;
    Renderer _rend;
    [NonSerialized] public float UpdataTime = 0.1f;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private Camera _camera;


    void Start()
    {
        _camera = Camera.main;
        _skinnedMeshRenderer = this.GetComponent<SkinnedMeshRenderer>();
        _rend = GetComponent<Renderer>();
        StartCoroutine(nameof(UpdateMatLod));
    }



    IEnumerator UpdateMatLod()
    {
        var period = UpdataTime;
        if (_camera != null)
        {
            var cam = _camera.transform;
            while (true)
            {
                var distance = (int)(transform.position - cam.position).sqrMagnitude;
                
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                Debug.Log("type cast distance : " + distance);
                
                // make LOD checking non deterministic. avoids stampeding LOD calls?
                yield return new WaitForSeconds(period);
            }
        }
    }
}