using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour {

    public bool reverse = false;
    public Sprite curSprite;
    public Sprite[] driveSprites;

    private Image _driveImage;

    void Start () {
        _driveImage = GetComponent<Image>();
    }
	
	
	void Update () {

        if (!reverse) {
            curSprite = driveSprites[0];
            _driveImage.sprite = curSprite;
        }
        else if (reverse)
        {
            curSprite = driveSprites[1];
            _driveImage.sprite = curSprite;
        }
	}
}
