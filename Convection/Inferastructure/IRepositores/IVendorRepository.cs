using Convection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.Inferastructure.IRepositores
{
    public interface IVendorRepository
    {
        List<Tag> GetListTagRepository();

        List<Tag> GetTagByIdRepository(int id);

        List<Vendor> GetListVendorRepository();

        Vendor GetVendorByIdRepository(int id);

        Vendor InsertVendorRepository(Vendor vendor);
        int DeleteVendorRepository(int id);
        int DeleteListTagsRepository(Tag tags);

        int UpdateVendorRepository(Vendor vendor);
    }
}
