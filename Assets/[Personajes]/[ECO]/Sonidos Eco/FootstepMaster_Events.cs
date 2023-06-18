//Marshall Heffernan aka itsmars 2015
//Special thanks to Duck, TheKusabi, alucardj, dorpeleg, TonyLi & superpig on the Unity Forums!

//This is the ANIMATION EVENT version of my Footstep script. For this to work, you'll first need to...

//1) Add an ANIMATION EVENT to your movement animations, called "FootstepLeft" and "FootstepRight" when your feet touch the ground.
//2) Tag your Terrain GameObject with "Terrain".
//3) Tag your Non-Terrain GameObject floors with their respective names (for example, a wooden floor would need the tag "Surface_Wood").

//Watch the video tutorial! https://www.youtube.com/watch?v=ISoBKFxQLic

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
//This will add an Audio Source component if you don't have one.

public class FootstepMaster_Events : MonoBehaviour
{

	private GameObject terrainFinder; //Stores the Terrain GameObject out of the Scene for use later.
	private Terrain terrain; //Your Terrain (if one's in your scene)
	private TerrainData terrainData; //Lets us get to the Terrain's splatmap.
	private Vector3 terrainPos; //Where are we on the Splatmap?
	public static int surfaceIndex = 0; //The order in which your textures were added to your Terrain.
	private string whatTexture; //Holds the FILENAMEs of the Textures in your Terrain.

	private AudioSource mySound; //The AudioSource component
	public static GameObject floor; //what are we standing on?
	private string currentFoot; //Each foot does it's own Raycast

	//-----------------------------------------------------------------------------------------

	[Space(5.0f)] private float currentVolume;
	[Range(0.0f, 1.0f)] public float volume = 1.0f; //Volume slider bar; set this between 0 and 1 in the Inspector.

	[Range(0.0f, 0.2f)]
	public float
		volumeVariance =
			0.04f; //Variance in volume levels per footstep; set this between 0.0 and 0.2 in the inspector. Default is 0.04f.

	private float pitch;

	[Range(0.0f, 0.2f)]
	public float
		pitchVariance =
			0.08f; //Variance in pitch levels per footstep; set this between 0.0 and 0.2 in the inspector. Default is 0.08f.

	[Space(5.0f)]
	public GameObject leftFoot; //Drag your player's RIG/MESH/BIP/BONE for the left foot here, in the inspector.

	public GameObject rightFoot; //Drag your player's RIG/MESH/BIP/BONE for the right foot here, in the inspector.
	[Space(5.0f)] public AudioClip[] defaults = new AudioClip[0];
	public AudioClip[] dirt = new AudioClip[0];
	public AudioClip[] grass = new AudioClip[0];
	public AudioClip[] gravel = new AudioClip[0];
	public AudioClip[] leaves = new AudioClip[0];
	public AudioClip[] metal = new AudioClip[0];
	public AudioClip[] snow = new AudioClip[0];
	public AudioClip[] stone = new AudioClip[0];
	public AudioClip[] water = new AudioClip[0];
	public AudioClip[] wood = new AudioClip[0];

	[Space(5.0f)] [Tooltip("Choose ONE")]
	public bool instantiatedFX; //Check this checkbox in the inspector if you want your FX to be instantiated.

	[Tooltip("Choose ONE")]
	public bool toggledFX; //Check this checkbox in the inspector if you want your FX to be enabled.

	[Space(5.0f)] public GameObject dirtFX;
	public GameObject snowFX;
	public GameObject waterFX;
	private Quaternion dirtRotation;
	private Quaternion snowRotation;
	private Quaternion waterRotation;
	private Vector3 dirtPos;
	private Vector3 snowPos;
	private Vector3 waterPos;

	//-----------------------------------------------------------------------------------------

	//Start
	void Start()
	{
		mySound = gameObject.GetComponent<AudioSource>();
		terrainFinder = GameObject.FindGameObjectWithTag("Terrain");

		if (terrainFinder != null)
		{
			//IS THERE A TERRAIN IN THE SCENE?
			terrain = Terrain.activeTerrain;
			terrainData = terrain.terrainData;
			terrainPos = terrain.transform.position;
		}
	}

	//-----------------------------------------------------------------------------------------

	//Update
	void Update()
	{
		if (terrainFinder != null)
		{
			//IS THERE A TERRAIN IN THE SCENE?
			surfaceIndex = GetMainTexture(transform.position);
			//Not that it matters, but here we determine what position the Terrain Textures are in.
			//For example, If you added a grass texture, then a dirt, then a rock, you'd have grass=0, dirt=1, rock=2.
			whatTexture = terrainData.splatPrototypes[surfaceIndex].texture.name;
			//Instead of messing around with numbers, we'll just check the texture's filename.
		}

		if (dirtFX != null)
		{
			dirtFX.transform.rotation =
				dirtRotation; //lock the dirt FX particle system's rotation so it doesn't spin (only applies to TOGGLE mode).
			dirtFX.transform.position =
				dirtPos; //lock the dirt FX particle system's position so it doesn't follow you as you move (only applies to TOGGLE mode).
		}

		if (snowFX != null)
		{
			snowFX.transform.rotation = snowRotation;
			snowFX.transform.position = snowPos;
		}

		if (waterFX != null)
		{
			waterFX.transform.rotation = waterRotation;
			waterFX.transform.position = waterPos;
		}
	} //END OF UPDATE

	//-----------------------------------------------------------------------------------------

	//Puts ALL TEXTURES from the Terrain into an array, represented by floats (0=first texture, 1=second texture, etc).
	private float[] GetTextureMix(Vector3 WorldPos)
	{
		if (terrainFinder != null)
		{
			//IS THERE A TERRAIN IN THE SCENE?
			// calculate which splat map cell the worldPos falls within
			int mapX = (int)(((WorldPos.x - terrainPos.x) / terrainData.size.x) * terrainData.alphamapWidth);
			int mapZ = (int)(((WorldPos.z - terrainPos.z) / terrainData.size.z) * terrainData.alphamapHeight);
			// get the splat data for this cell as a 1x1xN 3d array (where N = number of textures)
			float[,,] splatmapData = terrainData.GetAlphamaps(mapX, mapZ, 1, 1);
			float[] cellMix = new float[splatmapData.GetUpperBound(2) + 1]; //turn splatmap data into float array
			for (int n = 0; n < cellMix.Length; n++)
			{
				cellMix[n] = splatmapData[0, 0, n];
			}

			return cellMix;
		}
		else return null; //THERE'S NO TERRAIN IN THE SCENE! DON'T DO THE ABOVE STUFF.
	}

	//Takes the "GetTextureMix" float array from above and returns the MOST DOMINANT texture at Player's position.
	private int GetMainTexture(Vector3 WorldPos)
	{
		if (terrainFinder != null)
		{
			//IS THERE A TERRAIN IN THE SCENE?
			float[] mix = GetTextureMix(WorldPos);
			float maxMix = 0;
			int maxIndex = 0;
			for (int n = 0; n < mix.Length; n++)
			{
				if (mix[n] > maxMix)
				{
					maxIndex = n;
					maxMix = mix[n];
				}
			}

			return maxIndex;
		}
		else return 0; //THERE'S NO TERRAIN IN THE SCENE! DON'T DO THE ABOVE STUFF.
	}

	//-----------------------------------------------------------------------------------------

	//You'll be calling this Method/Function ("FootstepLeft") from an Animation Event when your Left foot touches the ground.
	void FootstepLeft()
	{
		RaycastHit surfaceHitLeft;
		Ray aboveLeftFoot = new Ray(leftFoot.transform.position + new Vector3(0, 1.5f, 0), Vector3.down);
		LayerMask
			layerMask = ~(1 << 18) |
			            (1 << 19); //Here we ignore layer 18 and 19 (Player and NPCs). We want the raycast to hit the ground, not people.
		if (Physics.Raycast(aboveLeftFoot, out surfaceHitLeft, 2f, layerMask))
		{
			floor = (surfaceHitLeft.transform.gameObject);
//			Debug.DrawRay (aboveLeftFoot.origin, Vector3.down * 1.5f, Color.green, 2, false);
		}

		currentFoot = "Left"; //This will help us place the Instantiated or Toggled FX at the correct position.
		if (floor != null)
		{
			Invoke("CheckTexture", 0);
		}
	}

	//You'll be calling this Method/Function ("FootstepRight") from an Animation Event when your Right foot touches the ground.
	void FootstepRight()
	{
		RaycastHit surfaceHitRight;
		Ray aboveRightFoot = new Ray(rightFoot.transform.position + new Vector3(0, 1.5f, 0), Vector3.down);
		LayerMask
			layerMask = ~(1 << 18) |
			            (1 << 19); //Here we ignore layer 18 and 19 (Player and NPCs). We want the raycast to hit the ground, not people.
		if (Physics.Raycast(aboveRightFoot, out surfaceHitRight, 2f, layerMask))
		{
			floor = (surfaceHitRight.transform.gameObject);
//			Debug.DrawRay (aboveRightFoot.origin, Vector3.down * 1.5f, Color.green, 2, false);
		}

		currentFoot = "Right"; //This will help us place the Instantiated or Toggled FX at the correct position.
		if (floor != null)
		{
			Invoke("CheckTexture", 0);
		}
	}

	//-----------------------------------------------------------------------------------------

	void CheckTexture()
	{
		if (floor.tag == ("Surface_Grass"))
			Invoke("PlayGrass", 0);
		if (floor.tag == ("Surface_Stone"))
			Invoke("PlayStone", 0);

	}


	void PlayGrass()
	{
		currentVolume = (volume + UnityEngine.Random.Range(-volumeVariance, volumeVariance));
		pitch = (1.0f + Random.Range(-pitchVariance, pitchVariance));
		mySound.pitch = pitch;
		if (grass.Length > 0)
		{
			mySound.PlayOneShot(grass[Random.Range(0, grass.Length)], currentVolume);
		}
		else Debug.LogError("trying to play grass sound, but no grass sounds in array!");
	}



	void PlayStone()
	{
		currentVolume = (volume + UnityEngine.Random.Range(-volumeVariance, volumeVariance));
		pitch = (1.0f + Random.Range(-pitchVariance, pitchVariance));
		mySound.pitch = pitch;
		if (stone.Length > 0)
		{
			mySound.PlayOneShot(stone[Random.Range(0, stone.Length)], currentVolume);
		}
		else Debug.LogError("trying to play stone sound, but no stone sounds in array!");
	}
}
	
	