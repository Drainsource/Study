using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkSQL.Models
{
    public class FullContactModel
    {
        public PersonModel person { get; set; } = new();
        public List<AddressModel> addresses { get; set; } = new();
    }
}
