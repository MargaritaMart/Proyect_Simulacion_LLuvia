using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controler : MonoBehaviour
{
    public GameObject gotita;
    public int gotitaC;
    public float WINDSPEED;
    private Slider windSlider, gotitasSlider;
    public Text datoWind, datoGotitas;
    public Button iniciar, modificar, salir;
    private bool start = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generador", 0.5f, 0.5f);

        windSlider = GameObject.Find("SliderViento").GetComponent<Slider>();
        gotitasSlider = GameObject.Find("SliderGotas").GetComponent<Slider>();
        datoWind = GameObject.Find("TextDatoViento").GetComponent<Text>();
        datoGotitas = GameObject.Find("TextDatoGotas").GetComponent<Text>();

        iniciar.onClick.AddListener(IniciarPro);
        modificar.onClick.AddListener(Modifi);
        salir.onClick.AddListener(Exit);

    }
    // Update is called once per frame
    void Update()
    {

    }

    void IniciarPro()
    {
        start = true;
    }
    void Modifi()
    {
        start = false;
    }
    public void Exit()
    {
        Application.Quit();
    }

    void TomaDatos()
    {
        WINDSPEED = windSlider.value;
        gotitaC = (int)gotitasSlider.value;
        datoWind.text = WINDSPEED.ToString();
        datoGotitas.text = gotitaC.ToString();
    }

    void Generador()
    {
        if (start)
        {
            for (int i = 0; i < gotitaC; i++)
            {
                Instantiate(gotita, new Vector3(Random.Range(-15, 15), Random.Range(8, 14), Random.Range(-4, 4)), Quaternion.identity);
            }
        }
        else
        {
            TomaDatos();
        }
    }

}
