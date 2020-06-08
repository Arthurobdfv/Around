using UnityEngine;

public class Building : MonoBehaviour{
    protected int m_maxHealth;
    protected int m_health;
    protected BuildingType m_buildingType;

    public int MaxHealth{
        get{ return m_health; }
        protected set {
            m_maxHealth = MaxHealth;
        }
    }

    public int Health {
        get { return m_health; }
        protected set {
            m_health = value;
        }
    }

    public BuildingType BuildingType{
        get{ return m_buildingType; }
        protected set {
            m_buildingType = value;
        }
    }

}