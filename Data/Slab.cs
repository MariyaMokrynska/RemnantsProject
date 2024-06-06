using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RemnantsProject.Data
{
    public enum SoldState
    {
        AVAILABLE,
        SOLD,
        PICKEDUP
    }
    public class Slab
    {
        [Key]
        public int SlabId { get; set; }
        //link to table
        [Display(Name = "Manufacturer Name")]
        public int ManufacturerId { get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }
        [Display(Name = "Colour")]
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Colour? Colour { get; set; }
        [Display(Name = "Batch number")]
        public String BatchNumber { get; set; }
        [Display(Name = "Surface Type")]
        public int SurfaceTypeId { get; set; }
        [ForeignKey("SurfaceTypeId")]
        [Display(Name = "Surface type")]
        public SurfaceType? SurfaceType { get; set; }
        [Range(10, 130)]
        public int Length { get; set; }
        [Range(10, 80)]
        public int Width { get; set; }
        [Range(2, 3)]
        [Display(Name = "Thickness (in cm)")]
        public int Thickness { get; set; }
        [Range(200, 1500)]
        public int Price { get; set; }
        [NotMapped]
        public SoldState State
        {
            get
            {
                if (SlabPickedUpDate != null)
                {
                    return SoldState.PICKEDUP;
                }
                else if (!String.IsNullOrEmpty(PayConfirmationNumber))
                {
                    return SoldState.SOLD;
                }
                else
                {
                    return SoldState.AVAILABLE;
                }
            }
        }
        [Display(Name = "Date Hold Is Due")]
        public DateTime? HoldDueDate { get; set; }
        [Display(Name = "Customer Name With Hold")]
        public String? HoldCustomerName { get; set; }
        [Display(Name = "Customer Id With Hold")]
        public int? HoldCustomerId { get; set; }
        [NotMapped]
        [Display(Name = "Slab in hold")]
        public bool InHold
        {
            get
            {
                return !String.IsNullOrEmpty(HoldCustomerName)
                    && HoldDueDate != null && HoldDueDate > DateTime.Today;

            }
        }
        [Display(Name = "Payment Confirmation Number")]
        public String? PayConfirmationNumber { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public int? EmployeeIdReceivedPayment { get; set; }
        [Display(Name = "Date slab was picked up")]
        public DateTime? SlabPickedUpDate { get; set; }
        public int? EmployeeIdDeliveringSlab { get; set; }


    }
}
