using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsiderMetrics.Docs.CodeExample.CSharp.Models
{
    public interface IModel
    {
        Guid UniqueID { get; set; }
    }
}
