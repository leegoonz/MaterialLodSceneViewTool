using UnityEngine;
using System.Collections;
[System.Serializable]
[ExecuteInEditMode]
public enum EditableMaterialsList
{
    Lod0,
    Lod1,
    Lod2
};
 
[ExecuteInEditMode]
public class ArtistMaterialSetLOD : MonoBehaviour
{
    public bool editMode = true;
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public EditableMaterialsList editableMaterialsList = EditableMaterialsList.Lod0;

    private Renderer _rend;
    private Renderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
#if UNITY_EDITOR
    private void UpdateMatLod()
    {
        _rend = _renderer;
        if (UnityEditor.EditorApplication.isPlaying)
        {
            editMode = false;
        }
        else editMode = true;
 
        if (!editMode)
        {
            return;
        }
        else
        {
            switch (editableMaterialsList)
            {
                case EditableMaterialsList.Lod0:
                    _rend.material = mat1;
                    break;
                case EditableMaterialsList.Lod1:
                    _rend.material = mat2;
                    break;
                case EditableMaterialsList.Lod2:
                    _rend.material = mat3;
                    break;
                default:
                    break;
            }
        }
      
    }


    private void Update()
    {
        UpdateMatLod();
    }
#endif
 
}