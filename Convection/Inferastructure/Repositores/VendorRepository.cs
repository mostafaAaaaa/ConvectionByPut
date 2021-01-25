using Convection.Contexts;
using Convection.Inferastructure.IRepositores;
using Convection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.Inferastructure.Repositores
{
    public class VendorRepository : IVendorRepository
    {
        private readonly ConvectionContext _ConvectionContext;
        public VendorRepository(ConvectionContext ConvectionContext)
        {
            _ConvectionContext = ConvectionContext;
        }

        public int DeleteListTagsRepository(Tag tags)
        {
            _ConvectionContext.Tags.Remove(tags);
            return _ConvectionContext.SaveChanges();
        }

        public int DeleteVendorRepository(int id)
        {
            var vendor = _ConvectionContext.vendors.Find(id);
            _ConvectionContext.vendors.Remove(vendor);
            return _ConvectionContext.SaveChanges();
        }

        public List<Tag> GetListTagRepository()
        {
            return _ConvectionContext.Tags.ToList();

        }

        public List<Vendor> GetListVendorRepository()
        {
            return _ConvectionContext.vendors.ToList();

        }

        public List<Tag> GetTagByIdRepository(int id)
        {
            return _ConvectionContext.Tags.Where(x => x.VendorId == id).ToList();
        }

        public Vendor GetVendorByIdRepository(int id)
        {

            var entity = _ConvectionContext.Set<Vendor>().Find(id);
            _ConvectionContext.Entry(entity).State = EntityState.Detached;
            return entity;

            
        }

        public Vendor InsertVendorRepository(Vendor vendor)
        {
            _ConvectionContext.vendors.Add(vendor);
             _ConvectionContext.SaveChanges();
            return vendor;
        }

        public int UpdateVendorRepository(Vendor vendor)
        {
            _ConvectionContext.vendors.Update(vendor);
            return _ConvectionContext.SaveChanges();
        }
    }
}
