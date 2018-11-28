using UnityEngine;
using UnityEngine.UI;

public class RallyAnimation : MonoBehaviour {
    
    public bool rally = false;

    public bool stop = false;
    public bool backward = false;
    public bool forward = false;
    public bool leftTurn = false;
    public bool rightTurn = false;
    public bool cautionRight = false;
    public bool cautionLeft = false;
    public bool speedlimit = false;

    public Animator anim;
    public Sprite curSprite;
    public Sprite[] rallySprites;

    public Image _rallyImage;
	
	void Start () {
        anim = GetComponent<Animator>();
        _rallyImage = GetComponent<Image>();
	}	
	
	void Update () {
       
        //Sets the Sprite on the Object
        if (backward == true)
        {
            curSprite = rallySprites[0];
            _rallyImage.sprite = curSprite;
        }

        if (forward == true)
        {
            curSprite = rallySprites[1];
            _rallyImage.sprite = curSprite;
        }

        if (leftTurn == true)
        {
            curSprite = rallySprites[2];
            _rallyImage.sprite = curSprite;
        }

        if (rightTurn == true)
        {
            curSprite = rallySprites[3];
            _rallyImage.sprite = curSprite;
        }

        if (cautionLeft == true)
        {
            curSprite = rallySprites[4];
            _rallyImage.sprite = curSprite;
        }

        if (cautionRight == true)
        {
            curSprite = rallySprites[5];
            _rallyImage.sprite = curSprite;
        }

        if (stop == true)
        {
            curSprite = rallySprites[6];
            _rallyImage.sprite = curSprite;
        }

        if (speedlimit == true)
        {
            curSprite = rallySprites[7];
            _rallyImage.sprite = curSprite;
        }

        //Controls the Animation
        if (rally == true) {
            anim.SetBool("rallyEnter", true);
        }
        else if(rally == false){
            anim.SetBool("rallyEnter", false);
        }
	}
}
