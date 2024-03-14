using Dapper;
using Final.Models;
using System.Data;
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
            //SELECT hats.*, shoes.* FROM hats JOIN shoes ON shoes.primarycolor = hats.primarycolor OR shoes.secondarycolor = hats.primarycolor where hats.idHats = @id , new {id = id};
        }
        public void UpdateHats(Hats hats)
        {
            _conn.Execute("UPDATE Hats SET HatsTeamLocation = @location, HatsTeamName = @name, PrimaryColor = @primarycolor, SecondaryColor = @secondarycolor WHERE idHats = @id",
            new { location = hats.HatsTeamLocation, name = hats.HatsTeamName, primarycolor = hats.PrimaryColor, secondarycolor = hats.SecondaryColor, id = hats.idHats });
        }
        
        
        public void InsertHat(Hats hatToInsert)
        {
            _conn.Execute("INSERT INTO Hats (HatsTeamLocation, HatsTeamName, PrimaryColor, SecondaryColor) VALUES (@hatsteamlocation, @hatsteamname, @primarycolor, @secondarycolor);",
                new { hatsteamlocation = hatToInsert.HatsTeamLocation, hatsteamname = hatToInsert.HatsTeamName, primarycolor = hatToInsert.PrimaryColor,
                    secondarycolor = hatToInsert.SecondaryColor });
        }
        public void DeleteHat(int id)
        {
            _conn.Execute("DELETE FROM Hats WHERE idHats = @id;", new {id = id});
        }

    
    }
}
