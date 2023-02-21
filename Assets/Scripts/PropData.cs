using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Props/PropData")]
public class PropData : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private Mesh mesh;

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
}
