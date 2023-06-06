namespace UseOfHangfire.Data
{
    public class HangfireDbContext
    {
        private List<string> names;

        public HangfireDbContext()
        {
            names= new List<string>() 
            {
                "yalcin", "selcuk"
            };
        }

        public void GetNames()
        {
            foreach(var name in names) {
                Console.WriteLine(name);
            }
        }
    }
}
