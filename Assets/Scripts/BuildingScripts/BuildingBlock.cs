using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuildingBlock : GameTile, IBuildable
{
    public BuildingType[] m_buildableBlocks;
    protected Building m_building;

    protected Vector3 m_buildingPoint;

    public Building Building {
        get { return m_building; }
        private set{
            m_building = value;
        }
    }

    public Vector3 BuildingPoint => m_buildingPoint;

    public void Build(Building _building)
    {
        Building = _building;
        Instantiate(_building.gameObject, m_buildingPoint, Quaternion.identity);
    }

    public Building GetBuilding()
    {
        return Building;
    }

    public bool IsBuildable(BuildingType _type)
    {
        return m_buildableBlocks.Contains(_type);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
