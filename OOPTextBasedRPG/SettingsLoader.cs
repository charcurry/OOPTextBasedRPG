using OOPTextBasedRPG;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

public static class SettingsLoader
{
    public static Settings LoadSettings(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        Settings settings =  JsonSerializer.Deserialize<Settings>(jsonString);

        if (settings.Player != null)
        {
            Debug.WriteLine("Add player colors");
            settings.Player.Color = ConvertJSONToConsoleColor(settings.Player.ColorName);
            settings.Player.DefaultConsoleColor = ConvertJSONToConsoleColor(settings.Player.DefaultConsoleColorName);
        }
        if (settings.Enemies != null)
        {
            Debug.WriteLine("Add enemy colors");
            settings.Enemies.Slime.Color = ConvertJSONToConsoleColor(settings.Enemies.Slime.ColorName);
            settings.Enemies.Bat.Color = ConvertJSONToConsoleColor(settings.Enemies.Bat.ColorName);
            settings.Enemies.LightningSpirit.Color = ConvertJSONToConsoleColor(settings.Enemies.LightningSpirit.ColorName);
        }
        if (settings.Items != null)
        {
            Debug.WriteLine("Add item colors");
            settings.Items.HealthItem.Color = ConvertJSONToConsoleColor(settings.Items.HealthItem.ColorName);
            settings.Items.ShieldItem.Color = ConvertJSONToConsoleColor(settings.Items.ShieldItem.ColorName);
            settings.Items.KeyItem.Color = ConvertJSONToConsoleColor(settings.Items.KeyItem.ColorName);
        }
        if (settings.Map != null)
        {
            Debug.WriteLine("Add map colors");
            settings.Map.AirTileColor = ConvertJSONToConsoleColor(settings.Map.AirTileColorName);
            settings.Map.WaterTileColor = ConvertJSONToConsoleColor(settings.Map.WaterTileColorName);
            settings.Map.DoorTileColor = ConvertJSONToConsoleColor(settings.Map.DoorTileColorName);
            settings.Map.WallTileColor = ConvertJSONToConsoleColor(settings.Map.WallTileColorName);
        }
        if (settings.Player.Controls != null)
        {
            Debug.WriteLine("Add player controls");
            settings.Player.Controls.UpKey = ConvertJSONToConsoleKey(settings.Player.Controls.UpKeyName);
            settings.Player.Controls.DownKey = ConvertJSONToConsoleKey(settings.Player.Controls.DownKeyName);
            settings.Player.Controls.LeftKey = ConvertJSONToConsoleKey(settings.Player.Controls.LeftKeyName);
            settings.Player.Controls.RightKey = ConvertJSONToConsoleKey(settings.Player.Controls.RightKeyName);
            settings.Player.Controls.AltUpKey = ConvertJSONToConsoleKey(settings.Player.Controls.AltUpKeyName);
            settings.Player.Controls.AltDownKey = ConvertJSONToConsoleKey(settings.Player.Controls.AltDownKeyName);
            settings.Player.Controls.AltLeftKey = ConvertJSONToConsoleKey(settings.Player.Controls.AltLeftKeyName);
            settings.Player.Controls.AltRightKey = ConvertJSONToConsoleKey(settings.Player.Controls.AltRightKeyName);
        }
        //Debug.WriteLine(jsonString);
        Debug.WriteLine(settings.Player.Controls.DownKey);
        return settings;
    }

    public static ConsoleColor ConvertJSONToConsoleColor(string colorName)
    {
        if (Enum.TryParse(colorName, true, out ConsoleColor color))
        {
            return color;
        }
        else
        {
            throw new ArgumentException("Invalid color name of " + colorName);
        }
    }

    public static ConsoleKey ConvertJSONToConsoleKey(string keyName)
    {
        if (Enum.TryParse(keyName, true, out ConsoleKey consoleKey))
        {
            return consoleKey;
        }
        else
        {
            throw new ArgumentException("Invalid key name of " + keyName);
        }
    }
}

