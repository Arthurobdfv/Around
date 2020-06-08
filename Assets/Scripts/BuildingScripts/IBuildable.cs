using System;
using UnityEngine;

public interface IBuildable {

    Vector3 BuildingPoint { get; }

    bool IsBuildable(BuildingType _type);

    void Build(Building _building);

    Building GetBuilding();
}

public interface IBuildingPlacement {
    void Hover();
}

public interface IPlacebleBuilding {

    bool IsPlaced { get; }

    Material BadPlacementMat { get; }
    Material GoodPlacementMat { get; }

    Renderer[] Renderer { get; }

    void SetPlacementMaterial(bool placeble);

    void Build();
}