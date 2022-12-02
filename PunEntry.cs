namespace The_Oracle
{
    public class PunEntry
    {
        public int UID { get; set; }
        public string Category{ get; set; }
        public string Text { get; set; }
        public int Quality { get; set; }
        public string Tags { get; set; }
        public string[] SplitTags { 
            get 
            {
                string[] result = Tags.Split(' ');
                if (result.Length == 1 && result[0] == "")
                    return new string[] { };
                return Tags.Split(' '); 

            }}
        public bool IsTopical { get; set; }
        public bool Used { get; set; }

        public PunEntry()
        {
            UID = -1; // This will indicate this is a fake entry
        }
    }
}