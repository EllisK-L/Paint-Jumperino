using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    string line = "";
    public bool LComplete = false;
    public bool isDead = false;
    float deathTimer = 0.0f;
    float sec = 0.0f;
	bool PSEmit = false; 

    void Start()
    {
       
    }

    void Update()
    {
        
        if (isDead == true)
        {
            GameObject.Find("PlayerModel").GetComponent<MeshRenderer>().enabled = false;
			if (PSEmit == true) {
				GameObject.Find ("PS").GetComponent<ParticleSystem> ().Emit (20000);
				PSEmit = false;
			}
            if (sec < 2)
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                Debug.Log("COUNTING");
                deathTimer += Time.deltaTime;
                sec = deathTimer % 60;
            }
            else
            {
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                OnDeath();
                sec = 0.0f;
                deathTimer = 0.0f;
                GameObject.Find("PlayerModel").GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {

            LComplete = true;
            StreamReader SR = new StreamReader(Application.persistentDataPath + "LevelSaves.txt");
            StreamWriter SW = new StreamWriter(Application.persistentDataPath + "LevelSavesTemp.txt");
            Debug.Log("Here");
            while (line != null)
            {
                line = SR.ReadLine();
                if (line != null)
                {
                    Debug.Log(SceneManager.GetActiveScene().name + "incomplete");
                    Debug.Log(line);
                    if (line == SceneManager.GetActiveScene().name + "incomplete")

                    {
                        line = SceneManager.GetActiveScene().name + "complete";
                        SW.WriteLine(line);
                    }
                    else

                    {
                        SW.WriteLine(line);
                    }

                }

      

            }

            SW.Flush();
            SW.Close();
            SR.Close();
            //
            line = "";
            StreamWriter SWnew = new StreamWriter(Application.persistentDataPath + "LevelSaves.txt");
            StreamReader SRnew = new StreamReader(Application.persistentDataPath + "LevelSavesTemp.txt");
            while (line != null)
            {
                line = SRnew.ReadLine();
                if (line != null)
                {
                    SWnew.WriteLine(line);
                }
            }
            SWnew.Flush();
            SWnew.Close();

        }



        if (other.tag == "Floor")
        {
            BeforeDeath();
        }
    }
    public void BeforeDeath()
    {
		PSEmit = true;
        Debug.Log(sec);
        isDead = true;
        //Update();
    }
    public void OnDeath()
    {
        isDead = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(-29.92f, 3.61f, 0);
        GameObject.Find("Camera").transform.position = new Vector3(GameObject.Find("Player").transform.position.x + 10, 8, -10);
        Debug.Log("Dead");
        
    }
}
