using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Services
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set;  }
        public List<string> Messages { get; set; } = new();
    }
}
