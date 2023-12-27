using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditMenu;
   public void StartButton()
   {
        SceneManager.LoadScene("Main");
   }
   public void CreditsButton()
   {
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
   }
   public void QuitButton()
   {
        Application.Quit();
   }
    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        creditMenu.SetActive(false);
    }
}
