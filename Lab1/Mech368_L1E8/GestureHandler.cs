using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Mech368_L1E8
{
    class Action
    {
        public string id { get; set; }
        public int[] key { get; set; }
        public int duration { get; set; }
        public Action[]? branches { get; set; }
    }

    class GestureHandler
    {
        public Action action, baseAction;

        public GestureHandler()
        {

        }

        public LoadGestures(string path)
        {
            StreamReader sr = new StreamReader("C:/Users/thoma/UBC/Mech 368/Labs/Lab1/Mech368Lab1E7/Gestures.JSON");
            this.baseAction = JsonSerializer.Deserialize<Action>(sr.ReadToEnd());
            this.action = this.baseAction;
            sr.Close();
            sr.Dispose();
        }
    }
}
