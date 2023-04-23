using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GAME : MonoBehaviour
{
    // UPARXOUN SKRIPT STA SE EIDOS CUBE AKOMA KAI SE LITLECUBE(DIAFORETIKO SCRIPT SE AUTA EXEI THN DIADIKASIA GIA NA EKSAFANIZONTAI META APO LIGO
    //ARA UPARXEI KAI EKEI KODIKAS , EPISEIS UPARXEI SCRIPT KAI STHN CAMERA THN SECOND OPOU ULOPOIEI
    //TA MOVE THS CAMERAS ARA KAI EKEI UPARXEI KODIKAS AKOMA UPARXEI KAI O DJ(dj1,dj2,dj3,dj4) POU EXEI KAI EKEINOS ENA SCRIPT GIA NA PAIZEI XORIS PROBLIMA SE OLO TO GAME HXOS 
    //TI PREPEI NA KANW META TIS GIORTES :
    //DEN EXEI OILOPOIHTHEI TO TELEPORT TOU MAUROU KIBOU
    
    public AudioSource MusicSourse;//gia tous eixous


    public Image BAR;//gia to health bar

    //public AudioClip mlg;//hxoi
    public AudioClip cubefalling;//hxoi
    public AudioClip axe;//hxoi
    public AudioClip jumb;//hxoi
    public AudioClip takeweapon;//hxoi
    //public AudioClip musicgame1;
    public AudioClip breakbigcube;//hxoi
    public AudioClip teleportsound;//hxoi

    public Material fulllife;
    public Material life80;
    public Material life60;
    public Material life40;
    public Material life20;
    public int maxHPweapon=100;//100
    private int luckforaxes=3;//0-3 to random einai sthn ousia 33% ean tha mou bgalei to 1 wste na spoanarw theorw to 1 ws condition gia na sponarw axes
    private float timereadvictorymessage=10 ; //10
    public int weapondamage =1;//1
    public int weaponHealth ;//100
    public float attackCoolDown =1;//1

    //buttons
    public KeyCode winbutton;//BUTTON E

    public KeyCode hitbutton;//BUTTON H
    public KeyCode collectbutton;//BUTTON F
    public KeyCode exitbutton;//BUTTON X
    public KeyCode spacebarr;//BUTTON SPACE JUMB GIA TON HXO MONO
    public KeyCode CHANGECAMERA;//BUTTON U ALLAGH KAMERAS

    public KeyCode CHANGECAMERA1;//BUTTON K EPANAFORA STON XORO


    public Camera cameraekswteriki;//H DEUTERI KAMERA
    public GameObject dj2;//mousiki gia ton kibo na spasei giati eixame themata allios
    public GameObject dj4;//mousiki gia to last message giati eixe bugs otan perpatouses 
    public GameObject victorymessage;//MINIMA STO WIN 
    public GameObject litlecubes;//GIA NA KANEI SPOWN MIKRA CUBES
    public GameObject litleaxes;//GIA NA KANEI SPOWN MIKRA AXE
    public GameObject Rcube;// GIA NA KANEI SPOWN KOKINO KIBO
    public GameObject Gcube;// GIA NA KANEI SPOWN PRASINO KIBO
    public GameObject Bcube;// GIA NA KANEI SPOWN MPLE KIBO
    public GameObject Wcube;// GIA NA KANEI SPOWN MAURO KIBO
    public GameObject T1cube;// GIA NA KANEI SPOWN T1 TEXTURE KIBO
    public GameObject T2cube;// GIA NA KANEI SPOWN T2 TEXTURE KIBO
    public GameObject T3cube;// GIA NA KANEI SPOWN T3 TEXTURE KIBO
    public GameObject Ztransparent;//XRISIMOPOIEITE GIA NA  NA MHN PEFTEI O PAIXTHS AKTW
    public GameObject Xtransparent;//XRISIMOPOIEITE GIA NA  NA MHN PEFTEI O PAIXTHS AKTW
    public GameObject plane;//PATOMA
    public GameObject light;//FOS STO KENTRO
    public GameObject fpscamera;//FPS CAMERA
    public GameObject fpscamera1;//FPS CAMERA gia to teleport
    public string hitTransformBefore;
    private string readPath;//topotthetisi tou path
    private string[,] maze;//piankas maze opou krataw ta r g t1 ktlp
    private string[,] maze3;//piankas maze opou krataw ta r g t1 ktlp
    private string[,] maze1;
    public int L, N, K;//L=EPIPEDA,N=MEGETHOS LABIRINTHOU PX 16x16 K=sfuria
    private string path; //to path pou pernw meta to enter sto iput field
    private int epipeda = 0;// metabliti gia to level
    private int topothetisikameras = 0;// metabliti gia tin topothetisi kameras tin proti fora 
    private int x1 = 0;//GIA TIN TOPOTHETISI TON KIBWN
    private int z1 = 0;//GIA TIN TOPOTHETISI TON KIBWN
    private int metritisE = 0;//gia tin tixea thesi POSA KENA EXW
    private int metritisE1;//gia tin tixea thesi GIA TIN EPILOGH THS 
    private int CameraIsSet = 1;//simea GIA TIN PROTI TOPOTHETISI TIS KAMERAS
    private GameObject enemie;
    private System.Random rnd = new System.Random();//GIA TIN PITHANOTITA
    private float ATSPperSec=0;//GIA NA EXOUME ENA DELAY STO ATTACK
    public int numberofweapon;//GIA TO PRIN TON WEAPON POSA WEAPON EXW KATHE STIGMI
    public int hpforprint;//ARXIKO LIFE KATHE WEAPON
    public int firsttime;//STIN HIT SINARTISI SIMAIA
    private int timereadvictorymessageflag0 = 0;//BOHTHITIKES SIMAIES OSTE OTAN PATITHEI TO E NA TERMATISEI META APO LIGO TO PAIXNIDI NA DOSEI DLD XRONO STON XRISTI NA DIABASEI TO KIMENO
    private int timereadvictorymessageflag1 = 0;//BOHTHITIKES SIMAIES OSTE OTAN PATITHEI TO E NA TERMATISEI META APO LIGO TO PAIXNIDI NA DOSEI DLD XRONO STON XRISTI NA DIABASEI TO KIMENO
    private float score;//GIA TIN EMFANISI SCORE
    private int sfuria;//POSA SFURIA EXW GIA TIN EMFANISI TOUS

    public int[] xblack;//GIA NA KRATISW TIS SUNTETAGMENES TOU MAUROU KOUTIOU
    private int blackcubeflag = 0;//GIA TIN DIAXIRISI TON X Z PINAKWN KAI TO Y STHN OUSIA
    public int[] zblack;//GIA NA KRATISW TIS SUNTETAGMENES TOU MAUROU KOUTIOU
    private int yblackcall;//GIA TO TELEPORT
    private int yblackcall1;//GIA TO TELEPORT
    private int CHANGE = 1;//GIA TIN ALLAGI KAMERAS
    private int holdfirst = 1;//mia simaia gia na kratisw to proto epiepdo tou maze 
    private int ftimein = 1;
    public Ray ray;
    public RaycastHit hit;
    private float HEALTHBAR;//H ZOH TOU SFURIOU GIA TO GRAFIKO KOMATI POU MIONETE STADIAKA
    List<string> stringlevellist = new List<string>();// domi gia apothikeusi ton level gia print meta

    List<string[,]> mazelist = new List<string[,]>();// domi gia apothikeusi kathe epipedou labirinthou
    // Start is called before the first frame update

    public void GetInput(string inputstring)//erxomai meta to enter STO PROTO PARATHIRO
    {
        Debug.Log("the file was inserted normally " + inputstring);
        path = inputstring;//KRATAW TO PATH WEDW
        readPath = Application.dataPath +"\\" + path;//BAZW OLOKLIRO TO PATH EDW
       // readPath = "C:\\Users\\BASILIS\\Desktop\\game\\" + path;
        Debug.Log(readPath);
        Destroy(GameObject.Find("Canvasfirstscene"));//DIAGRAFO TO ARXIKO PARATHIRO

        LoadfilemazeGenerateGrid(readPath);//diabazw ton labirnithw 
        
        firsttime = 1;
        hpforprint = 100;
        weaponHealth = 100;

    }

    void Start()
    {
        if (Input.GetKey(exitbutton))
        {

            Application.Quit();
            Debug.Log("Game is exiting");
        }

    }


    



    private void LoadfilemazeGenerateGrid(string path)//sunartisi pou mas bohthaei gia to load tou arxeiou .maz
    {
        string line;
        string[] slist;
        int i = 0;
        StreamReader sRead = new StreamReader(path);
        while (!sRead.EndOfStream)
        {
            if (i == 0)
            {
                line = sRead.ReadLine();
                slist = line.Split('=');
                L = int.Parse(slist[1]);
                line = sRead.ReadLine();
                slist = line.Split('=');
                N = int.Parse(slist[1]);
                line = sRead.ReadLine();
                slist = line.Split('=');
                K = int.Parse(slist[1]);
                i = 1;
                maze = new string[N, N];
                xblack = new int[L];
                zblack = new int[L];
                // Instantiate(fpscamera, new Vector3(0,0,0), Quaternion.identity);
                Instantiate(light, new Vector3(N, 2 * L + 2, N), Quaternion.identity);//TOPOTHETISI FOS

                for (int x = 0; x < N; x++)
                {
                    for (int z = 0; z < N; z++)
                    {

                        Instantiate(plane, new Vector3(x, epipeda, z), Quaternion.identity);//TOPOTHETISI DAPEDOU SE N*N
                        Instantiate(plane, new Vector3(x1, epipeda, z1), Quaternion.identity);//2N*2N GIA MEGALITERO XORO
                        z1 = z1 + 2;
                    }
                    z1 = 0;
                    x1 = x1 + 2;

                }
                z1 = 0;
                x1 = 0;
                epipeda = epipeda + 1;//AFOU EBALA GROUND ANEBAINW EPIPEDO  
            }
            else
            {
                line = sRead.ReadLine();
                stringlevellist.Add(line);
               // Debug.Log(line);
                if (line.Equals("END OF MAZE"))
                {
                    break;
                }
                else
                {
                    for (int j = 0; j < N; j++)
                    {
                        line = sRead.ReadLine();
                        slist = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j1 = 0; j1 < N; j1++)
                        {

                            maze[j, j1] = slist[j1];

                          //  Debug.Log(maze[j, j1]);
                        }
                    }
                    if (holdfirst == 1)
                    {
                        maze1 = maze;
                        holdfirst = 2;
                    }
                   
                    if (holdfirst == 2)
                    {//gia tin proti epenalipsi theloume mono na broume ena tuxaio keno 
                        for (int x = 0; x < N; x++)
                        {
                            for (int z = 0; z < N; z++)
                            {
                                if (maze[x, z].Equals("E"))
                                {//METRAME TA KENA
                                    metritisE++;
                                }
                            }
                        }
                        holdfirst = 3;
                        metritisE1 = rnd.Next(0, metritisE + 1);//EPILEGOUME ENA APO TA KENA OPOU THA TOPOTHETITHEI H KAMERA  TUXAIA
                    }


                    for (int x = 0; x < N; x++)
                    {
                        for (int z = 0; z < N; z++)
                        {
                            // Debug.Log(maze3[x, z]);
                            if (maze[x, z].Equals("R"))//EAN EINAI R BALE ENA KOKINO KIBO
                            {
                                Instantiate(Rcube, new Vector3(x1, epipeda, z1), Quaternion.identity);
                            }
                            else if (maze[x, z].Equals("G"))//EAN EINAI G BALE ENA PRASINO KIBO
                            {
                                Instantiate(Gcube, new Vector3(x1, epipeda, z1), Quaternion.identity);
                            }
                            else if (maze[x, z].Equals("B"))//EAN EINAI B BALE ENA MPLE KIBO
                            {
                                Instantiate(Bcube, new Vector3(x1, epipeda, z1), Quaternion.identity);
                            }
                            else if (maze[x, z].Equals("T1"))//EAN EINAI T1 BALE ENA T1 TEXTURE KIBO
                            {
                                Instantiate(T1cube, new Vector3(x1, epipeda, z1), Quaternion.identity);
                            }
                            else if (maze[x, z].Equals("T2"))//EAN EINAI T2 BALE ENA T2 TEXTURE KIBO
                            {
                                Instantiate(T2cube, new Vector3(x1, epipeda, z1), Quaternion.identity);
                            }
                            else if (maze[x, z].Equals("T3"))//EAN EINAI T1 BALE ENA T1 TEXTURE KIBO
                            {
                                Instantiate(T3cube, new Vector3(x1, epipeda, z1), Quaternion.identity);
                            }
                            else if (maze[x, z].Equals("W"))//EAN EINAI W BALE ENA MAURO KIBO
                            {
                                Instantiate(Wcube, new Vector3(x1, epipeda, z1), Quaternion.identity);
                                xblack[blackcubeflag] = x1;//APOTHIKEUSI SINTETAGMENON
                                zblack[blackcubeflag] = z1;
                                blackcubeflag = blackcubeflag + 1;
                            }

                            z1 = z1 + 2;//ME BOHTHAEI STIN PIO AREA TOPOTHETITSI 

                        }
                        z1 = 0;
                        x1 = x1 + 2;
                    }
                    x1 = 0;
                    epipeda = epipeda + 2;
                }
            }

                mazelist.Add(maze);

            }
      
        for (int x = 0; x < N; x++)
        {
            for (int z = 0; z < N; z++)
            {
                if (!(maze1[x, z].Equals("W") || maze1[x, z].Equals("T3") || maze1[x, z].Equals("T2") || maze1[x, z].Equals("T1") || maze1[x, z].Equals("G") || maze1[x, z].Equals("R") || maze1[x, z].Equals("B")))
                {

                    topothetisikameras++;//AUKSANW KATA 1
                    if (topothetisikameras == metritisE1 && CameraIsSet == 1)//EAN DEN EXW TOPOTHETISEI KAMERA KAI EIMAI STO KENO POU THELW BALTIN
                    {

                        //Debug.Log(topothetisikameras);
                        CameraIsSet = 0;

                        //Camera.main.transform.position= Vector3.Slerp(new Vector3(x1, epipeda+2, z1), Camera.main.transform.position, 1f);
                        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;//SBINW TO PALIO FPS DEN MOU XREIAZETAI 

                        enemie = Instantiate(fpscamera, new Vector3(x1, 1, z1), Quaternion.identity);

                        //GameObject.Find("FPSController)").transform.position = new Vector3(x1, epipeda, z1);
                        // Instantiate(fpscamera, new Vector3(x1, epipeda, z1), Quaternion.identity);
                        //Camera.main.transform.position = new Vector3(x1, 1, z1);
                        Destroy(GameObject.Find("FPSController"));//SBINW TO PALIO FPS DEN MOU XREIAZETAI 


                    }
                    //Debug.Log("keno");





                }
                z1 = z1 + 2;//ME BOHTHAEI STIN PIO AREA TOPOTHETITSI  
            }
            z1 = 0;
            x1 = x1 + 2;
        }
        x1 = 0;

        Instantiate(Ztransparent, new Vector3(-1, 0, -1), Quaternion.identity);//Z sthn ousia topotheto ena polu megalo diafenes kibaki oste na min mporei na pesei o kiboso opoios exei megalo z kai mikro x
        Instantiate(Xtransparent, new Vector3(-1, 0, -1), Quaternion.identity);//X edw antistixa exei megalo x kai mikro z 
        Instantiate(Ztransparent, new Vector3(2 * N - 1, 0, 2 * N - 1), Quaternion.identity);//Z antistixa allazw suntetagmenes gia na piasw twra tin katw gonia 
        Instantiate(Xtransparent, new Vector3(2 * N - 1, 0, 2 * N - 1), Quaternion.identity);//X sximatika exw auto 
                                                                                             //          -1-1 _ _ _ _ _ _ _
                                                                                             //              |00 01 02 03 |
                                                                                             //              |10 11 12 13 |
                                                                                             //              |20 21 22 23 |
                                                                                             //              |30 31 32 33 |
                                                                                             //              |............|
                                                                                             //                              (N+1)(N+1) bazw 2*N epeidh ekana x2 tis diastaseis tou paixnidiou  kai to -1 epeidi etsi exw ftiaksei to patoma 
                                                                                             //
                                                                                             //
                                                                                             //





        foreach (string[,] key in mazelist)
            {
                for (int j = 0; j < N; j++)
                {

                    for (int j1 = 0; j1 < N; j1++)
                    {
                      //  Debug.Log(key[j, j1]);
                    }
                }
            }
     }
    


// Update is called once per frame
void Update()// gia na spasei kibakia h gia na mazepsei axe KAI GENIKA GIA OLA TA KOUMPIA
    {
        if (firsttime == 1)
        {//gia tosetarisma tou xromatos sfuriou 
            fpscamera.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = fulllife;//setare to katalilo xroma
        }
        else if (hpforprint <= 100 && hpforprint >= 80) {//apo edw kai pera analoga me to pososto zohs setare to katalilo xroma sto sfuri
            fpscamera.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = fulllife;
        }
        else if (hpforprint < 80 && hpforprint >= 60)
        {

            fpscamera.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = life80;
        }
        else if (hpforprint < 60 && hpforprint >= 40)
        {

            fpscamera.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = life60;
        }
        else if (hpforprint < 40 && hpforprint >= 20)
        {

            fpscamera.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = life40;
        }
        else if (hpforprint < 20 && hpforprint >= 0)
        {

            fpscamera.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = life20;
        }


        if (ATSPperSec < 0)//EPANAFORA DELAY METABLITIS attack
        {
            ATSPperSec = 0;
        }
        if (ATSPperSec > 0)
        {
            ATSPperSec -= Time.deltaTime;//GIA TIN KATHISTERISI TON HITS NA MHN METRAEI APEIRA 
        }
        
        if (Input.GetKey(hitbutton) && ATSPperSec == 0)//KANE XIT EAN EINAI OLA OK  ME TO DELAY
        {
            if (firsttime == 1)//THN PROTI FORA  SETAREI TA EKSIS 
            {

                sfuria = 1;
                weaponHealth = maxHPweapon * K;//EXW 4 SFURIA ? ARA 4*100 400 ZOH 
                                               // Debug.Log(weaponHealth);
                numberofweapon = (weaponHealth / maxHPweapon) - 1;//400/100 -1 DLD 3 GIATI ? EPEIDH EAN EXW 4 SFURIA ENA KRATAW POU FAINETAI 100% KAI 3 STO INVENDORY  
                hpforprint = 100;//SET STO 100 PROFANOS

                firsttime = 0;//MIN KSANA MPEIS SE AUTIN THN IF 
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(1).gameObject.active = true;
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>().text = " Current weapon  			" + (hpforprint) + "%";//DEKSI MINIMA
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(0).GetComponent<Text>().text = "You have " + (numberofweapon) + " weapons in the inventory";//ARISTERO MINIMA
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(2).GetComponent<Text>().text = "SCORE = 0";//ARISTERO MINIMA

            }

            // Debug.Log(maxHPweapon);
            //Debug.Log(luckforaxes);
            //Debug.Log(timereadvictorymessage);
            //Debug.Log(weapondamage);

            // Debug.Log(weaponHealth);

            // Debug.Log(attackCoolDown);

            fpscamera.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Animation>().Play("axe2");//GIA NA KANEI TO ANIMATION
            MusicSourse.clip = axe;//SETARW TON HXO STO SOURCE
            MusicSourse.Play();//PAIKSE TWRA TO KOMATI
            hitcube();//KANE TO HIT
            ATSPperSec = attackCoolDown;//DOSE CD STO ATTACK GIA NA MHN BARAEI SUNEXEIA
            HEALTHBAR = hpforprint * 0.01f;//GIA TIN MPARA THS ZOHS TWN AXE
            ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(1).GetComponent<Image>().fillAmount = HEALTHBAR;//GIA TIN MPARA THS ZOHS TWN AXE


        }




        if (Input.GetKey(collectbutton))//MAZEPSE AXE
        {

            collectaxe();//KALESE THN SUNARTISI POU TO KANEI
            HEALTHBAR = hpforprint * 0.01f;//GIA TIN MPARA THS ZOHS TWN AXE
            ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(1).GetComponent<Image>().fillAmount = HEALTHBAR;//GIA TIN MPARA THS ZOHS TWN AXE

        }
        if (Input.GetKey(exitbutton))//ME TO X BGAINEIS 
        {
           // score = N * N - Time.time - sfuria * 50;

            Application.Quit();//STO EXPORT ARXEIO BGAINEI MONO STON EDITOR DEN BLEPOUME KATI
            Debug.Log("Game is exiting");
            //((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(2).GetComponent<Text>().text = "SCORE:" + score;

        }
        if (Input.GetKey(winbutton))//OTAN PATISEI TO E
        {

            if (fpscamera.transform.position.y >= ((L * 1.9) + 0.1)&& timereadvictorymessageflag1==0)//1.9 y o kathe kibos *L epipeda +0.1y to dapedo kai mpainw proti fora to flag1=0
            {
                timereadvictorymessage = 10;//O XRONOS POU THA KANEI NA FUGEI
                timereadvictorymessageflag1 = 1;//SET THN SIMAIA
                dj4.GetComponent<dj4fixvictorymessage>().play();
                //MusicSourse.clip = mlg;//SETARE TON HXO
               // MusicSourse.Play();//PAIXTON
                timereadvictorymessageflag0 = 1;//SETARE THN DEUTERH SHMAIA
                Debug.Log("win");
                Instantiate(victorymessage, fpscamera.transform.position, Quaternion.identity);//EMFANISE TO MINIMA NIKHS
                score = N * N - Time.time - sfuria * 50;//UPOLOGISE SCORE
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(2).GetComponent<Text>().text = "SCORE:" + score;//EMAFANISE TO



            }
            else
            {
                Debug.Log(fpscamera.transform.position.y);//GIA NA BLEPW POU EIMAI AKRIBOS KAHTE FORA POU PATAW E
            }


        }
        if (timereadvictorymessage > 0 && timereadvictorymessageflag1 == 1 && timereadvictorymessageflag0 == 1)//gia na prolabei na diabasei to message prin klisi to game
        {
            timereadvictorymessage -= Time.deltaTime;//GIA TO DELAY TIME TOU VICTORY MINIMATOS

        }
        else if (timereadvictorymessage <= 0 && timereadvictorymessageflag1 == 1)
        {
            timereadvictorymessageflag1 = 0;
            Application.Quit();//AFOU PERASEI O XRONOS KANE EXIT
            Debug.Log("Game is exiting");

        }

       
        if (Input.GetKey(CHANGECAMERA))//U ALLAZEI THN KAMERA
        {
            if (CHANGE==1) {//EAN DEN EXW ALLAKSEI KAMERA OK MPES NA THN ALLAKSEIS

               
                Instantiate(cameraekswteriki, new Vector3(-1, L / 2, -2 * N / 2), Quaternion.identity);
                //GameObject.Find("FPSController(Clone)").SetActive(false);den douleuei oste na min kouniete h main h kamera meta belakia psilo buged tou unity 
                //fpscamera.transform.GetChild(0).GetComponent<Camera>().enabled = false;

                CHANGE = 0;//TWRA ALLAKSA KAMERA MIA FORA ALLAKSE THN SIAMIA
            }
            
            

        }
        if (Input.GetKey(CHANGECAMERA1))//K WRAIA TWRA SETARE THN KAMERA PALI PISW OPOS HTAN DEN XREIAZETE NA TO APENERGOPOIHSW GIATI UPARXEI SCRIPT STIN KAMERA  TO KANEI EKEI TO K 
        {
            //fpscamera.transform.GetChild(0).GetComponent<Camera>().enabled = true;
            CHANGE = 1;
            
        }


        }

    public void OnTriggerEnter(Collider other)//OTAN KANEI TRIGGER H KAMERA ME TON KIBO UPO KATASKEUH AKOMA 
    {
       
        if (other.gameObject.tag =="Wcube") {
            MusicSourse.clip = teleportsound;
            MusicSourse.Play();
            
            //Debug.Log("mpika");
            
            Instantiate(fpscamera, new Vector3(xblack[(int)this.transform.position.y%2], this.transform.position.y+2, zblack[(int)this.transform.position.y % 2]), Quaternion.identity);
           

            Destroy(fpscamera);
            Destroy(other.gameObject);
            


           // Debug.Log(fpscamera.transform.position);
            
        }


       
    }



private void hitcube() {//OTAN KANEI HIT 


             
       
       
        //numberofweapon = weaponHealth % 100;
        if (hpforprint == 0&& numberofweapon>0)//EAN EXW HP WEAPON STO   0 PREPEI NA ALALKSW WEAPON  KAI NA PAW PALI STO 100 
        {
            sfuria = sfuria + 1;//MAS BOHTHAEI STA POSA SFIRAIA XRISIMOPOIHSA
            hpforprint = 100;//BALTO 100


            numberofweapon = -1;//BGALE ENA SFURI
        }
        int luck;//TYXH GIA TA SFURIA
        int healthcube = 0;//ZOH KUBOU

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out hit, 2) && hit.transform.name != "ground")//SE APOSTASI 2 KAI OXI EDAFOS KANE OTI EINAI NA KANEIS
        {
            
            Debug.Log(hit.transform.position);
            if (hit.collider.tag.Equals("cube")  && weaponHealth > 0)//EAN AUTO POU BLEPW EINAI CUBE KAI EXEI ZOH TO WEAPON MOU BARATO
            {
                
                var newBlockPostion = hit.transform.position;
                
                cubehelath CubeHealth = hit.collider.GetComponent<cubehelath>();//UPARXEI ENA SCRIPT STOUS KIBOUS 
                CubeHealth.TakeDamage(weapondamage);//KANE DAMAGE STON SUGKEKRIMENO KIBO
                weaponHealth = weaponHealth - 10;//MIOSE TO DAMAGE TOU SFURIOU 
                numberofweapon = weaponHealth / maxHPweapon;//POSA WEAPON MOU EMEINAN

                hpforprint = weaponHealth % maxHPweapon;//POSO HP NA TIPOSW TELIKA ?

                
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(0).GetComponent<Text>().text = "You have " + (numberofweapon) + " weapons in the inventory";//MINIMA PANW ARISTERA

                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>().text = " Current weapon  			" + (hpforprint) + "%";//MINIMA PANW DEKSIA


                healthcube = CubeHealth.returnHealth();//POSI ZOH EXEI O KIBOS? AUTO MOU EPISTREFEI 
                Debug.Log(newBlockPostion);
                if (healthcube == 0)//EAN EXEI 0
                {

                    dj2.GetComponent<musicdj2>().playcut();//paizei to 
                    
                    hit.collider.gameObject.SetActive(false);// spaw to koutaki pou den exei pleon allh zoh
                    litlecubes.transform.position = transform.position + newBlockPostion;// setaro to position 
                    //MusicSourse.clip = breakbigcube;
                    //MusicSourse.Play();

                    for (int z = 0; z < 8; z++)//dimiourgia mikrw kibwn otan spaw enan mealo
                    {
                        Instantiate(litlecubes, newBlockPostion, Quaternion.identity);// twra kanw spown 8 mikra kibakia
                        MusicSourse.clip = cubefalling;//SETARE TON IXO
                        MusicSourse.Play();//PAIKSE


                    }
                    luck = rnd.Next(0, luckforaxes);//25% pithanotita gia tsekouri
                    if (luck == 1)//EAN EXW TIXI 1 TOTE SPONARW AXE
                    {

                        litleaxes.transform.position = transform.position + newBlockPostion;//EN TELH DEN TO XERIASTIKA
                        Instantiate(litleaxes, newBlockPostion, Quaternion.identity);// twra kanw spown 1 axe
                    }
                }
                if (weaponHealth == 0)//EAN TO WEAPON DEN EXEI ZOH EKSAFANISE TO EAN EXEI HEALTH 400 SIMAINEI OTI EXW 1 STO XERI 3 STO INVENTORY EKSAFANIZETE OTAN GINEI 0
                {

                    ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(0).gameObject).SetActive(false);
                }



            }
        
            //Visible only on Scene Mode
            //Debug.DrawLine(ray.origin, hit.point, Color.red, 2.5f);
            //print("Hit Something - " + hit.transform.name);
            // print("Found an object - distance: " + hit.distance);



        }

        if (hit.transform != null)
            hitTransformBefore = hit.transform.name;

    }
    


    private void collectaxe()//MAZEPSE  TA AXE
    {

        

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 2) && hit.transform.name != "ground")//SE APOSTASI 2 KAI OXI EDAFOS KANE OTI EINAI NA KANEIS
        {
            if (hit.collider.tag.Equals("axe"))//EAN BRIKES AXE 
            {
                MusicSourse.clip = takeweapon;//EIXOS POU SIKONEIS TOWEAPON
                MusicSourse.Play();//PAIXTON
                hit.collider.gameObject.SetActive(false);//EKSAFANISE TO TWRA
                if (weaponHealth ==0) { 

                    ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(0).gameObject).SetActive(true);
                }
                weaponHealth = weaponHealth + maxHPweapon;// ean brw axe gemizw tin zoh mou +100, 110 shmainei 2 sfiria 1 me 100 zoh ena me 10 
                numberofweapon = weaponHealth / maxHPweapon;//POSA WEAPON EXEIS SUNOLIKA ?
                hpforprint = weaponHealth % maxHPweapon;//POSO HEALTH EXEIS TELIKA ?
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Text>().text = " Current weapon  			" + (hpforprint) + "%";//DEKSI MINIMA
                ((fpscamera.transform.GetChild(0).gameObject).transform.GetChild(2).gameObject).transform.GetChild(0).GetComponent<Text>().text = "You have " + (numberofweapon) + " weapons in the inventory";//ARISTERO MINIMA
            }
            
        }
    }


    
}
