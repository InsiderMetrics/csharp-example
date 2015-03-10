using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InsiderMetrics.Docs.CodeExample.CSharp.Models
{
    public class Respondent : IModel
    {
        public Respondent()
		{
			KeyValues = new Dictionary<string, string>();
		}
		
		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string PhoneNumber { get; set; }

		[DataMember]
		public Guid Campaign_UniqueID { get; set; }

		[DataMember]
		public Guid Language_UniqueID { get; set; }

		[DataMember]
		public Guid UniqueID { get; set; }

		[DataMember]
		public Dictionary<string, string> KeyValues { get; set; }
		
		[DataMember]
		public bool? HasbeenEnabled { get; set; }
    }
}
