using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//tobe put on each facial feature game object
public class SetFace : MonoBehaviour
{

    public Sprite[] spriteList; //set sprites 

    private Sprite[] randSprites;
    //GameObject SpriteRenderer
    private SpriteRenderer spriteRenderer;

    private int spriteIndex;

    // Start is called before the first frame update
    void Start()
    {
        spriteIndex = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        randSprites = new Sprite[spriteList.Length];
        randSprites = RandomiseSpriteOrder(spriteList);

        SetRandomSprite();

    }

    public void SetRandomSprite()
    {
        System.Random rand = new System.Random();
        int randElement;

        randElement = rand.Next(0, randSprites.Length);
        Debug.Log(randElement);
        spriteRenderer.sprite = randSprites[randElement];

        spriteIndex = randElement;
    }

    public void ChangeFaceSprite(bool isIncrease)
    {
        //if increase
        if(isIncrease)
        {
            if(spriteIndex == randSprites.Length - 1)
            {
                spriteIndex = 0;
            }
            else
            {
                spriteIndex += 1;
            }
            
        }
        else
        {
            if (spriteIndex == 0)
            {
                spriteIndex = randSprites.Length - 1;
            }
            else
            {
                spriteIndex -= 1;
            }
        }

        spriteRenderer.sprite = randSprites[spriteIndex];
    }

    public Sprite[] RandomiseSpriteOrder(Sprite[] sprites)
    {
        Sprite[] randSpriteList;
        randSpriteList = new Sprite[sprites.Length];
        System.Random rand = new System.Random();
        int randElement;

        for (int i = 0; i < sprites.Length; i++)
        {
            randElement = rand.Next(0, sprites.Length);

            while (sprites[randElement] == null) // check element is not null
            {
                randElement = rand.Next(0, sprites.Length);
            }
            randSpriteList[i] = sprites[randElement];
            sprites[randElement] = null; //set to null to prevent duplicates         
        }

        return randSpriteList;
    }
}
