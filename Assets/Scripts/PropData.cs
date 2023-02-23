using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Props/PropData")]
public class PropData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private Mesh mesh;
    [SerializeField] private List<Material> materials;
    [SerializeField] private Material imageMaterial;

    public int Id
    {
        get
        {
            return id;
        }
    }
    public Mesh Mesh
    {
        get
        {
            return mesh;
        }
    }

    public List<Material> Materials
    {
        get
        {
            return materials;
        }
    }

    public Material ImageMaterial
    {
        get { return imageMaterial; }
    }
}
