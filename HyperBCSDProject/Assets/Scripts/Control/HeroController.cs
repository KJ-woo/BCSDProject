using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroController : MonoBehaviour
{
    [SerializeField]
    private GameObject unitMarker;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        navMeshAgent.SetDestination(end);
    }
}
