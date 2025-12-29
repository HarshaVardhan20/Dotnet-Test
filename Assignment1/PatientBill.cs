
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    /// <summary>
    /// PatientBill Class - Base PatientBill class representing a patient's billing details.
    /// </summary>
    public class PatientBill
    {
        #region Properties

        /// Gets or sets the bill identifier.
        public string BillId { get; set; }

        /// Gets or sets the patient's full name.
        public string PatientName { get; set; }

        /// Gets or sets a value indicating whether the patient has insurance.
        public bool HasInsurance { get; set; }

        /// Gets or sets the consultation fee amount.
        public decimal ConsultationFee { get; set; }

        /// Gets or sets the total lab charges.
        public decimal LabCharges { get; set; }

        /// Gets or sets the total medicine charges.
        public decimal MedicineCharges { get; set; }

        /// Gets or sets the gross amount (sum of fees and charges).
        public decimal GrossAmount { get; set; }

        /// Gets or sets the discount amount applied (for example, insurance discount).
        public decimal DiscountAmount { get; set; }

        /// Gets or sets the final payable amount after discounts.
        public decimal FinalPayable { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the PatientBill class.
        /// </summary>
        public PatientBill(string BillId, string PatientName, bool HasInsurance, decimal ConsultationFee, decimal LabCharges, decimal MedicalCharges)
        {
            #region Input assignments
            // Input: BillId -> assign to BillId property (unique bill identifier)
            this.BillId = BillId;

            // Input: PatientName -> assign to PatientName property (full patient name)
            this.PatientName = PatientName;

            // Input: HasInsurance -> assign to HasInsurance property (indicates insurance coverage)
            this.HasInsurance = HasInsurance;

            // Input: ConsultationFee -> assign to ConsultationFee property (fee for consultation)
            this.ConsultationFee = ConsultationFee;

            // Input: LabCharges -> assign to LabCharges property (total lab tests/charges)
            this.LabCharges = LabCharges;

            // Input: MedicalCharges -> assign to MedicineCharges property (total medicine cost)
            this.MedicineCharges = MedicalCharges;
            #endregion

            #region Calculations and derived values
            // Variable: gross -> temporary variable holding the sum of all charge components
            decimal gross = ConsultationFee + LabCharges + MedicalCharges;

            // Assign gross sum to GrossAmount property (total before discounts)
            this.GrossAmount = gross;

            // Initialize DiscountAmount to zero (no discount by default)
            this.DiscountAmount = 0;

            // If patient has insurance, apply a discount of 10% of gross
            if (HasInsurance)
            {
                // DiscountAmount = 10% of gross
                this.DiscountAmount = gross / 10;
            }

            // FinalPayable is gross minus any discount applied
            this.FinalPayable = this.GrossAmount - this.DiscountAmount;
            #endregion
        }

        #endregion

    }

}