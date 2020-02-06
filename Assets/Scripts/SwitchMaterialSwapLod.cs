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
                var distance = (transform.position - cam.position).sqrMagnitude;
                int intDistance = Mathf.RoundToInt(distance);
                if (intDistance > matLodDistance[2])
                {
                    Debug.Log("*************************current mat is LOD2");
                    _rend.material = lodMat[2];
                }
                else if (intDistance > matLodDistance[1])
                {
                    Debug.Log("*************current mat is LOD1");
                    _rend.material = lodMat[1];
                }
                else if(intDistance > matLodDistance[0])
                {
                    Debug.Log("*****current mat is LOD0");
                    _rend.material = lodMat[0];
                }
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                Debug.Log("type cast distance : " + intDistance);
                
                // make LOD checking non deterministic. avoids stampeding LOD calls?
                yield return new WaitForSeconds(period);
            }
        }
    }
}