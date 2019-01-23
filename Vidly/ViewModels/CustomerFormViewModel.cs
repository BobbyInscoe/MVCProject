using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    /// <summary>
    ///     ViewModel that contains multiple classes necessary for a new Customer to fill out. Used for New customer creation
    ///     View.
    /// </summary>
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}