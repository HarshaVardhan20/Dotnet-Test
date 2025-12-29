using System;

namespace Assignment1
{
    /// <summary>
    /// Program class - provides a minimal console UI to create, view and clear a PatientBill.
    /// </summary>
    public class Program
    {
        #region Fields

        /// Holds the previously created bill (last bill). Null when no bill exists.
        static PatientBill LastBill;

        /// Indicates whether a last bill currently exists.
        static bool HasLastBill = false;

        #endregion


        /// <summary>
        /// Prompts the user for patient and billing inputs, validates them, creates a PatientBill and stores it as the last bill.
        /// </summary>
        public void RegistUser()
        {
            #region Taking input - Bill Id
            Console.WriteLine("Enter Bill Id: ");
            string? BillIdInput = Console.ReadLine(); // BillIdInput: raw input for bill identifier
            if (string.IsNullOrEmpty(BillIdInput))
            {
                Console.WriteLine("Invalid BillIdInput");
                return;
            }
            #endregion

            #region Taking input - Patient Name
            Console.WriteLine("Enter Patient Name: ");
            string? PatientNameInput = Console.ReadLine(); // PatientNameInput: raw input for patient name
            if (string.IsNullOrEmpty(PatientNameInput))
            {
                Console.WriteLine("Invalid Patient Name");
                return;
            }
            #endregion

            #region Taking input - Insurance flag
            Console.WriteLine("Is the patient insured? (Y/N): ");
            string? PatientInsuredInput = Console.ReadLine(); // PatientInsuredInput: "Y"/"N" input indicating insurance status
            if (string.IsNullOrEmpty(PatientInsuredInput) || !(PatientInsuredInput == "Y" || PatientInsuredInput == "N"))
            {
                Console.WriteLine("Invalid option");
                return;
            }
            #endregion

            #region Taking input - Consultation Fee
            Console.WriteLine("Enter Consultation Fee: ");
            string? ConsultationFeeInput = Console.ReadLine(); // ConsultationFeeInput: raw input for consultation fee

            if ((int.TryParse(ConsultationFeeInput, out int consultationFee) && consultationFee <= 0) || !(int.TryParse(ConsultationFeeInput, out int cf)))
            {
                // consultationFee: parsed consultation fee (used below when creating the bill)
                // cf: parsing helper variable used in the conditional expression
                Console.WriteLine("Enter valid consultation fee.");
                return;
            }
            #endregion

            #region Taking input - Lab Charges
            Console.WriteLine("Enter Lab Charges: ");
            string? LabChargesInput = Console.ReadLine(); // LabChargesInput: raw input for lab charges

            if (int.TryParse(LabChargesInput, out int LabCharges) && LabCharges < 0 || !(int.TryParse(LabChargesInput, out int lc)))
            {
                // LabCharges: parsed integer value for lab charges (used when creating the bill)
                // lc: parsing helper variable used in the conditional expression
                Console.WriteLine("Enter valid lab charges fee.");
                return;
            }
            #endregion

            #region Taking input - Medicine Charges
            Console.WriteLine("Enter Medicine Charges: ");
            string? MedicalChargesInput = Console.ReadLine(); // MedicalChargesInput: raw input for medicine charges

            if (int.TryParse(MedicalChargesInput, out int MedicalChargeFee) && MedicalChargeFee < 0 || !(int.TryParse(MedicalChargesInput, out int mc)))
            {
                // MedicalChargeFee: parsed integer value for medicine charges (used when creating the bill)
                // mc: parsing helper variable used in the conditional expression
                Console.WriteLine("Enter valid Medical Charge fee.");
                return;
            }
            #endregion

            #region Bill creation and storage
            Console.WriteLine();

            // Create a new PatientBill using the validated inputs:
            PatientBill bill = new PatientBill(BillIdInput, PatientNameInput, (PatientInsuredInput == "Y"), consultationFee, LabCharges, MedicalChargeFee);
            // bill: newly created PatientBill instance containing calculated fields (GrossAmount, DiscountAmount, FinalPayable)

            LastBill = bill; // LastBill: static field holding the latest created bill
            HasLastBill = true; // HasLastBill: set to true to indicate a bill exists

            // Output summary information
            Console.WriteLine("Bill created successfully.");
            Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
            Console.WriteLine("-----------------------------------------------------------------------");
            #endregion
        }

        /// <summary>
        /// Prints the details of the last created bill to the console.
        /// </summary>
        public void PrintLastBill()
        {
            #region Check availability
            if (HasLastBill)
            {
                string HasInsurance = ""; // HasInsurance: local string for printing whether the patient is insured

                if (LastBill != null)
                {
                    if (LastBill.HasInsurance)
                    {
                        HasInsurance = "Yes";
                    }
                    else
                    {
                        HasInsurance = "No";
                    }
                }
                #endregion

                #region Display bill details
                Console.WriteLine();
                Console.WriteLine("-------- Last Bill --------");
                Console.WriteLine($"BillId: {LastBill.BillId}");
                Console.WriteLine($"Patient: {LastBill.PatientName}");
                Console.WriteLine($"Insured: {HasInsurance}");
                Console.WriteLine($"Consultation Fee: {(LastBill.ConsultationFee):F2}");
                Console.WriteLine($"Lab Charges: {(LastBill.LabCharges):F2}");
                Console.WriteLine($"Medicine Charges: {(LastBill.MedicineCharges):F2}");
                Console.WriteLine($"Gross Amount: {(LastBill.GrossAmount):F2}");
                Console.WriteLine($"Discount Amount: {(LastBill.DiscountAmount):F2}");
                Console.WriteLine($"Final Payable: {(LastBill.FinalPayable):F2}");
                Console.WriteLine($"-----------------------------");
                Console.WriteLine($"--------------------------------------------------------");
                #endregion
            }
            else
            {
                // Inform the user that no bill is available
                Console.WriteLine("No bill available. Please create a new bill first.");
            }
        }

        /// <summary>
        /// Clears the stored last bill.
        /// </summary>
        public void ClearLastBill()
        {
            LastBill = null; // Clear stored last bill reference
            HasLastBill = false; // Mark that no last bill exists
            Console.WriteLine("Last bill cleared");
        }

        /// <summary>
        /// Application entry point. Presents a simple menu loop to the user.
        /// </summary>
        /// <param name="args">Command line arguments (unused).</param>
        public static void Main(string[] args)
        {
            #region Menu loop initialization
            bool flag = true; // flag: controls the menu loop
            Program p = new Program(); // p: instance used to call instance methods from static Main
            #endregion

            #region Menu loop
            while (flag)
            {
                Console.WriteLine("===================== MediSure Clinic Billing ===================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                String? input = Console.ReadLine(); // input: raw user input for menu selection
                if (int.TryParse(input, out int val))
                {
                    // val: parsed integer menu selection
                    switch (val)
                    {
                        case 1:
                            p.RegistUser();
                            break;
                        case 2:
                            p.PrintLastBill();
                            break;
                        case 3:
                            p.ClearLastBill();
                            break;
                        case 4:
                            Console.WriteLine("Thank you. Application closed normally.");
                            flag = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct value.");
                }
            }
            #endregion
        }

    }
}
