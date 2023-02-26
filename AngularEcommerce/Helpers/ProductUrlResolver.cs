﻿using AngularEcommerce.Dto;
using AngularEcommerce.Entity;
using AutoMapper;
using AutoMapper.Execution;

namespace AngularEcommerce.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)) 
            { 
               return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;

        }
    }
}
