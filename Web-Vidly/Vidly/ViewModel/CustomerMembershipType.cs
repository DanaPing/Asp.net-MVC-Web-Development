using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomerMembershipType
    {
        public Customer Customer { get; set; }
       
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}