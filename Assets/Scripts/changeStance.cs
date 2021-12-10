using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeStance : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite transition;
    public Sprite fight;
    public Sprite neutral;
    private int state = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && state == 0)
        {
            //Enter code to change stance
            ChangeSprite(transition);
            StartCoroutine(change(3, fight));
            state++;
        } else if(Input.GetKeyDown(KeyCode.Space) && state == 1){
            ChangeSprite(transition);
            StartCoroutine(change(3, neutral));
            state--;
        }
    }
    void ChangeSprite(Sprite x)
    {
        spriteRenderer.sprite = x;
    }

    IEnumerator change(int secs, Sprite sprite)
    {
        yield return new WaitForSeconds(secs);
        ChangeSprite(sprite);
    }
}