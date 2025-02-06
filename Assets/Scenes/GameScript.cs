using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public string songInput = "C2, C2, G2, G2, A2, A2, G2, " +
                              "F2, F2, E2, E2, D2, D2, C2, " +
                              "G2, G2, F2, F2, E2, E2, D2, " +
                              "G2, G2, F2, F2, E2, E2, D2, " +
                              "C2, C2, G2, G2, A2, A2, G2, " +
                              "F2, F2, E2, E2, D2, D2, C2";

    public GameObject keys1;
    public GameObject keys2; 
    public GameObject keys3;
    public GameObject tile;
    public GameObject tileSharp;

    public GameObject C1;
    public GameObject CS1;
    public GameObject D1;
    public GameObject DS1;
    public GameObject E1;
    public GameObject F1;
    public GameObject FS1;
    public GameObject G1;
    public GameObject GS1;
    public GameObject A1;
    public GameObject AS1;
    public GameObject B1;

    public GameObject C2;
    public GameObject CS2;
    public GameObject D2;
    public GameObject DS2;
    public GameObject E2;
    public GameObject F2;
    public GameObject FS2;
    public GameObject G2;
    public GameObject GS2;
    public GameObject A2;
    public GameObject AS2;
    public GameObject B2;

    public GameObject C3;
    public GameObject CS3;
    public GameObject D3;
    public GameObject DS3;
    public GameObject E3;
    public GameObject F3;
    public GameObject FS3;
    public GameObject G3;
    public GameObject GS3;
    public GameObject A3;
    public GameObject AS3;
    public GameObject B3;

    private AudioSource audioSource;
    
    public AudioClip soundC1;
    public AudioClip soundCS1;
    public AudioClip soundD1;
    public AudioClip soundDS1;
    public AudioClip soundE1;
    public AudioClip soundF1;
    public AudioClip soundFS1;
    public AudioClip soundG1;
    public AudioClip soundGS1;
    public AudioClip soundA1;
    public AudioClip soundAS1;
    public AudioClip soundB1;

    public AudioClip soundC2;
    public AudioClip soundCS2;
    public AudioClip soundD2;
    public AudioClip soundDS2;
    public AudioClip soundE2;
    public AudioClip soundF2;
    public AudioClip soundFS2;
    public AudioClip soundG2;
    public AudioClip soundGS2;
    public AudioClip soundA2;
    public AudioClip soundAS2;
    public AudioClip soundB2;

    public AudioClip soundC3;
    public AudioClip soundCS3;
    public AudioClip soundD3;
    public AudioClip soundDS3;
    public AudioClip soundE3;
    public AudioClip soundF3;
    public AudioClip soundFS3;
    public AudioClip soundG3;
    public AudioClip soundGS3;
    public AudioClip soundA3;
    public AudioClip soundAS3;
    public AudioClip soundB3;

    public AudioClip soundFail;

    [SerializeField] private int octave;
    [SerializeField] private bool isSharp;

    [SerializeField] private Dictionary<string, (GameObject, int)> keyMap;

    // other song inputs:
    // twinkle twinkle / ABCs
    // "C2, C2, G2, G2, A2, A2, G2, F2, F2, E2, E2, D2, D2, C2, G2, G2, F2, F2, E2, E2, D2, G2, G2, F2, F2, E2, E2, D2, C2, C2, G2, G2, A2, A2, G2, F2, F2, E2, E2, D2, D2, C2"

    // fur elise
    // "E3, D#3, E3, D#3, E3, B2, D3, C3, A2, C2, E2, A2, B2, E2, G#2, B2, C3, E2, E3, D#3, E3, D#3, E3, B2, D3, C3, A2, C2, E2, A2, B2, E2, C3, B2, A2, B2, C3, D3, E3, G2, F3, E3, D3, F2, E3, D3, C3, E2, D3, C3, B2, E2, E3, D#3, E3, D#3, E3, B2, D3, C3, A2, C2, E2, A2, B2, E2, G#2, B2, C3, E2, E3, D#3, E3, D#3, E3, B2, D3, C3, A2, C2, E2, A2, B2, E2, C3, B2, A2"

    // rush e
    // "E2, E2, E2, E2, E2, E2, E3, E3, E3, E3, E3, E3, E1, E1, E1, E1, E1, E1, E1, E1, E1, A1, C2, E1, C2, E1, G1, G#1, A1, C2, E1, C2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, F2, E2, D#2, E2, A2, C3, D3, D3, D3, D3, D3, C3, B2, D3, C3, C3, C3, C3, C3, B2, A2, C3, B2, B2, B2, B2, F#2, B2, G#2, E1, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, E2, F2, E2, D#2, E2, A2, C3, E3, A3, C1, D3, C3, B2, D3, C3, B2, A2, C3, B2, A2, G#2, B2, A2, E2, C2, A1, F2, E2, D2, C2, B1, A1, G#1, B1, A1, A1, D2, C#2, D2, E2, F2, E2, D2, F2, E2, D2, C2, D2, E2, C2, B1, A#1, B1, C2, D2, C2, B1, D2, C2, A1, C2, E2, A2, E2, C2, A1, D2, C#2, D2, E2, F2, E2, D2, F2, E2, D2, C2, D2, E2, A2, D2, F2, E2, C2, D2, B1, A1, E2, A2"

    public List<string> songArray = new List<string>();
    private List<GameObject> tileList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        octave = 1;
        isSharp = false;

        string[] splitArray = songInput.Split(new char[] { ',', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);  // Split by comma and space
        songArray = new List<string>(splitArray);

        // Initialize AudioSource
        audioSource = GetComponent<AudioSource>();

        // Assign the AudioClip if not done in the inspector
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // hashmap of key value where value is tuple of gameobject and octave
        keyMap = new Dictionary<string, (GameObject, int)>()
        {
            { "C1", (C1, 1) }, { "C#1", (CS1, 1) }, { "D1", (D1, 1) }, { "D#1", (DS1, 1) },
            { "E1", (E1, 1) }, { "F1", (F1, 1) }, { "F#1", (FS1, 1) }, { "G1", (G1, 1) },
            { "G#1", (GS1, 1) }, { "A1", (A1, 1) }, { "A#1", (AS1, 1) }, { "B1", (B1, 1) },
            { "C2", (C2, 2) }, { "C#2", (CS2, 2) }, { "D2", (D2, 2) }, { "D#2", (DS2, 2) },
            { "E2", (E2, 2) }, { "F2", (F2, 2) }, { "F#2", (FS2, 2) }, { "G2", (G2, 2) },
            { "G#2", (GS2, 2) }, { "A2", (A2, 2) }, { "A#2", (AS2, 2) }, { "B2", (B2, 2) },
            { "C3", (C3, 3) }, { "C#3", (CS3, 3) }, { "D3", (D3, 3) }, { "D#3", (DS3, 3) },
            { "E3", (E3, 3) }, { "F3", (F3, 3) }, { "F#3", (FS3, 3) }, { "G3", (G3, 3) },
            { "G#3", (GS3, 3) }, { "A3", (A3, 3) }, { "A#3", (AS3, 3) }, { "B3", (B3, 3) }
        };

        generateSong(songArray);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (octave == 0)
            {
                Debug.Log("Attempt to lower octave below 1");
            }
            else
            {
                lowerOctave(octave);
                octave -= 1;
            }

            if (tileList.Count <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (octave == 2)
            {
                Debug.Log("Attempt to raise octave above 3");
            }
            else
            {
                raiseOctave(octave);
                octave += 1;
            }

            if (tileList.Count <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sharpMode(!isSharp);
            isSharp = !isSharp;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            string currKey = songArray[0];
            // if it's not sharp and it's the right octave and the right note
            if (!isSharp && (octave + 1) == keyMap[currKey].Item2 && (currKey == "C1" || currKey == "C2" || currKey == "C3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            string currKey = songArray[0];
            // if it's sharp and it's the right octave and the right note
            if (/*isSharp && */(octave + 1) == keyMap[currKey].Item2 && (currKey == "C#1" || currKey == "C#2" || currKey == "C#3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either not sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            string currKey = songArray[0];
            // if it's not sharp and it's the right octave and the right note
            if (!isSharp && (octave + 1) == keyMap[currKey].Item2 && (currKey == "D1" || currKey == "D2" || currKey == "D3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            string currKey = songArray[0];
            // if it's sharp and it's the right octave and the right note
            if (/*isSharp && */(octave + 1) == keyMap[currKey].Item2 && (currKey == "D#1" || currKey == "D#2" || currKey == "D#3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either not sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            string currKey = songArray[0];
            // if it's not sharp and it's the right octave and the right note
            if (!isSharp && (octave + 1) == keyMap[currKey].Item2 && (currKey == "E1" || currKey == "E2" || currKey == "E3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            string currKey = songArray[0];
            // if it's not sharp and it's the right octave and the right note
            if (!isSharp && (octave + 1) == keyMap[currKey].Item2 && (currKey == "F1" || currKey == "F2" || currKey == "F3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            string currKey = songArray[0];
            // if it's sharp and it's the right octave and the right note
            if (/*isSharp && */(octave + 1) == keyMap[currKey].Item2 && (currKey == "F#1" || currKey == "F#2" || currKey == "F#3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either not sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            string currKey = songArray[0];
            // if it's not sharp and it's the right octave and the right note
            if (!isSharp && (octave + 1) == keyMap[currKey].Item2 && (currKey == "G1" || currKey == "G2" || currKey == "G3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            string currKey = songArray[0];
            // if it's sharp and it's the right octave and the right note
            if (/*isSharp && */(octave + 1) == keyMap[currKey].Item2 && (currKey == "G#1" || currKey == "G#2" || currKey == "G#3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either not sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            string currKey = songArray[0];
            // if it's not sharp and it's the right octave and the right note
            if (!isSharp && (octave + 1) == keyMap[currKey].Item2 && (currKey == "A1" || currKey == "A2" || currKey == "A3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            string currKey = songArray[0];
            // if it's sharp and it's the right octave and the right note
            if (/*isSharp && */(octave + 1) == keyMap[currKey].Item2 && (currKey == "A#1" || currKey == "A#2" || currKey == "A#3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either not sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            string currKey = songArray[0];
            // if it's not sharp and it's the right octave and the right note
            if (!isSharp && (octave + 1) == keyMap[currKey].Item2 && (currKey == "B1" || currKey == "B2" || currKey == "B3"))
            {
                playSound(currKey);
                for (int i = 0; i < tileList.Count; i++)
                {
                    // move each tile down by 1
                    tileList[i].transform.position += new Vector3(0, -1f, 0);
                }

                // destroy the gameobject and remove it from the list
                if (tileList.Count > 0)
                {
                    GameObject firstObject = tileList[0];
                    tileList.RemoveAt(0);  // remove from list first so we don't error
                    songArray.RemoveAt(0);// also remove from songArray since we use it to quickly reference currKey
                    Destroy(firstObject);  // destroy last
                }
            }
            else
            {
                Debug.Log("Either not sharp, wrong octave, or wrong note");
                audioSource.PlayOneShot(soundFail);
            }
        }
    }

    void generateSong(List<string> songArray)
    {
        // -2.5 is the starting bottom, and each tile has distance of 1
        for (int i = 0; i < songArray.Count; i++)
        {
            // get the x and y position to place the tile
            string currKey = songArray[i];
            float xPos = keyMap[songArray[i]].Item1.transform.position.x;
            float yPos = -2.5f + i;

            // sharp check
            if (currKey == "C#1" || currKey == "D#1" || currKey == "F#1" || currKey == "G#1" || currKey == "A#1" ||
                currKey == "C#2" || currKey == "D#2" || currKey == "F#2" || currKey == "G#2" || currKey == "A#2" ||
                currKey == "C#3" || currKey == "D#3" || currKey == "F#3" || currKey == "G#3" || currKey == "A#3")
            {
                GameObject newTile = Instantiate(tileSharp, new Vector2(xPos, yPos), Quaternion.identity);
                tileList.Add(newTile);
            }
            else
            {
                GameObject newTile = Instantiate(tile, new Vector2(xPos, yPos), Quaternion.identity);
                tileList.Add(newTile);
            }
        }
    }

    void lowerOctave(int octave)
    {
        hideKeys(octave);
        showKeys(octave - 1);
    }

    void raiseOctave(int octave)
    {
        hideKeys(octave);
        showKeys(octave + 1);
    }

    // play the sound
    void playSound(string key)
    {
        switch (key)
        {
            case "C1":
                audioSource.PlayOneShot(soundC1);
                break;
            case "C#1":
                audioSource.PlayOneShot(soundCS1);
                break;
            case "D1":
                audioSource.PlayOneShot(soundD1);
                break;
            case "D#1":
                audioSource.PlayOneShot(soundDS1);
                break;
            case "E1":
                audioSource.PlayOneShot(soundE1);
                break;
            case "F1":
                audioSource.PlayOneShot(soundF1);
                break;
            case "F#1":
                audioSource.PlayOneShot(soundFS1);
                break;
            case "G1":
                audioSource.PlayOneShot(soundG1);
                break;
            case "G#1":
                audioSource.PlayOneShot(soundGS1);
                break;
            case "A1":
                audioSource.PlayOneShot(soundA1);
                break;
            case "A#1":
                audioSource.PlayOneShot(soundAS1);
                break;
            case "B1":
                audioSource.PlayOneShot(soundB1);
                break;
            case "C2":
                audioSource.PlayOneShot(soundC2);
                break;
            case "C#2":
                audioSource.PlayOneShot(soundCS2);
                break;
            case "D2":
                audioSource.PlayOneShot(soundD2);
                break;
            case "D#2":
                audioSource.PlayOneShot(soundDS2);
                break;
            case "E2":
                audioSource.PlayOneShot(soundE2);
                break;
            case "F2":
                audioSource.PlayOneShot(soundF2);
                break;
            case "F#2":
                audioSource.PlayOneShot(soundFS2);
                break;
            case "G2":
                audioSource.PlayOneShot(soundG2);
                break;
            case "G#2":
                audioSource.PlayOneShot(soundGS2);
                break;
            case "A2":
                audioSource.PlayOneShot(soundA2);
                break;
            case "A#2":
                audioSource.PlayOneShot(soundAS2);
                break;
            case "B2":
                audioSource.PlayOneShot(soundB2);
                break;
            case "C3":
                audioSource.PlayOneShot(soundC3);
                break;
            case "C#3":
                audioSource.PlayOneShot(soundCS3);
                break;
            case "D3":
                audioSource.PlayOneShot(soundD3);
                break;
            case "D#3":
                audioSource.PlayOneShot(soundDS3);
                break;
            case "E3":
                audioSource.PlayOneShot(soundE3);
                break;
            case "F3":
                audioSource.PlayOneShot(soundF3);
                break;
            case "F#3":
                audioSource.PlayOneShot(soundFS3);
                break;
            case "G3":
                audioSource.PlayOneShot(soundG3);
                break;
            case "G#3":
                audioSource.PlayOneShot(soundGS3);
                break;
            case "A3":
                audioSource.PlayOneShot(soundA3);
                break;
            case "A#3":
                audioSource.PlayOneShot(soundAS3);
                break;
            case "B3":
                audioSource.PlayOneShot(soundB3);
                break;
        }      
    }

    // changes sharp keys color to signal activation
    void sharpMode(bool activate)
    {
        foreach (Transform child in keys1.transform)
        {
            GameObject currObject = child.gameObject;
            // sharp check
            if (currObject == CS1 || currObject == DS1 || currObject == FS1 || currObject == GS1 || currObject == AS1)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;

                    if (activate)
                    {
                        currentColor.r = 0.52f;
                        currentColor.g = 0.23f;
                        currentColor.b = 1f;
                    }
                    else if (!activate)
                    {
                        currentColor.r = 0.16f;
                        currentColor.g = 0.16f;
                        currentColor.b = 0.16f;
                    }

                    spriteRenderer.color = currentColor;
                }
            }  
        }

        foreach (Transform child in keys2.transform)
        {
            GameObject currObject = child.gameObject;
            // sharp check
            if (currObject == CS2 || currObject == DS2 || currObject == FS2 || currObject == GS2 || currObject == AS2)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;

                    if (activate)
                    {
                        currentColor.r = 0.52f;
                        currentColor.g = 0.23f;
                        currentColor.b = 1f;
                    }
                    else if (!activate)
                    {
                        currentColor.r = 0.16f;
                        currentColor.g = 0.16f;
                        currentColor.b = 0.16f;
                    }

                    spriteRenderer.color = currentColor;
                }
            }
        }

        foreach (Transform child in keys3.transform)
        {
            GameObject currObject = child.gameObject;
            // sharp check
            if (currObject == CS3 || currObject == DS3 || currObject == FS3 || currObject == GS3 || currObject == AS3)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;

                    if (activate)
                    {
                        currentColor.r = 0.52f;
                        currentColor.g = 0.23f;
                        currentColor.b = 1f;
                    }
                    else if (!activate)
                    {
                        currentColor.r = 0.16f;
                        currentColor.g = 0.16f;
                        currentColor.b = 0.16f;
                    }

                    spriteRenderer.color = currentColor;
                }
            }
        }
    }

    // reduce alpha of current key set
    void hideKeys(int octave)
    {
        if (octave == 0)
        {
            foreach (Transform child in keys1.transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;
                    currentColor.a = 0.12f;
                    spriteRenderer.color = currentColor;
                }
            }
        }

        if (octave == 1)
        {
            foreach (Transform child in keys2.transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;
                    currentColor.a = 0.12f;
                    spriteRenderer.color = currentColor;
                }
            }
        }

        if (octave == 2)
        {
            foreach (Transform child in keys3.transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;
                    currentColor.a = 0.12f;
                    spriteRenderer.color = currentColor;
                }
            }
        }
    }

    // increase alpha of current key set
    void showKeys(int octave)
    {
        if (octave == 0)
        {
            foreach (Transform child in keys1.transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;
                    currentColor.a = 1f;
                    spriteRenderer.color = currentColor;
                }
            }
        }

        if (octave == 1)
        {
            foreach (Transform child in keys2.transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;
                    currentColor.a = 1f;
                    spriteRenderer.color = currentColor;
                }
            }
        }

        if (octave == 2)
        {
            foreach (Transform child in keys3.transform)
            {
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();

                if (spriteRenderer != null)
                {
                    Color currentColor = spriteRenderer.color;
                    currentColor.a = 1f;
                    spriteRenderer.color = currentColor;
                }
            }
        }
    }
}
