using Final.Models;
using System;
using System.Collections.Generic;

namespace Final
{
    public interface IHatRepository
    {
        public IEnumerable<Hats> GetAllHats();
        Hats GetHatsById(int id);
        void UpdateHats(Hats hats);
        public void InsertHat(Hats hatToInsert);
        public void DeleteHat(int id);
    }
}
