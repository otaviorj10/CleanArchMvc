﻿using CleanArchMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Entities
{
    public sealed class Category : Entity
    {
        public String Name { get; private set; }
        public ICollection<Product> Products { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);

        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is Requerired");

            DomainExceptionValidation.When(name.Length <3,
                "Invalid name , too short  , minimium 3 characters");

            Name = name;
        }
    }
}
