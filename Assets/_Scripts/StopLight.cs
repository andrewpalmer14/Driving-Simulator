using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour {

	public Material green;
	public Material yellow;
	public Material red;

    public LightAnimation lightQueue;
    public Sprite greenSprite;
    public Sprite yellowSprite;
    public Sprite redSprite;

	private Shader on;

	private Shader off;

	private float time;
	private float greenTime = 5f;
	private float yellowTime = 1.5f;
	private float redTime = 6.5f;

	private const string GREEN = "GREEN";

	private const string YELLOW = "YELLOW";

	private const string RED = "RED";

	private string currentLight;


	private enum stopLight {GREEN, RED, YELLOW};


	// Use this for initialization
	void Start () {
		on = Shader.Find("Legacy Shaders/Self-Illumin/Specular"); // on shader
		off = Shader.Find("Legacy Shaders/Specular");	// off shader
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		checkLight();
        if (lightQueue != null)
        {
            if (currentLight == "GREEN")
            {

                lightQueue._lightImage.sprite = greenSprite;
            }
            else if (currentLight == "YELLOW")
            {


                lightQueue._lightImage.sprite = yellowSprite;
            }
            else if (currentLight == "RED")
            {

                lightQueue._lightImage.sprite = redSprite;
            }
        }

    }

	void checkLight() {
		switch (currentLight) {
			case GREEN:
			if (time >= greenTime) {
				setYellow();
				time = 0;
			}
			break;
			case YELLOW:
			if (time >= yellowTime) {
				setRed();
				time = 0;
			}
			break;
			case RED:
			if (time >= redTime) {
				setGreen();
				time = 0;
			}
			break;
			default:
			setGreen();
			break;
		}
	}

	// set light to green
	void setGreen() {
		currentLight = GREEN;
		setShaders(on, off, off);
	}

	// set light to yellow
	void setYellow() {
		currentLight = YELLOW;
		setShaders(off, on, off);
	}

	// set light to red
	void setRed() {
		currentLight = RED;
		setShaders(off, off, on);
	}

	void setShaders(Shader greenShader, Shader yellowShader, Shader redShader) {
		green.shader = greenShader;
		yellow.shader = yellowShader;
		red.shader = redShader;
	}

    public string getCurrentLight()
    {
        return currentLight;
    }
}
