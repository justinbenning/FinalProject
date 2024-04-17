using Dapper;
using Final.Models;
using Org.BouncyCastle.Utilities;
using System.Data;
using System.Data.Common;
using System.Security.AccessControl;

namespace Final
{
    public class HatRepository : IHatRepository
    {

        private readonly IDbConnection _conn;
        public HatRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Hats> GetAllHats()
        {
            return _conn.Query<Hats>("SELECT * FROM Hats;");
        }

        public Hats GetHatsById(int id)
        {
            return _conn.QuerySingle<Hats>("SELECT * FROM Hats WHERE idHats = @id", new { id = id });
        }



        public void UpdateHats(Hats hats)
        {
            _conn.Execute("UPDATE Hats SET HatsTeamLocation = @location, HatsTeamName = @name, PrimaryColor = @primarycolor, SecondaryColor = @secondarycolor, DateLastWorn = @datelastworn, LinkToImage = @linktoimage WHERE idHats = @id",
            new { location = hats.HatsTeamLocation, name = hats.HatsTeamName, primarycolor = hats.PrimaryColor, secondarycolor = hats.SecondaryColor, DateLastWorn = hats.DateLastWorn, LinkToImage = hats.LinkToImage, id = hats.idHats });
        }
        public void InsertHat(Hats hatToInsert)
        {
            _conn.Execute("INSERT INTO Hats (HatsTeamLocation, HatsTeamName, PrimaryColor, SecondaryColor, DateLastWorn, LinkToImage) VALUES (@hatsteamlocation, @hatsteamname, @primarycolor, @secondarycolor, @datelastworn, @linktoimage);",
            new
            {
                hatsteamlocation = hatToInsert.HatsTeamLocation,
                hatsteamname = hatToInsert.HatsTeamName,
                primarycolor = hatToInsert.PrimaryColor,
                secondarycolor = hatToInsert.SecondaryColor,
                datelastworn = hatToInsert.DateLastWorn,
                linktoimage = hatToInsert.LinkToImage

            });
        }
        public void DeleteHat(int id)
        {
            _conn.Execute("DELETE FROM Hats WHERE idHats = @id;", new { id = id });
        }

    }
}
