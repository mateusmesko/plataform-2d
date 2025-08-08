using UnityEngine;

public class OpenMenuOnGame : MonoBehaviour
{
    public Canvas menuCanvas;
    public Camera camera1;
    public Camera camera2;

    private bool menuAberto = false;

    void Start()
    {
        if (camera2 != null)
        {
            camera2.targetDisplay = 0;
            camera2.gameObject.SetActive(false); // Garante que começa desativada
        }

        if (menuCanvas != null)
            menuCanvas.gameObject.SetActive(false); // Menu começa oculto
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            menuAberto = !menuAberto;

            if (menuCanvas != null)
                menuCanvas.gameObject.SetActive(menuAberto);

            if (camera1 != null)
                camera1.gameObject.SetActive(!menuAberto); // Desativa camera1

            if (camera2 != null)
                camera2.gameObject.SetActive(menuAberto);  // Ativa camera2
        }
    }
}
