using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    /// <summary>
    ///     Registration via social login / third party login
    /// </summary>
    public class ExternalLoginConfirmationViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }

        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}