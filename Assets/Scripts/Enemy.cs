using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform objectivo;
    public Collider[] objetos_detectados;
    public LayerMask mascaraDeBusqueda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        objetos_detectados = Physics.OverlapSphere(transform.position, 10f,mascaraDeBusqueda);

        //foreach (Collider item in objetos_detectados)
        //{
        //    if (item.tag == "Player")
        //    {
        //        GetComponent<NavMeshAgent>().SetDestination(objectivo.position);
        //    }
        //}

        if (objetos_detectados.Length > 0)
        {
            GetComponent<NavMeshAgent>().SetDestination(objectivo.position);
        }
        else
        {
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
