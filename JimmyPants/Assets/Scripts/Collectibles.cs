using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public static int totalCollected; //public static total collectibles acquired

    /*private int clo = 0;
    [SerializeField] private Sprite baby0, baby1, baby2;
    [SerializeField] private GameObject player;
    private enum babyState
    {
        STAGE0, STAGE1, STAGE2
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameStateManager.Restart();
            clo++;
            checkBabyState(clo);
        }//end if collectable
    }//end collusions

    private void checkBabyState(int clo)
    {
        babyState sprite = (babyState)clo;
        switch (sprite)
        {
            case babyState.STAGE0: player.GetComponent<SpriteRenderer>().sprite = baby0;  break;
            case babyState.STAGE1: player.GetComponent<SpriteRenderer>().sprite = baby1; break;
            case babyState.STAGE2: player.GetComponent<SpriteRenderer>().sprite = baby2; break;
        }//end switch sprite
    }//end checkBabyState*/

}
