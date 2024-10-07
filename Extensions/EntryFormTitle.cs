using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDapper.Extensions
{
    public enum EntryFormTitle
    {
        [Description("ប្រុស")] Male,
        [Description("ស្រី")] Female,
        [Description("បង្កើតថ្មី")]
        Create,
        [Description("កែប្រែ")]
        Edit,
        [Description("ការិយបរិច្ឆេទ")] Delete,
        
}
}
