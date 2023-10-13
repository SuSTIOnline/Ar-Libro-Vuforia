using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManipulacionDeObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject objetoPrefab;
    [SerializeField] Camera aRCamaraRef;
    [SerializeField] bool seSeleccionoObjeto;
    Vector2 posicionToqueInicial;

    [SerializeField] float velocidadDeMovimiento = 4.0f;
    [SerializeField] float velocidadDeRotacion = 5.0f;
    [SerializeField] float factorDeEscala = 0.1f;

    float escalaDePantalla = 0.0001f;

    Touch primerToque;
    Touch segundoToque;
    float distanciaEntreToques;
    Vector2 difPosicionEntreToques;

    float toleranciaDeRotacion = 1.5f;
    float toleranciaDeEscala = 25f;
    private bool ChequearToqueSobreObjeto(Vector2 posicionToque) 
    {
        Ray rayo = aRCamaraRef.ScreenPointToRay(posicionToque);

        if(Physics.Raycast(rayo, out RaycastHit golpeAObjeto))
        {
            if (golpeAObjeto.collider.tag == "Interactuable")
            {
                objetoPrefab = golpeAObjeto.transform.gameObject;
                return true;
            }
        }
        return false;
    }

    private void EscalaDeObjeto()
    {
        if(Input.touchCount == 2)
        {
            segundoToque = Input.GetTouch(1);
            if(primerToque.phase == TouchPhase.Began || segundoToque.phase == TouchPhase.Began)
            {
                difPosicionEntreToques = segundoToque.position - primerToque.position;
                distanciaEntreToques = Vector2.Distance(segundoToque.position, primerToque.position);
            }

            if(primerToque.phase == TouchPhase.Moved || segundoToque.phase == TouchPhase.Moved)
            {
                Vector2 nuevaDiferenciaDePosicion = segundoToque.position - primerToque.position;
                float nuevaDistanciaDeToque = Vector2.Distance(segundoToque.position, primerToque.position);

                float diferenciaEntreDistancias = nuevaDistanciaDeToque - distanciaEntreToques;

                //if(Mathf.Abs(diferenciaEntreDistancias) > toleranciaDeEscala
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            primerToque = Input.GetTouch(0);

            if(Input.touchCount == 1)
            {
                if(primerToque.phase == TouchPhase.Began)
                {
                    posicionToqueInicial = primerToque.position;
                    seSeleccionoObjeto = ChequearToqueSobreObjeto(posicionToqueInicial);
                }
            }
            if(primerToque.phase == TouchPhase.Moved && seSeleccionoObjeto)
            {
                Vector2 Desplazamiento = (primerToque.position - posicionToqueInicial) * escalaDePantalla;
                objetoPrefab.transform.position += new Vector3(Desplazamiento.x * velocidadDeMovimiento, Desplazamiento.y * velocidadDeMovimiento, 0f);

                posicionToqueInicial = primerToque.position;
            }
        }
    }
}
