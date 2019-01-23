using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

        /// <summary>
        ///     1: Pay as You Go
        ///     2: Monthly
        ///     3: Quarterly
        ///     4: Annual
        /// </summary>
        public byte Id { get; set; }

        [Required] public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}