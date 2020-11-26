using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptPlayer : MonoBehaviour
{
    public float velocidade;
    public float velRot;
    private Rigidbody rbd;
    private Quaternion rotOriginal;
    int rotTecladoX = 0;
    private int vida;
    private bool pause = false;


    // Start is called before the first frame update
    void Start()
    {
        velRot = 100;
        velocidade = 20;
        vida = 3;
      
        rbd = GetComponent<Rigidbody>();
        
        rotOriginal = transform.localRotation;

    }

    public void OnCollisionEnter (Collision col){
        if (col.gameObject.tag == "Fantasma"){
            vida -= 1;            
        }

        if (vida == 0){
            Destroy(this.gameObject);
            SceneManager.LoadScene(2);
        }

        if(col.gameObject.tag == "Vortex"){
            if(transform.position.x < 0){
                transform.position = new Vector3((transform.position.x + 1) * -1, transform.position.y, transform.position.z);
            } else {
                transform.position = new Vector3((transform.position.x - 1) * -1, transform.position.y, transform.position.z);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        //MOVIMENTO
        float moveFrente = Input.GetAxis("Vertical");
        float moveLado = Input.GetAxis("Horizontal");
        

        Vector3 vel = transform.TransformDirection(new Vector3(moveLado * velocidade, rbd.velocity.y, moveFrente * velocidade));
        
       
        //ROTAÇÃO TECLADO
        rbd.velocity = vel;
        int rot = 0;
        if(Input.GetKey(KeyCode.Q)){
            rot = -1;
        }else if(Input.GetKey(KeyCode.E)){
            rot = 1;
        }

        transform.Rotate(new Vector3(0, rot*Time.deltaTime * velRot,0));

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pause){
                pause = false;
                Time.timeScale = 1;    
                SceneManager.UnloadSceneAsync(0);
            }else{
                pause = true;
                Time.timeScale = 0;
                SceneManager.LoadSceneAsync(0,LoadSceneMode.Additive);
            }
            
        }

    }

   
}
