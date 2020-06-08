using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementManager : MonoBehaviour
{
    // Start is called before the first frame update

    private PlacebleBuilding m_buildingToPlace = null;
    public PlacebleBuilding BuildingToPlace {
        get { return m_buildingToPlace; }
        private set {
            if(m_buildingToPlace != null) Destroy(m_buildingToPlace.gameObject);
            m_buildingToPlace = value;
        }
    }

    private GameObject m_instance;
    [SerializeField]private ShootScript m_targetPoint;

    public PlacebleBuilding m_exampleBuilding;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) BuildingToPlace = Instantiate(m_exampleBuilding);
        HoverBuilding();
    }

    void HoverBuilding(){
        if(BuildingToPlace != null){
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit)){
                var buildingBlock = hit.transform.gameObject.GetComponent<IBuildable>();
                if(buildingBlock != null){
                    BuildingToPlace.transform.position = buildingBlock.BuildingPoint;
                    BuildingToPlace.SetPlacementMaterial(buildingBlock.IsBuildable(BuildingToPlace.BuildingType));
                }
            }
        }
    }
}
