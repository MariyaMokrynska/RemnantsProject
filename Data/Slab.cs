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
        public int ManufacturerId {  get; set; }
        [ForeignKey("ManufacturerId")]
        public Manufacturer? Manufacturer { get; set; }
        [Display(Name = "Colour")]
        public int ColorId {  get; set; }
        [ForeignKey("ColorId")]
        public Colour? Colour { get; set; }
        [Display(Name = "Batch number")]
        public String BatchNumber { get; set; }
        public int SurfaceTypeId { get; set; }
        [ForeignKey("SurfaceTypeId")]
        [Display(Name = "Surface type")]
        public SurfaceType? SurfaceType { get; set; }
        [Range(10, 130)]
        public int Length {  get; set; }
        [Range(10, 80)]
        public int Width { get; set; }
        [Range(2, 3)]
        public int Thickness { get; set; }
        [Range(200, 1500)]
        public int Price { get; set; }
        [NotMapped]
        public SoldState State 
        { 
            get {
                if (SlabPickedUpDate != null)
                {
                    return SoldState.PICKEDUP;
                }else if (!String.IsNullOrEmpty(PayConfirmationNumber))
                {
                    return SoldState.SOLD;
                }
                else
                {
                    return SoldState.AVAILABLE;
                }
            }  
        }

        public DateTime? HoldDueDate { get; set; }
        public String? HoldCustomerName { get; set; }
        public int? HoldCustomerId { get; set; }
        [NotMapped]
        public bool InHold {
            get {
                return !String.IsNullOrEmpty(HoldCustomerName)
                    && HoldDueDate != null && HoldDueDate > DateTime.Today;

            } }
        public String? PayConfirmationNumber { get; set; }
        public DateTime? DateOfPayment { get; set; }
        public int? EmployeeIdReceivedPayment { get; set; }
        public DateTime? SlabPickedUpDate { get; set; }
        public int? EmployeeIdDeliveringSlab { get; set; }


    }
}
