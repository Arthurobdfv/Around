using UnityEngine;

public class Point : MonoBehaviour {

    private int m_x;
    private int m_z;
    public int X {
        get { return m_x; }
        set { 
            m_x = value; 
            PositionChanged();
        }
    }
    public int Z {
        get { return m_z; }
        set { 
            m_z = value;
            PositionChanged();
        }
    }

    private GameTile m_thisTile;
    public GameTile Tile {
        get { return m_thisTile; }
        private set {
            m_thisTile = Tile;
        }
    }

    public void SetTile(GameTile _tile){
        if(Tile != null) Destroy(Tile.gameObject);
        Tile = Instantiate(_tile, transform.position, Quaternion.identity);
    }

    void PositionChanged(){
        transform.position = this.PointToVec();
    }

    public void SetPoint(int _x, int _z){
        m_x = _x;
        m_z = _z;
        PositionChanged();
    }
}