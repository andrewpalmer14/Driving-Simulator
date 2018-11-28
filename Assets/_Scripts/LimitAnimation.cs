using UnityEngine;
using UnityEngine.UI;

public class LimitAnimation : MonoBehaviour {

    public bool limit = false;

    public bool sl35 = false;
    public bool sl20 = false;
    public bool sl50 = false;

    public Animator anim;
    public Sprite curSprite;
    public Sprite[] limitSprites;

    private Image _limitImage;

    void Start () {
        anim = GetComponent<Animator>();
        _limitImage = GetComponent<Image>();
    }
	
	
	void Update () {

        //Sets the Sprite on the Object
        if (sl35 == true)
        {
            curSprite = limitSprites[0];
            _limitImage.sprite = curSprite;
        }

        if (sl20 == true)
        {
            curSprite = limitSprites[1];
            _limitImage.sprite = curSprite;
        }

        if (sl50 == true)
        {
            curSprite = limitSprites[2];
            _limitImage.sprite = curSprite;
        }

        //Controls the Animation
        if (limit == true)
        {
            anim.SetBool("limitGo", true);
        }
        else if (limit == false)
        {
            anim.SetBool("limitGo", false);
        }
    }
}
