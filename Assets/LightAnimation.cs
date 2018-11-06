using UnityEngine;
using UnityEngine.UI;

public class LightAnimation : MonoBehaviour {

    public bool trafficLight = false;

    public bool green = false;
    public bool red = false;
    public bool yellow = false;   

    public Animator anim;
    public Sprite curSprite;
    public Sprite[] lightSprites;

    private Image _lightImage;
    
    void Start () {
        anim = GetComponent<Animator>();
        _lightImage = GetComponent<Image>();
    }
		
	void Update () {

        //Sets the Sprite on the Object
        if (green == true)
        {
            curSprite = lightSprites[0];
            _lightImage.sprite = curSprite;
        }

        if (red == true)
        {
            curSprite = lightSprites[1];
            _lightImage.sprite = curSprite;
        }

        if (yellow == true)
        {
            curSprite = lightSprites[2];
            _lightImage.sprite = curSprite;
        }

        //Controls the Animation
        if (trafficLight == true)
        {
            anim.SetBool("lightGo", true);
        }
        else if (trafficLight == false)
        {
            anim.SetBool("lightGo", false);
        }

    }
}
