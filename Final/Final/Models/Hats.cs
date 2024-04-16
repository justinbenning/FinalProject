using Org.BouncyCastle.Bcpg;

namespace Final.Models
{
    public class Hats
    {
        public Hats()
        {

        }
        public int idHats {  get; set; }
        public string HatsTeamLocation { get; set; }
        public string HatsTeamName { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set;}

        public string DateLastWorn {  get; set; }
        public string LinkToImage {  get; set; }

        
        
    }
}
