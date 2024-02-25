using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float vitesseX;
    public float vitesseY;
    public GameObject laPiece;
    public GameObject PackVie;
    public GameObject Champignon;
    public Sprite flappyBlesse;
    public Sprite flappyNormal;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            vitesseX = 0.02f;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            vitesseX = -0.02f;
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            vitesseY = 5;
        }
        else{
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);
    }
    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        if (infoCollision.gameObject.name == "ColonneHaut" || infoCollision.gameObject.name == "ColonneBas")
        {
            GetComponent<SpriteRenderer>().sprite = flappyBlesse;
        }
        else if(infoCollision.gameObject.name == "PieceOr")
        {
            infoCollision.gameObject.SetActive(false);

            Invoke("ReactiverPiece", 3f);
        }
        else if (infoCollision.gameObject.name == "PackVie")
        {
            GetComponent<SpriteRenderer>().sprite = flappyNormal;

            infoCollision.gameObject.SetActive(false);

            Invoke("ReactiverPackVie", 3f);
        }
        else if(infoCollision.gameObject.name == "Champignon")
        {
            infoCollision.gameObject.SetActive(false);

            gameObject.transform.localScale *= 2f;

            Invoke("ReactiverChampignon", 7f);
        }
    }
    void ReactiverPiece()
    {
        laPiece.SetActive(true);
        laPiece.transform.position = new Vector2(laPiece.transform.position.x,Random.Range(-5, 5));
    }

    void ReactiverPackVie()
    {
        PackVie.SetActive(true);
    }
    void ReactiverChampignon()
    {
        gameObject.transform.localScale /= 2f;
        Champignon.SetActive(true);
    }
}
