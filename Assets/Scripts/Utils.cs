
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class Extension{
    public static Point Random(this IEnumerable<Point> collection){
        return collection.ElementAt(UnityEngine.Random.Range(0,collection.Count<Point>()));
    }

    public static Vector3 PointToVec(this Point p){
        return new Vector3(p.X,0f,p.Z);
    }
}

public enum BuildingType{
    Turret,
    Enviroment,
    Trap
}