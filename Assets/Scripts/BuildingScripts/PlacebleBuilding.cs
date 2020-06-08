using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class PlacebleBuilding : Building, IPlacebleBuilding {

    public Material m_badPlacement, m_goodPlacement;

    private bool m_placed;

    public List<Renderer> m_renderers = new List<Renderer>();
    public List<Material> m_originalMats  = new List<Material>();

    public Material BadPlacementMat => m_badPlacement;

    public Material GoodPlacementMat => m_goodPlacement;

    public Renderer[] Renderer => m_renderers.ToArray();

    public bool IsPlaced => m_placed;

    public void SetPlacementMaterial(bool placeble)
    {
        foreach(var rend in m_renderers){
            List<Material> mats = new List<Material>();
            for(int i=0 ; i< rend.materials.Length; i++){
                mats.Add(new Material(placeble ? m_goodPlacement : m_badPlacement));
            }
            rend.materials = mats.ToArray();
        } 
    }

    void Start(){
        SetUpMaterialsAndRenderers();
    }

    void SetUpMaterialsAndRenderers(){
        m_renderers = GetComponentsInChildren<Renderer>().ToList();
        foreach(var r in m_renderers){
            m_originalMats.AddRange(r.materials);
        }
    }

    public void Build()
    {
        throw new NotImplementedException();
    }
}