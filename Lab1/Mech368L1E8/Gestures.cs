using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Gestures
{
    public class Gesture
    {
        public string id { get; set; }
        public int[] key { get; set; }

        public int[] sprite { get; set; }
        public int duration { get; set; }
        public Gesture[]? branches { get; set; }

        public static Gesture IDLE;
    }

    class GestureHandler
    {
        public const string GESTURES_PATH = "C:/Users/thoma/UBC/Mech 368/Labs/Lab1/Mech368L1E8/Gestures.JSON";
        public Gesture[] actionsTable;

        public GestureHandler()
        {
            this.LoadActionsTable();
            Gesture.IDLE = new Gesture { id = "Idle" };
            Gesture.IDLE.sprite = new int[] { 60, 0, 45, 95 };
        }

        private bool LoadActionsTable()
        {
            StreamReader sr = new StreamReader(GestureHandler.GESTURES_PATH);
            Gesture[] actions = JsonSerializer.Deserialize<Gesture[]>(sr.ReadToEnd());
            if (actions == null || actions.Length == 0)
                return false;

            this.actionsTable = actions;
            
            sr.Close();
            sr.Dispose();

            return true;
        }

        public bool Interpret(int[] acceleration, out Gesture action, Gesture reference)
        {
            if (reference is null)
                reference = Gesture.IDLE;
            Gesture[] gestureTable = (reference != Gesture.IDLE) ? (reference.branches is null ? new Gesture[0] : reference.branches) : this.actionsTable;

            bool matchfun(Gesture g)
            {
                int signum(int i) { return Convert.ToInt32(i > 0) - Convert.ToInt32(i < 0); }

                int ax = acceleration[0],
                    ay = acceleration[1],
                    az = acceleration[2];

                bool ax_match = (signum(ax) == signum(g.key[0])) && Math.Abs(ax) >= Math.Abs(g.key[0]);
                bool ay_match = (signum(ay) == signum(g.key[1])) && Math.Abs(ay) >= Math.Abs(g.key[1]);
                bool az_match = (signum(az) == signum(g.key[2])) && Math.Abs(az) >= Math.Abs(g.key[2]);

                return ax_match && ay_match && az_match;
            }

            Gesture match = Array.Find(gestureTable, matchfun);
            
            bool idling = match == null;
            action = (idling ? Gesture.IDLE : match);
            return !idling;
        }
    }
}
