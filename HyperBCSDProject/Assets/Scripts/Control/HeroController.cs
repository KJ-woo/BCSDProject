using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private GameObject unitMarker;
    
    public Hero hero;
    public NavMeshAgent nav;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = gameObject.transform.parent.GetComponent<PlayerController>();
    }

    public void SelectHero()
    {
        unitMarker.SetActive(true);
    }
    public void DeSelectHero()
    {
        unitMarker.SetActive(false);
    }
    public void MoveTo(Vector3 end)
    {
        nav.SetDestination(end);
        hero.Run();
    }
    public void Stay()
    {
        hero.Set_Placement();
    }
}
