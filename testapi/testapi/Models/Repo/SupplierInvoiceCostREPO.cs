using testapi.Models;
using testapi.Models.DTO;
using testapi.Models.Mapper;

namespace testapi.Repo
{
    public interface ISupplierInvoiceCostREPO
    {
        ICollection<SupplierInvoiceCostDTOGet> GetAllSupplierInvoiceCosts();
        SupplierInvoiceCostDTOGet GetSupplierInvoiceCostById(int id);
        SupplierInvoiceCostDTOGet CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost);
        SupplierInvoiceCostDTOGet UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost);
        SupplierInvoiceCostDTOGet DeleteSupplierInvoiceCost(int id);


    }
    public class SupplierInvoiceCostREPO : ISupplierInvoiceCostREPO
    {
        private readonly Progetto_FormativoContext _context;
        public SupplierInvoiceCostREPO(Progetto_FormativoContext ctx)
        {
            _context = ctx;
        }

        public SupplierInvoiceCostDTOGet CreateSupplierInvoiceCost(SupplierInvoiceCost supplierInvoiceCost)
        {
            SupplierInvoice si;
            if (supplierInvoiceCost == null)
                throw new ArgumentNullException("Couldn't create supplier Invoice Cost");
            if (!_context.SupplierInvoices.Where(x => x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId).Any())
                throw new ArgumentException("Supplier Invoice Id not found!");
            if (supplierInvoiceCost.SupplierInvoiceId == null)
                throw new ArgumentException("Supplier Invoice Id can't be null!");
            if (supplierInvoiceCost.Cost<0 || supplierInvoiceCost.Quantity<1 || supplierInvoiceCost.Cost == null || supplierInvoiceCost.Quantity == null)
                throw new ArgumentException("Values can't be lesser than 1 or null");

            si =_context.SupplierInvoices.Where(x=>x.InvoiceId == supplierInvoiceCost.SupplierInvoiceId).First();

            decimal? total=_context.SupplierInvoiceCosts.Where(x=>x.SupplierInvoiceId== supplierInvoiceCost.SupplierInvoiceId).Sum(x=>x.Cost*x.Quantity);

            si.InvoiceAmount=total+ supplierInvoiceCost.Cost* supplierInvoiceCost.Quantity;
            _context.SupplierInvoices.Update(si);
            _context.Add(supplierInvoiceCost);
            _context.SaveChanges();
            return SupplierInvoiceCostMapper.MapGet(supplierInvoiceCost);
        }


        public SupplierInvoiceCostDTOGet DeleteSupplierInvoiceCost(int id)
        {
            var data = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefault();
            if (data == null || id < 1)
            {
                throw new ArgumentNullException("Supplier Invoice Cost not found!");
            }
            SupplierInvoice si= _context.SupplierInvoices.Where(x => x.InvoiceId == data.SupplierInvoiceId).First();
            decimal? total = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == data.SupplierInvoiceId).Sum(x => x.Cost * x.Quantity);
            si.InvoiceAmount = total - data.Cost * data.Quantity;
            _context.SupplierInvoiceCosts.Remove(data);
            _context.SaveChanges();
            return SupplierInvoiceCostMapper.MapGet(data);

        }

        public ICollection<SupplierInvoiceCostDTOGet> GetAllSupplierInvoiceCosts()
        {
            return _context.SupplierInvoiceCosts.Select(x=> SupplierInvoiceCostMapper.MapGet(x)).ToList();
        }

        public SupplierInvoiceCostDTOGet GetSupplierInvoiceCostById(int id)
        {
            var data = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefault();
            if (data == null)
            {
                throw new ArgumentException("SupplierInvoiceCost not found!");
            }
            return SupplierInvoiceCostMapper.MapGet(data);
        }

        public SupplierInvoiceCostDTOGet UpdateSupplierInvoiceCost(int id, SupplierInvoiceCost supplierInvoiceCost)
        {
            var sicDB = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceCostsId == id).FirstOrDefault();
            if (sicDB != null && id >=0)
            {
                if (supplierInvoiceCost.SupplierInvoiceId != null && supplierInvoiceCost.SupplierInvoiceId >= 1)
                {
                    sicDB.SupplierInvoiceId = supplierInvoiceCost.SupplierInvoiceId;
                }
                sicDB.Quantity = supplierInvoiceCost.Quantity ?? sicDB.Quantity;
                sicDB.Cost = supplierInvoiceCost.Cost ?? sicDB.Cost;
                _context.SupplierInvoiceCosts.Update(sicDB);
                _context.SaveChanges();
               if(sicDB.Cost > 0 && sicDB.Quantity > 0)
                {
                SupplierInvoice si = _context.SupplierInvoices.Where(x => x.SupplierId == sicDB.SupplierInvoiceId).First();
                decimal? total = _context.SupplierInvoiceCosts.Where(x => x.SupplierInvoiceId == sicDB.SupplierInvoiceId).Sum(x => x.Cost * x.Quantity);
                si.InvoiceAmount = total;
                _context.SupplierInvoices.Update(si);
                _context.SaveChanges();
                }
                return SupplierInvoiceCostMapper.MapGet(sicDB);
            }
            throw new ArgumentNullException("Supplier Invoice or Supplier Invoice Cost not found");
        }
    }
}
