﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_api.Models
{
    public class LoaiModels
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
