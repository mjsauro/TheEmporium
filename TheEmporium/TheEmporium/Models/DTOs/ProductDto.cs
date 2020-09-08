﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheEmporium.Models.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int ImagesId { get; set; }
        public int ProductTypeId { get; set; }

        
    }
}
