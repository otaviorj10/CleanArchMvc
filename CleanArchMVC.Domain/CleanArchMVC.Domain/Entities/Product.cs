using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Product : Entity
    {
        public String Name { get; private set; }
        public String Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);

        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id Value");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }

        public void Upadate(string name, string description, decimal price, int stock, string image , int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is Requerired");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name , too short  , minimium 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid name.Name is Requerired");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid name , too short  , minimium 5 characters");

            DomainExceptionValidation.When(price < 0,
                 "Invalid price Value");

            DomainExceptionValidation.When(stock < 0,
              "Invalid stock Value");

            DomainExceptionValidation.When(image?.Length > 250,
              "Invalid image name , too long , maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image ;
        }

        
    }
}
