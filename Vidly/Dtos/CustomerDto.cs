using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    /// <summary>
    ///     Used to pass raw data to calls from the API
    ///     This is used as Data Transfer Objects for our CustomerController API. This is used to prevent security risks when
    ///     malicious users would attempt to pass data directly to our database.
    ///     DTOs are used to control what properties are passed to the internal controller methods and allows us to fine tune
    ///     what properties in the entity model can be updated.
    ///     This is also used to simplify a model that is provided to the view.
    /// </summary>
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required] [StringLength(255)] public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        /// <summary>
        ///     Min18YearsIfAMember may need to be removed to prevent a runtime exception for casting to Customer
        /// </summary>
        public DateTime? Birthday { get; set; }
    }
}