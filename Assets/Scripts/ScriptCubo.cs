using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCubo : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter (Collision col){
        if (col.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            ScriptScore.score += 1;            
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
        
    }

   
}
