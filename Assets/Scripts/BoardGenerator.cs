using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardGenerator : MonoBehaviour
{
    public int m_boardWidth, m_boardHeight;
    public int m_pathLength, m_numberOfPaths;
    public List<Point> m_boardPoints = new List<Point>();
    public GameTile m_boardPiecePrefab, m_pathPrefabm, m_protectPrefabs;   

    public GameObject m_pointPrefab;

    private Point m_protectPoint;

    public Material[] m_highlightMaterials;
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
        SetUpMainPoint();
        SetUpPaths();
        foreach (var item in m_boardPoints.Where((bp) => bp.Tile == null))
        {
            item.SetTile(m_boardPiecePrefab);
        }
    }

    void GenerateBoard(){
        transform.position = new Vector3(-(m_boardWidth/2f),0f,-(m_boardHeight/2f));
        for(int x=0; x<m_boardWidth; x++){
            for(int z=0;z<m_boardHeight; z++){
                var obj = Instantiate(m_pointPrefab).GetComponent<Point>();
                obj.SetPoint(x,z);
                m_boardPoints.Add(obj);
            }
        }
    }

    public Point SelectPoint(){
        var randomPoint = Random.Range(0,m_boardPoints.Count);
        return m_boardPoints[randomPoint];
    }

    void SetUpMainPoint(){
        m_protectPoint = SelectPoint();
        m_protectPoint.SetTile(m_protectPrefabs);
    }

    void SetUpPaths(){
        List<Point> path = new List<Point>();
        path.Add(m_protectPoint);
        for(int i=1; i < m_pathLength; i++){
            var allNeigh = GetNeighbours(path[path.Count-1]);
            var possibleNeigh = allNeigh.Where((p) => GetNeighbours(p).Except(path).Count() == GetNeighbours(p).Count);
            var randomBtnNeigh = possibleNeigh.Random();
            path.Add(randomBtnNeigh);
        }

        var pathPoints = m_boardPoints.Where((bp) => path.Contains(bp));
        foreach(var p in pathPoints){
            p.SetTile(m_pathPrefabm);
        }
    }

    public List<Point> GetNeighbours(Point p){
        var points = new List<Point>();
            if(p.X+1 < m_boardWidth)   points.Add(m_boardPoints[((p.X+1)*m_boardHeight) + p.Z]);
            if(p.X-1 >= 0)  points.Add(m_boardPoints[((p.X-1)*m_boardHeight) + p.Z]);
            if(p.Z-1 >= 0)  points.Add(m_boardPoints[(p.X*m_boardHeight) + (p.Z-1)]);
            if(p.Z+1 < m_boardHeight)  points.Add(m_boardPoints[(p.X*m_boardHeight) + (p.Z+1)]);
        return points;
    }

    bool InsideBoundaries(Point p){
        return (p.X < m_boardWidth && p.X >= 0 && p.Z < m_boardHeight && p.Z >= 0);
    }
}
