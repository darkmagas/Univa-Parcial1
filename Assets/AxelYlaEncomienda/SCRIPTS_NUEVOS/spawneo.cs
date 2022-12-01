using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawneo : MonoBehaviour
{
    Transform t;
    bool onDie;
    public float Lifes = 5f;
    public Transform spawnPoint;

    private Animator animator;
    private void OnCollisionEnter(Collision collision)
    {
        //Cuando entra en collision con el objecto de caida, se activa el metodo de killplayer
        if (collision.gameObject.tag == "Enemy")
        {
            KillPlayer();

        }
    }
    private void KillPlayer()
    { //cuando se activa el bool de morir es positivo y se informa el parametro, si tienes mas de 0 vidas se activa el respawn y si no gameover

        if (onDie) return;

        onDie = true;
        animator.SetBool("muerte", onDie);
        if (Lifes > 0f)
        {
            StartCoroutine(SpawnBall());
            Lifes -= 1;

        }
        if (Lifes == 0)
        {
            // if (GameOver != null)
            // GameOver();
        }


        IEnumerator SpawnBall()
        {//si se activa se toma unos segundos para el respawn, luego el personaje regresa al spawn point y se le resta una vida, Y el on die se vuelve falso 
            yield return new WaitForSeconds(2f);
            transform.position = spawnPoint.transform.position;

            onDie = false;
            animator.SetBool("OnDie", onDie);
            //speed = 0f;
        }
        // Use this for initialization

        // Start is called before the first frame update
        void Start()
        {


            // Update is called once per frame
            void Update()
            {

            }
        }
    }
}
