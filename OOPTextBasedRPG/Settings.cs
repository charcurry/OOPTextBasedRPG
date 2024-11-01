using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTextBasedRPG
{

    public class Settings
    {
        public PlayerSettings Player { get; set; }
        public EnemySettings Enemies { get; set; }
        public ItemSettings Items { get; set; }
        public MapSettings Map { get; set; }
        public HUDSettings HUD { get; set; }
    }

    public class PlayerSettings
    {
        public ConsoleColor DefaultConsoleColor { get; set; }
        public string DefaultConsoleColorName { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public ConsoleColor Color { get; set; }
        public string ColorName { get; set; }
        public string Icon { get; set; }

        public Point2D SpawnPoint { get; set; }// = new Point2D(3, 3);

        public ControlsSettings Controls { get; set; }
    }

    public class ControlsSettings
    {
        public ConsoleKey UpKey { get; set; }
        public ConsoleKey DownKey { get; set; }
        public ConsoleKey LeftKey { get; set; }
        public ConsoleKey RightKey { get; set; }
        public ConsoleKey AltUpKey { get; set; }
        public ConsoleKey AltDownKey { get; set; }
        public ConsoleKey AltLeftKey { get; set; }
        public ConsoleKey AltRightKey { get; set; }
        public ConsoleKey QuitKey { get; set; }
        public string UpKeyName { get; set; }
        public string DownKeyName { get; set; }
        public string LeftKeyName { get; set; }
        public string RightKeyName { get; set; }
        public string AltUpKeyName { get; set; }
        public string AltDownKeyName { get; set; }
        public string AltLeftKeyName { get; set; }
        public string AltRightKeyName { get; set; }
        public string QuitKeyName { get; set; }
    }

    public class EnemySettings
    {
        public SlimeSettings Slime { get; set; }
        public BatSettings Bat { get; set; }
        public LightningSpiritSettings LightningSpirit { get; set; }
    }

    public class SlimeSettings
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public ConsoleColor Color { get; set; }
        public string ColorName { get; set; }
        public string Icon { get; set; }
        public int MaxDetectionRadius { get; set; }
    }

    public class BatSettings
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public ConsoleColor Color { get; set; }
        public string ColorName { get; set; }
        public string Icon { get; set; }
    }

    public class LightningSpiritSettings
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public int MaxShield { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        public ConsoleColor Color { get; set; }
        public string ColorName { get; set; }
        public string Icon { get; set; }
    }

    public class ItemSettings
    {
        public HealthItemSettings HealthItem { get; set; }
        public ShieldItemSettings ShieldItem { get; set; }
        public KeyItemSettings KeyItem { get; set; }
    }

    public class HealthItemSettings
    {
        public ConsoleColor Color { get; set; }
        public string ColorName { get; set; }
        public string Icon { get; set; }
        public int HealingValue { get; set; }
    }

    public class ShieldItemSettings
    {
        public ConsoleColor Color { get; set; }
        public string ColorName { get; set; }
        public string Icon { get; set; }
        public int HealingValue { get; set; }
    }
    public class KeyItemSettings
    {
        public ConsoleColor Color { get; set; }
        public string ColorName { get; set; }
        public string Icon { get; set; }
    }


    public class HUDSettings
    {
        public int TimerDuration { get; set; }
        public string ContinueText { get; set; }
        public string GameOverText { get; set; }
        public string VictoryText { get; set; }
    }

    public class MapSettings
    {
        public ConsoleColor AirTileColor { get; set; }
        public string AirTileColorName { get; set; }
        public ConsoleColor WallTileColor { get; set; }
        public string WallTileColorName { get; set; }
        public ConsoleColor DoorTileColor { get; set; }
        public string DoorTileColorName { get; set; }
        public ConsoleColor WaterTileColor { get; set; }
        public string WaterTileColorName { get; set; }
        public char AirTile { get; set; }
        public char WallTile { get; set; }
        public char DoorTile { get; set; }
        public char WaterTile { get; set; }
        public int BorderOffset { get; set; }
        public int MovesToGetThroughWater { get; set; }
    }
}
