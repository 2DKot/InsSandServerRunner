using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsSandServerRunner
{
    public partial class Form1 : Form
    {

        Dictionary<string, string> checkpointScenariosMapping = new Dictionary<string, string>
        {
            {"Canyon", "Canyon?Scenario=Scenario_Crossing_Checkpoint_Security"},
            {"Bab", "Bab?Scenario=Scenario_Bab_Checkpoint_Security"},
            {"Farmhouse", "Farmhouse?Scenario=Scenario_Farmhouse_Checkpoint_Security"},
            {"Town", "Town?Scenario=Scenario_Hideout_Checkpoint_Security"},
            {"Sinjar", "Sinjar?Scenario=Scenario_Hillside_Checkpoint_Security"},
            {"Ministry", "Ministry?Scenario=Scenario_Ministry_Checkpoint_Security"},
            {"Compound", "Compound?Scenario=Scenario_Outskirts_Checkpoint_Security"},
            {"Precinct", "Precinct?Scenario=Scenario_Precinct_Checkpoint_Security"},
            {"Oilfield", "Oilfield?Scenario=Scenario_Refinery_Checkpoint_Security"},
            {"Mountain", "Mountain?Scenario=Scenario_Summit_Checkpoint_Security"},
            {"PowerPlant", "PowerPlant?Scenario=Scenario_PowerPlant_Checkpoint_Security"},
            {"Tell", "Tell?Scenario=Scenario_Tell_Checkpoint_Security"},
            {"Buhriz", "Buhriz?Scenario=Scenario_Tideway_Checkpoint_Security"}
        };

        Dictionary<string, string> checkpointHardcoreScenariosMapping = new Dictionary<string, string>
        {
            {"Canyon", "Canyon?Scenario=Scenario_Crossing_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Bab", "Bab?Scenario=Scenario_Bab_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Farmhouse", "Farmhouse?Scenario=Scenario_Farmhouse_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Town", "Town?Scenario=Scenario_Hideout_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Sinjar", "Sinjar?Scenario=Scenario_Hillside_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Ministry", "Ministry?Scenario=Scenario_Ministry_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Compound", "Compound?Scenario=Scenario_Outskirts_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Precinct", "Precinct?Scenario=Scenario_Precinct_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Oilfield", "Oilfield?Scenario=Scenario_Refinery_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Mountain", "Mountain?Scenario=Scenario_Summit_Checkpoint_Security?Game=CheckpointHardcore"},
            {"PowerPlant", "PowerPlant?Scenario=Scenario_PowerPlant_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Tell", "Tell?Scenario=Scenario_Tell_Checkpoint_Security?Game=CheckpointHardcore"},
            {"Buhriz", "Buhriz?Scenario=Scenario_Tideway_Checkpoint_Security?Game=CheckpointHardcore"}
        };

        Dictionary<string, string> ffaScenariosMapping = new Dictionary<string, string>
        {
            {"Canyon", "Canyon?Scenario=Scenario_Crossing_FFA"},
            {"Precinct", "Precinct?Scenario=Scenario_Precinct_FFA"},
            {"PowerPlant", "PowerPlant?Scenario=Scenario_PowerPlant_FFA"},
            {"Tell", "Tell?Scenario=Scenario_Tell_FFA"}
        };

        Dictionary<string, string> survivalScenariosMapping = new Dictionary<string, string>
        {
            {"Bab", "Bab?Scenario=Scenario_Bab_Survival"},
            {"Farmhouse", "Farmhouse?Scenario=Scenario_Farmhouse_Survival"},
            {"Town", "Town?Scenario=Scenario_Hideout_Survival"},
            {"Sinjar", "Sinjar?Scenario=Scenario_Hillside_Survival"},
            {"Ministry", "Ministry?Scenario=Scenario_Ministry_Survival"},
            {"Compound", "Compound?Scenario=Scenario_Outskirts_Survival"},
            {"Precinct", "Precinct?Scenario=Scenario_Precinct_Survival"},
            {"Oilfield", "Oilfield?Scenario=Scenario_Refinery_Survival"},
            {"Mountain", "Mountain?Scenario=Scenario_Summit_Survival"},
            {"PowerPlant", "PowerPlant?Scenario=Scenario_PowerPlant_Survival"},
            {"Tell", "Tell?Scenario=Scenario_Tell_Survival"},
            {"Buhriz", "Buhriz?Scenario=Scenario_Tideway_Survival"},
        };

        public Form1()
        {
            InitializeComponent();
        }

        public static string ExtractPath(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            // If value starts with a quote, extract content inside quotes
            if (value.StartsWith("\""))
            {
                int endQuote = value.IndexOf('"', 1);
                if (endQuote > 0)
                    return value.Substring(1, endQuote - 1);
            }

            // Otherwise, assume it's space-separated, take first token
            int spaceIndex = value.IndexOf(' ');
            if (spaceIndex > 0)
                return value.Substring(0, spaceIndex);

            return value;
        }

        public static string FindSteamFromRegistry()
        {
            // Registry hives to check - Steam typically installs in LocalMachine
            var hives = new[] { RegistryHive.LocalMachine, RegistryHive.CurrentUser };
            var views = new[] { RegistryView.Registry64, RegistryView.Registry32 };

            foreach (var hive in hives)
            {
                foreach (var view in views)
                {
                    using (var baseKey = RegistryKey.OpenBaseKey(hive, view))
                    {
                        // Try the standard Steam registry locations
                        var steamPaths = new[]
                        {
                            @"SOFTWARE\Valve\Steam",           // 32-bit
                            @"SOFTWARE\Wow6432Node\Valve\Steam" // 64-bit
                        };

                        foreach (var steamPath in steamPaths)
                        {
                            using (var steamKey = baseKey.OpenSubKey(steamPath))
                            {
                                if (steamKey != null)
                                {
                                    var installPath = steamKey.GetValue("InstallPath") as string;
                                    if (!string.IsNullOrEmpty(installPath))
                                    {
                                        Console.WriteLine($"Steam registry entry found: {installPath}");
                                        var exePath = Path.Combine(installPath, "steam.exe");
                                        if (File.Exists(exePath))
                                        {
                                            Console.WriteLine($"Steam found: {exePath}");
                                            return exePath;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Steam not found: {exePath}");
                                        }
                                    }
                                }
                            }
                        }

                        // Fallback to Uninstall registry
                        using (var uninstallKey = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
                        {
                            if (uninstallKey == null) continue;
                            foreach (var subkeyName in uninstallKey.GetSubKeyNames())
                            {
                                using (var subkey = uninstallKey.OpenSubKey(subkeyName))
                                {
                                    var name = subkey.GetValue("DisplayName") as string;
                                    if (string.IsNullOrEmpty(name)) continue;
                                    if (name.Contains("Steam") && !name.Contains("SteamVR"))
                                    {
                                        Console.WriteLine($"Entry found: {name}");
                                        var path = subkey.GetValue("InstallLocation") as string;

                                        if (string.IsNullOrEmpty(path))
                                        {
                                            var uninstallString = subkey.GetValue("UninstallString") as string;
                                            path = ExtractPath(uninstallString);
                                        }

                                        if (string.IsNullOrEmpty(path))
                                        {
                                            var displayIcon = subkey.GetValue("DisplayIcon") as string;
                                            path = ExtractPath(displayIcon);
                                        }

                                        Console.WriteLine($"Path: {path}");

                                        if (!string.IsNullOrEmpty(path))
                                        {
                                            // Build full path to executable
                                            var exePath = Path.Combine(path, "steam.exe");
                                            if (File.Exists(exePath))
                                            {
                                                Console.WriteLine($"Steam found: {exePath}");
                                                return exePath;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Steam not found: {exePath}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return null; // not found
        }

        public static List<string> GetSteamLibraryFolders(string steamInstallPath)
        {
            var libraryFolders = new HashSet<string>();
            
            if (string.IsNullOrEmpty(steamInstallPath) || !Directory.Exists(steamInstallPath))
                return new List<string>();

            // Add the main Steam folder as the first library
            libraryFolders.Add(steamInstallPath);

            // Read libraryfolders.vdf to find additional library folders
            var libraryFoldersVdf = Path.Combine(steamInstallPath, "steamapps", "libraryfolders.vdf");
            if (File.Exists(libraryFoldersVdf))
            {
                Console.WriteLine($"Reading library folders from: {libraryFoldersVdf}");
                try
                {
                    var content = File.ReadAllText(libraryFoldersVdf);
                    Console.WriteLine($"Library folders VDF content:");
                    Console.WriteLine(content);
                    
                    // Parse VDF format - look for path entries
                    var lines = content.Split('\n');
                    
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var line = lines[i].Trim();
                        
                        // Look for lines containing "path" followed by a quoted path
                        if (line.Contains("\"path\""))
                        {
                            // The path should be on the same line after "path"
                            var pathStart = line.IndexOf("\"path\"");
                            if (pathStart >= 0)
                            {
                                // Find the quoted path after "path"
                                var afterPath = line.Substring(pathStart + 6).Trim();
                                if (afterPath.StartsWith("\"") && afterPath.EndsWith("\""))
                                {
                                    var path = afterPath.Trim('"');
                                    // Convert double backslashes to single backslashes
                                    path = path.Replace("\\\\", "\\");
                                    
                                    if (Directory.Exists(path))
                                    {
                                        libraryFolders.Add(path);
                                        Console.WriteLine($"Found library folder: {path}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Library folder does not exist: {path}");
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading libraryfolders.vdf: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Library folders VDF not found: {libraryFoldersVdf}");
            }

            return libraryFolders.ToList();
        }

        public static string FindInsurgencySandstormServer(List<string> libraryFolders)
        {
            // Insurgency Sandstorm Dedicated Server Steam App ID
            const int insurgencyServerAppId = 581330;
            
            foreach (var libraryFolder in libraryFolders)
            {
                var steamappsPath = Path.Combine(libraryFolder, "steamapps");
                if (!Directory.Exists(steamappsPath)) continue;

                Console.WriteLine($"Searching in library folder: {libraryFolder}");

                // List all app manifests to help debug
                var allManifests = Directory.GetFiles(steamappsPath, "appmanifest_*.acf");
                Console.WriteLine($"Found {allManifests.Length} app manifests in this library:");
                foreach (var manifest in allManifests)
                {
                    var fileName = Path.GetFileName(manifest);
                    Console.WriteLine($"  - {fileName}");
                }

                // Look for the specific Insurgency Sandstorm Server manifest
                var appManifestFile = Path.Combine(steamappsPath, $"appmanifest_{insurgencyServerAppId}.acf");
                Console.WriteLine($"Looking for: {appManifestFile}");
                Console.WriteLine($"File exists: {File.Exists(appManifestFile)}");
                
                if (File.Exists(appManifestFile))
                {
                    Console.WriteLine($"Found Insurgency Sandstorm Server manifest: {appManifestFile}");
                    
                    try
                    {
                        // Parse the ACF file to get installation directory
                        var content = File.ReadAllText(appManifestFile);
                        var lines = content.Split('\n');
                        
                        string installDir = null;
                        string name = null;
                        
                        foreach (var line in lines)
                        {
                            if (line.Contains("\"installdir\""))
                            {
                                // Extract the directory name after "installdir"
                                // Look for the pattern: "installdir"		"directory_name"
                                var match = System.Text.RegularExpressions.Regex.Match(line, @"""installdir""\s+""([^""]+)""");
                                if (match.Success)
                                {
                                    installDir = match.Groups[1].Value;
                                }
                            }
                            else if (line.Contains("\"name\""))
                            {
                                // Extract the game name
                                // Look for the pattern: "name"		"game_name"
                                var match = System.Text.RegularExpressions.Regex.Match(line, @"""name""\s+""([^""]+)""");
                                if (match.Success)
                                {
                                    name = match.Groups[1].Value;
                                }
                            }
                        }
                        
                        Console.WriteLine($"App name: {name}");
                        Console.WriteLine($"Install directory: {installDir}");
                        
                        if (!string.IsNullOrEmpty(installDir))
                        {
                            var serverPath = Path.Combine(steamappsPath, "common", installDir);
                            Console.WriteLine($"Full path: {serverPath}");
                            Console.WriteLine($"Directory exists: {Directory.Exists(serverPath)}");
                            
                            if (Directory.Exists(serverPath))
                            {
                                // Look for any executable files
                                var exeFiles = Directory.GetFiles(serverPath, "*.exe", SearchOption.TopDirectoryOnly);
                                Console.WriteLine($"Found {exeFiles.Length} executable files:");
                                foreach (var exe in exeFiles)
                                {
                                    Console.WriteLine($"  - {Path.GetFileName(exe)}");
                                }
                                
                                // Look for server executables specifically
                                var serverExeFiles = Directory.GetFiles(serverPath, "*Server*.exe", SearchOption.TopDirectoryOnly);
                                if (serverExeFiles.Length > 0)
                                {
                                    var serverExe = serverExeFiles[0]; // Take the first match
                                    Console.WriteLine($"Found server executable: {serverExe}");
                                    return serverExe;
                                }
                                else
                                {
                                    Console.WriteLine($"No server executable found in: {serverPath}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Server directory does not exist: {serverPath}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing app manifest: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"App manifest not found: {appManifestFile}");
                }
            }
            
            return null; // not found
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string exe = FindSteamFromRegistry();
            if (exe == null)
            {
                MessageBox.Show("Could not find steam.exe via registry. Please select manually.");
                return;
            }

            if (exe != null)
            {
                // Get Steam installation directory
                var steamDir = Path.GetDirectoryName(exe);
                Console.WriteLine($"Steam directory: {steamDir}");
                
                // Get all Steam library folders
                var libraryFolders = GetSteamLibraryFolders(steamDir);
                Console.WriteLine($"Found {libraryFolders.Count} Steam library folders:");
                foreach (var folder in libraryFolders)
                {
                    Console.WriteLine($"  - {folder}");
                }

                // Find Insurgency Sandstorm Dedicated Server
                var serverExe = FindInsurgencySandstormServer(libraryFolders);
                if (serverExe != null)
                {
                    Console.WriteLine($"Starting Insurgency Sandstorm Server: {serverExe}");
                    
                    // Get values from text fields and concatenate them
                    var mapCommand = this.mapCommand.Text?.Trim() ?? "";
                    var serverArgs = this.serverArgs.Text?.Trim() ?? "";
                    var fullArguments = $"{mapCommand} {serverArgs}".Trim();
                    
                    Console.WriteLine($"Map command: {mapCommand}");
                    Console.WriteLine($"Server args: {serverArgs}");
                    Console.WriteLine($"Full arguments: {fullArguments}");
                    
                    var psi = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = serverExe,
                        Arguments = fullArguments,
                        WorkingDirectory = Path.GetDirectoryName(serverExe),
                        UseShellExecute = false,
                        CreateNoWindow = false
                    };
                    System.Diagnostics.Process.Start(psi);
                }
                else
                {
                    MessageBox.Show("Could not find Insurgency Sandstorm Dedicated Server. Please install it via Steam first.");
                }
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://mod.io/g/insurgencysandstorm/r/server-admin-guide",
                UseShellExecute = true
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Find Steam and get library folders
            string exe = FindSteamFromRegistry();
            if (exe == null)
            {
                MessageBox.Show("Could not find steam.exe via registry.");
                return;
            }

            var steamDir = Path.GetDirectoryName(exe);
            var libraryFolders = GetSteamLibraryFolders(steamDir);

            // Find Insurgency Sandstorm Dedicated Server
            var serverExe = FindInsurgencySandstormServer(libraryFolders);
            if (serverExe != null)
            {
                var serverDir = Path.GetDirectoryName(serverExe);
                var configDir = Path.Combine(serverDir, "Insurgency", "Saved", "Config", "WindowsServer");
                Console.WriteLine($"Opening server config folder: {configDir}");
                
                // Open the server config folder in Windows Explorer
                System.Diagnostics.Process.Start("explorer.exe", configDir);
            }
            else
            {
                MessageBox.Show("Could not find Insurgency Sandstorm Dedicated Server. Please install it via Steam first.");
            }
        }

        private void CheckpointScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == CheckpointScenarios && CheckpointScenarios.SelectedItem != null)
            {
                string selectedMap = CheckpointScenarios.SelectedItem.ToString();
                if (checkpointScenariosMapping.ContainsKey(selectedMap))
                {
                    mapCommand.Text = checkpointScenariosMapping[selectedMap];
                    Console.WriteLine($"Selected checkpoint map: {selectedMap}, Set mapCommand to: {mapCommand.Text}");
                }
            }
            else if (sender == CheckpointHardcoreScenarios && CheckpointHardcoreScenarios.SelectedItem != null)
            {
                string selectedMap = CheckpointHardcoreScenarios.SelectedItem.ToString();
                if (checkpointHardcoreScenariosMapping.ContainsKey(selectedMap))
                {
                    mapCommand.Text = checkpointHardcoreScenariosMapping[selectedMap];
                    Console.WriteLine($"Selected checkpoint hardcore map: {selectedMap}, Set mapCommand to: {mapCommand.Text}");
                }
            }
            else if (sender == FfaScenarios && FfaScenarios.SelectedItem != null)
            {
                string selectedMap = FfaScenarios.SelectedItem.ToString();
                if (ffaScenariosMapping.ContainsKey(selectedMap))
                {
                    mapCommand.Text = ffaScenariosMapping[selectedMap];
                    Console.WriteLine($"Selected FFA map: {selectedMap}, Set mapCommand to: {mapCommand.Text}");
                }
            }
            else if (sender == SurvivalScenarios && SurvivalScenarios.SelectedItem != null)
            {
                string selectedMap = SurvivalScenarios.SelectedItem.ToString();
                if (survivalScenariosMapping.ContainsKey(selectedMap))
                {
                    mapCommand.Text = survivalScenariosMapping[selectedMap];
                    Console.WriteLine($"Selected Survival map: {selectedMap}, Set mapCommand to: {mapCommand.Text}");
                }
            }
        }

    }
}
