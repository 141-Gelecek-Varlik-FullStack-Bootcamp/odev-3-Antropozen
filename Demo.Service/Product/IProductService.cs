using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Product
{
    public interface IProductService
    {
        public General<List<Model.Product.Product>> GetAll();
        public General<Demo.Model.Product.Product> Insert(Demo.Model.Product.Product newProduct);
        public General<Demo.Model.Product.Product> Update(int id, Demo.Model.Product.Product updateProduct);
        public General<Demo.Model.Product.Product> Delete(int id);
    }
}
