using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackManager : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject[] stickers;
    static int amountOfStickers = int.MaxValue;
    void Start()
    {

    }

    void Update()
    {
        OpenPack();

        if (amountOfStickers <= 0)
        {
            //Cambiamos la escena a la del album.
        }
    }

    void RandomQuantityOfStickers() //se utiliza en la animacion "OpenPack"
    {
        int Quantity = 0;
        Quantity = Random.Range(1, 10);
        GameObject RandomSticker;

        if (Quantity >= 1 && Quantity <= 5)
        {
            RandomSticker = stickers[Random.Range(1, stickers.Length)];
            Instantiate(RandomSticker, spawns[1].transform.position, Quaternion.identity, spawns[1].transform); //2ra Posicion 
            amountOfStickers = 1;
        }
        else if (Quantity >=6 && Quantity <= 9)
        {
            RandomSticker = stickers[Random.Range(1, stickers.Length)];
            Instantiate(RandomSticker, spawns[0].transform.position, Quaternion.identity, spawns[0].transform); //1ra Posicion 
            RandomSticker = stickers[Random.Range(1, stickers.Length)];
            Instantiate(RandomSticker, spawns[1].transform.position, Quaternion.identity, spawns[1].transform); //2ra Posicion 
            amountOfStickers = 2;
        }
        else
        {
            RandomSticker = stickers[Random.Range(1, stickers.Length)];
            Instantiate(RandomSticker, spawns[0].transform.position, Quaternion.identity, spawns[0].transform); //1da Posicion 
            RandomSticker = stickers[Random.Range(1, stickers.Length)];
            Instantiate(RandomSticker, spawns[1].transform.position, Quaternion.identity, spawns[1].transform); //2ra Posicion 
            RandomSticker = stickers[Random.Range(1, stickers.Length)];
            Instantiate(RandomSticker, spawns[2].transform.position, Quaternion.identity, spawns[2].transform); //3ra Posicion 
            amountOfStickers = 3;
        }
    }

    private void OpenPack()
    {
        bool isPressOpenButton = Input.GetKey(KeyCode.Space);
        if (isPressOpenButton)
        {
            GetComponent<Animator>().Play("OpenPack");
        }
    }
}
