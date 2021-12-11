using AutoMapper;
using Demo.DB.Entities.DataContext;
using Demo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public General<Model.Product.Product> Delete(int id)
        {
            var result = new General<Model.Product.Product>();

            using (var context = new DemoContext())
            {
                
                var product = context.Product.SingleOrDefault(i => i.Id == id);

                if (product is not null)
                {
                    context.Product.Remove(product);
                    context.SaveChanges();

                    result.Entity = _mapper.Map<Model.Product.Product>(product);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hata....";
                }
            }

            return result;
        }

        public General<List<Model.Product.Product>> GetAll()
        {
            var result = new General<List<Model.Product.Product>>();
            using (var context = new DemoContext())
            {
                var data = context.Product;
                if (data.Any())
                {
                    var map = _mapper.Map<List<Demo.Model.Product.Product>>(data.ToList());

                    result = new General<List<Model.Product.Product>> { Entity = map, IsSuccess=true };
                    //result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Hata....";
                }
            }
            return result;
        }


        public General<Model.Product.Product> Insert(Model.Product.Product newProduct)
        {
            var result = new General<Model.Product.Product>();
            var model = _mapper.Map<Demo.DB.Entities.Product>(newProduct);

            using (var context = new DemoContext())
            {
                
                var isAuth = context.User.Any(x => x.Id == model.Iuser &&  x.IsActive && !x.IsDeleted);
                if (isAuth)
                {
                    model.IdateTime = DateTime.Now;
                    context.Product.Add(model);
                    context.SaveChanges();

                    result.Entity = _mapper.Map<Model.Product.Product>(model);
                    result.IsSuccess = true;
                }
                else
                {
                    result.ExceptionMessage = "Ürün ekleme yetkiniz bulunmamaktadır.";
                }
            }

            return result;
        }

        public General<Model.Product.Product> Update(int id, Model.Product.Product updateProduct)
        {
            var result = new General<Model.Product.Product>();

            using (var context = new DemoContext())
            {
                
                var productUpdate = context.Product.SingleOrDefault(i => i.Id == id);

                    if (productUpdate is not null)
                    {
                        var trTimeZone = DateTime.Now;

                        productUpdate.ProductName = updateProduct.ProductName;
                        productUpdate.Price = (int)updateProduct.Price;
                        productUpdate.Stock = (int)updateProduct.Stock;

                        context.SaveChanges();

                        result.Entity = _mapper.Map<Model.Product.Product>(productUpdate);
                        result.IsSuccess = true;
                    }
                    else
                    {
                        result.ExceptionMessage = "Hata...";
                    }
            }

            return result;
        }

    }
}
