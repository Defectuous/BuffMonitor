using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using ArcheBuddy.Bot.Classes;

namespace ArcheageBuffMonitor {
    public class BuffMonitor : Core
    {
        public static string GetPluginAuthor()
        { return "Defectuous"; }
        public static string GetPluginVersion()
        { return "1.0.0.0"; }
        public static string GetPluginDescription()
        { return "Buff Monitor: Insert Something About Buffs Here"; }
        
        /// How this works
        //  #1 Checks to see if Buff gone
        //  #2 Checks to see if you have the item needed
        //  #3 Checks to see if you want to use it
        //  #4 uses that item
        //  #5 Rinse and Repeat
        ///
        
        

        // Item ID's
        
        // Tyrenos's Index ( Library Use Only Item )
        uint _BuffID0  = 8240;
        uint _ItemID0  = 34242;
        bool _Itemuse0 = true;

        // Lucky Quicksilver Tonic
        int _BuffID1   = 8000009;
        int _ItemID1   = 8000019;
        bool _Itemuse1 = true;
        
        // Greedy Dwarven Elixir
        int _BuffID2   = 8000022;
        int _ItemID2   = 8000082;
        bool _Itemuse2 = true;
        
        // Unstoppable Force
        uint _BuffID3  = 7478;
        uint _ItemID3  = 31777;
        bool _Itemuse3 = true;
        
        // Brick Wall
        int _BuffID4   = 7477;
        int _ItemID4   = 31776;
        bool _Itemuse4 = true;
        
        //Call on plugin start
        public void PluginRun()
        {
            ClearLogs();
            Log(Time() + "Starting Buff Monitor");
            while(true)
            {
                if (buffTime(_BuffID0) == 0 && itemCount(_ItemID0) >= 1 && _Itemuse0 == true)
                    {
                        Log(Time() + "Using Tyrenos's Index");
                        UseItem(8000019);
                        Thread.Sleep(2500); // Rest for 2.5 seconds ( little over the global cooldown )
                        }
                
                    if (buffTime(8000009) == 0 && itemCount(8000019) >= 1 && _Itemuse1 == true)
                    {
                        Log(Time() + "Using Quicksilver Tonic");
                        UseItem(8000019);
                        Thread.Sleep(2500); // Rest for 2.5 seconds ( little over the global cooldown )
                        }
                    
                if (buffTime(8000022) == 0 && itemCount(8000082) >= 1 && _Itemuse2 == true)
                    {
                        Log(Time() + "Greedy Dwarven Elixir");
                        UseItem(8000082);
                        Thread.Sleep(2500); // Rest for 2.5 seconds ( little over the global cooldown )
                        }
                    
                if (buffTime(7478) == 0 && itemCount(31777) >= 1 && _Itemuse3 == true)
                    {
                        Log(Time() + "Using Spellbook: Unstoppable Force");
                        UseItem(31777);
                        Thread.Sleep(2500); // Rest for 2.5 seconds ( little over the global cooldown )
                        }
                
                if (buffTime(7477) == 0 && itemCount(31776) >= 1 && _Itemuse4 == true)
                    {
                        Log(Time() + "Using Spellbook: Brick Wall");
                        UseItem(31776);
                        Thread.Sleep(2500); // Rest for 2.5 seconds ( little over the global cooldown )
                    }
                                                             
                var Tyrian = (buffTime(8240) / 1000 / 60); 
                var Tonic  = (buffTime(8000009) / 1000 / 60); 
                var Elixir = (buffTime(8000022) / 1000 / 60);
                var Force  = (buffTime(7478) / 1000 / 60);
                var Wall   = (buffTime(7477) / 1000 / 60);
                
                Log(" ");
                if (_Itemuse0 == true ) { Log(Time() + "Grand Tyrenos's Index Timer:  " + Tyrian + " Minutes"); }
                
                if (_Itemuse1 == true ) { Log(Time() + "Quicksilver Tonic Timer:  " + Tonic + " Minutes"); }
                if (_Itemuse2 == true ) { Log(Time() + "Greedy Dwarven Elixir Timer:  " + Elixir + " Minutes"); }
                
                if (_Itemuse3 == true ) { Log(Time() + "Spellbook: Unstoppable Force Timer:  " + Force + " Minutes"); }
                if (_Itemuse4 == true ) { Log(Time() + "Spellbook: Brick Wall Timer:  " + Wall + " Minutes"); }     
                
                Log(Time() + "Checking again in 60 seconds");    
                Thread.Sleep(60000); // 60 seconds
                Log(" ");
                Log(Time() + "Starting Next Check");
            }
        }

        public string Time()
        {
            string A = DateTime.Now.ToString("[hh:mm:ss] ");
            return A;
        }
        
        //Call on plugin stop
        public void PluginStop()
        {
        }
    }
}
