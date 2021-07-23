using ShopProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProj.Models.Interfaces
{
    public interface IFilmsCategory
    {
        IEnumerable<Genre> AllGenres { get; }
    }
}
