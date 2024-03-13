using Final.Models;
using System;
using System.Collections.Generic;

namespace Final
{
    public interface IShoesRepository
    {
        public IEnumerable<Shoes> GetAllShoes();
        Shoes GetShoesById(int id);
        void UpdateShoes(Shoes hats);
        public void InsertPair(Shoes pairToInsert);
        public void DeletePair(int id);
    }
}