using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFantasminha : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agente;
    public GameObject alvo;
    public GameObject[] waypoints = new GameObject[4];

    void Start()
    {
        agente = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        if (alvo == null){
            alvo = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void OnCollisionEnter (Collision col){
        if (col.gameObject.tag == "Player"){
            transform.position = new Vector3(0, 2, 0);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        agente.destination = alvo.transform.position;
    }

    
}
