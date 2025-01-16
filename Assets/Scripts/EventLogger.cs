using System.Collections.Generic;
using UnityEngine;

public class EventLogger : MonoBehaviour
{
    private float startTime;
    private float menuOpenTime;
    private float colorChosenTime;
    private float mainMenuChosenTime;
    private float materialChosenTime;
    private float sizeChosenTime;
    private int incorrectClicks = 0;
    private List<string> logEntries = new List<string>();

    private string chosenColor = "";
    private string chosenMainMenu = "";
    private string chosenMaterial = "";
    private string chosenSize = "";

    private void Start()
    {
        startTime = Time.time;
        logEntries.Add("timestamp,Action,Details,TimeSinceLastAction");
    }

    // Metod f�r huvudmenyknappen
    /*public void OnMainMenuButtonActivated()
    {
        menuOpenTime = Time.time - startTime;
        float timeToChooseMenu = mainMenuChosenTime - (menuOpenTime > 0 ? menuOpenTime : 0);
        string availableOptions = "color,material,size"; // Detaljer om tillg�ngliga alternativ
        logEntries.Add($"{menuOpenTime},MainMenuButtonActivated,{availableOptions},{menuOpenTime}");
        Debug.Log($"Huvudmeny �ppnad vid: {menuOpenTime} sekunder. Tillg�ngliga alternativ: {availableOptions}");
        Debug.Log($"Material '{mainMenuName}' valt vid: {mainMenuChosenTime} sekunder (tid att v�lja: {timeToChooseMenu} sekunder)");

        chosenMenu = mainMenuName;
        CheckAllChoicesMade();
    }
    */

    public void OnMainMenuButtonActivated(string mainMenuName)
    {
        mainMenuChosenTime = Time.time - startTime;
        float timeToChooseMainMenu = mainMenuChosenTime - (menuOpenTime > 0 ? menuOpenTime : 0);
        logEntries.Add($"{mainMenuChosenTime},MainMenuButtonActivated,{mainMenuName},{timeToChooseMainMenu}");
        Debug.Log($"F�rg '{mainMenuName}' vald vid: {mainMenuChosenTime} sekunder (tid att v�lja: {timeToChooseMainMenu} sekunder)");

        chosenMainMenu = mainMenuName;
        CheckAllChoicesMade();
    }

    // Metod f�r f�rgknapparna
    public void OnColorButtonActivated(string colorName)
    {
        colorChosenTime = Time.time - startTime;
        float timeToChooseColor = colorChosenTime - (menuOpenTime > 0 ? menuOpenTime : 0);
        logEntries.Add($"{colorChosenTime},ColorButtonActivated,{colorName},{timeToChooseColor}");
        Debug.Log($"F�rg '{colorName}' vald vid: {colorChosenTime} sekunder (tid att v�lja: {timeToChooseColor} sekunder)");

        chosenColor = colorName;
        CheckAllChoicesMade();
    }

    // Metod f�r materialknapparna
    public void OnMaterialButtonActivated(string materialName)
    {
        materialChosenTime = Time.time - startTime;
        float timeToChooseMaterial = materialChosenTime - (colorChosenTime > 0 ? colorChosenTime : menuOpenTime);
        logEntries.Add($"{materialChosenTime},MaterialButtonActivated,{materialName},{timeToChooseMaterial}");
        Debug.Log($"Material '{materialName}' valt vid: {materialChosenTime} sekunder (tid att v�lja: {timeToChooseMaterial} sekunder)");

        chosenMaterial = materialName;
        CheckAllChoicesMade();
    }

    // Metod f�r storleksknappen
    public void OnSizeButtonActivated(string sizeName)
    {
        sizeChosenTime = Time.time - startTime;
        float timeToChooseSize = sizeChosenTime - (materialChosenTime > 0 ? materialChosenTime : (colorChosenTime > 0 ? colorChosenTime : menuOpenTime));
        logEntries.Add($"{sizeChosenTime},SizeButtonActivated,{sizeName},{timeToChooseSize}");
        Debug.Log($"Storlek '{sizeName}' vald vid: {sizeChosenTime} sekunder (tid att v�lja: {timeToChooseSize} sekunder)");

        chosenSize = sizeName;
        CheckAllChoicesMade();
    }

    // Metod f�r att registrera felklick
    public void OnIncorrectButtonActivated(string buttonName)
    {
        incorrectClicks++;
        float currentTime = Time.time - startTime;
        logEntries.Add($"{currentTime},IncorrectButtonActivated,{buttonName},{currentTime}");
        Debug.Log($"Felaktig knapp '{buttonName}' klickad vid: {currentTime} sekunder");
    }

    // Metod f�r att kontrollera om alla val har gjorts
    private void CheckAllChoicesMade()
    {
        if (chosenColor == "Red" && chosenMaterial == "Wood" && chosenSize == "Large")
        {
            float totalTime = Time.time - startTime;
            logEntries.Add($"{totalTime},AllChoicesMade,Red,Wood,Large,TimeToComplete={totalTime} sec,IncorrectClicks={incorrectClicks}");
            Debug.Log($"Alla val har gjorts: R�d f�rg, Tr�material, Storlek Large vid: {totalTime} sekunder (felklick: {incorrectClicks})");
        }
    }

    // Metod f�r att spara loggen till en fil
    public void SaveLogToFile()
    {
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, "log_" + Time.timeAsDouble + ".txt");
        System.IO.File.WriteAllLines(filePath, logEntries);
        Debug.Log($"Logg sparad till: {filePath}");
    }

    // Metod f�r att avsluta applikationen och spara loggen
    public void ExitAndSave()
    {
        SaveLogToFile(); // Spara loggen
        Debug.Log("Avslutar applikationen och sparar loggen.");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // St�ng i Unity Editor
#else
        Application.Quit(); // St�ng i frist�ende build
#endif
    }

    private void OnApplicationQuit()
    {
        SaveLogToFile();
    }
}
