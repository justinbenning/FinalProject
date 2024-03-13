using Dapper;
using Final.Models;
using System.Data;
using System.Security.AccessControl;

namespace Final
{
    public class ShoesRepository : IShoesRepository
    {

        private readonly IDbConnection _conn;
        public ShoesRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Shoes> GetAllShoes()
        {
            return _conn.Query<Shoes>("SELECT * FROM Shoes;");
        }

        public Shoes GetShoesById(int id)
        {
            return _conn.QuerySingle<Shoes>("SELECT * FROM Shoes WHERE idShoes = @id", new { id = id });
            //select * from hats where idHats = 1 and Exists (select * from shoes where shoes.primarycolor = hats.primarycolor or shoes.secondarycolor = hats.primarycolor);
        }
        public void UpdateShoes(Shoes shoes)
        {
            _conn.Execute("UPDATE Shoes SET Brand = @brand, Model = @model, Size = @size, PrimaryColor = @primarycolor, SecondaryColor = @secondarycolor WHERE idShoes = @id",
            new { Brand = shoes.Brand, Model = shoes.Model, Size = shoes.Size, primarycolor = shoes.PrimaryColor, secondarycolor = shoes.SecondaryColor, id = shoes.idShoes });
        }


        public void InsertPair(Shoes shoeToInsert)
        {
            _conn.Execute("INSERT INTO Shoes (Brand, Model, Size, PrimaryColor, SecondaryColor) VALUES (@brand, @model, @size, @primarycolor, @secondarycolor);",
                new
                {
                    brand = shoeToInsert.Brand,
                    model = shoeToInsert.Model,
                    size = shoeToInsert.Size,
                    primarycolor = shoeToInsert.PrimaryColor,
                    secondarycolor = shoeToInsert.SecondaryColor
                });
        }
        public void DeletePair(int id)
        {
            _conn.Execute("DELETE FROM Shoes WHERE idShoes = @id;", new { id = id });
        }


    }
}

