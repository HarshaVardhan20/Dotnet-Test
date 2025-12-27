namespace Assignment1
{
    public class Program
    {
        // static PatientBill LastBill - previous last bill
        static PatientBill LastBill;
        // staitc boool HasLastBill - tells about the previous bill
        static bool HasLastBill = false;

        // Method to create a new User.
        public void RegistUser()
        {
            Console.WriteLine("Enter Bill Id: ");
            string? BillIdInput = Console.ReadLine();
            if (string.IsNullOrEmpty(BillIdInput)) {
                Console.WriteLine("Invalid BillIdInput");
                return;
            }
            Console.WriteLine("Enter Patient Name: ");
            string? PatientNameInput = Console.ReadLine();
            if (string.IsNullOrEmpty(PatientNameInput))
            {
                Console.WriteLine("Invalid Patient Name");
                return;
            }
            Console.WriteLine("Is the patient insured? (Y/N): ");
            string? PatientInsuredInput = Console.ReadLine();
            if (string.IsNullOrEmpty(PatientInsuredInput) || !(PatientInsuredInput=="Y" || PatientInsuredInput == "N"))
            {
                Console.WriteLine("Invalid option");
                return;
            }
            Console.WriteLine("Enter Consultation Fee: ");
            string? ConsultationFeeInput = Console.ReadLine();
            if((int.TryParse(ConsultationFeeInput, out int consultationFee) && consultationFee <= 0) || !(int.TryParse(ConsultationFeeInput, out int cf)))
            {
                Console.WriteLine("Enter valid consultation fee.");
                return;
            }
            Console.WriteLine("Enter Lab Charges: ");
            string? LabChargesInput = Console.ReadLine();
            if (int.TryParse(LabChargesInput, out int LabCharges) && LabCharges < 0 || !(int.TryParse(LabChargesInput, out int lc)))
            {
                Console.WriteLine("Enter valid lab charges fee.");
                return;
            }
            Console.WriteLine("Enter Medicine Charges: ");
            string? MedicalChargesInput = Console.ReadLine();
            if (int.TryParse(MedicalChargesInput, out int MedicalChargeFee) && MedicalChargeFee < 0 || !(int.TryParse(MedicalChargesInput, out int mc)))
            {
                Console.WriteLine("Enter valid Medical Charge fee.");
                return;
            }

            Console.WriteLine();
            PatientBill bill = new PatientBill(BillIdInput,PatientNameInput, (PatientInsuredInput == "Y"), consultationFee, LabCharges, MedicalChargeFee);
            LastBill = bill;
            HasLastBill = true;

            Console.WriteLine("Bill created successfully.");
            Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
            Console.WriteLine("-----------------------------------------------------------------------");
        }

        // Method to print the last Bill.
        public void PrintLastBill()
        {
            if (HasLastBill)
            {
                string HasInsurance = "";
                if (LastBill != null) {
                    if (LastBill.HasInsurance)
                    {
                        HasInsurance = "Yes";
                    }
                    else
                    {
                        HasInsurance = "No";
                    }
                }
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
            }
            else
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
            }
        }

        // Method to clear the last bill.
        public void ClearLastBill()
        {
            LastBill = null;
            HasLastBill = false;
            Console.WriteLine("Last bill cleared");
        }

        // Main Function
        public static void Main(string[] args)
        {
            bool flag = true;
            Program p = new Program();
            while (flag)
            {
                Console.WriteLine("===================== MediSure Clinic Billing ===================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");
                String? input = Console.ReadLine();
                if(int.TryParse(input, out int val))
                {
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
        }
    }
}
