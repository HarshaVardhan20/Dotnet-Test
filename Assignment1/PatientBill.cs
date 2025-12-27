using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    // PatientBill Class - Base PatientBill class
    public class PatientBill
    {
        public string BillId { get; set; }
        public string PatientName { get; set; }

        public bool HasInsurance { get; set; }
        public decimal ConsultationFee { get; set; }

        public decimal LabCharges { get; set; }

        public decimal MedicineCharges { get; set; }
        public decimal GrossAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal FinalPayable { get; set; }
        
        // PatientBill Constructor
        public PatientBill(string BillId, string PatientName, bool HasInsurance, decimal ConsultationFee, decimal LabCharges, decimal MedicalCharges)
        {
            this.BillId = BillId;
            this.PatientName = PatientName;
            this.HasInsurance = HasInsurance;
            this.ConsultationFee = ConsultationFee;
            this.LabCharges= LabCharges;
            this.MedicineCharges= MedicalCharges;

            decimal gross = ConsultationFee + LabCharges + MedicalCharges;
            this.GrossAmount = gross;
            this.DiscountAmount = 0;
            if(HasInsurance){
                this.DiscountAmount = gross/10;
            }
            this.FinalPayable = this.GrossAmount - this.DiscountAmount;
        }

    }

}
