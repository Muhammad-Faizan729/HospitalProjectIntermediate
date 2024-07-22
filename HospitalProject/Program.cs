using System;

namespace HospitalProject{
    public class Program
    {
        static void Main(string[] args)
        {
            Patient patient = new Patient();
            MedicalRecord record = new MedicalRecord();
            Doctor doctor = new Doctor();
            bool NoExit = true;
            while (NoExit)
            {
                Console.WriteLine("\n Press 1 : Add New Patient. \n Press 2 : Add New Doctor. \n Press 3 : Display ALl Patients. \n Press 4 : Display All Doctors. \n Press 5 : Display All Medical Reocord. \n Press 6 : Delete Patient. \n Press 7 : Update Patient \n Press 8 :  Delete Doctor \n Press 9 : Update Doctor \n Press 10 : Exit." );
                int UserInput = Convert.ToInt32(Console.ReadLine());
                switch (UserInput)
                {
                    case 1:
                        var p = patient.AddPatient();
                        break;
                    case 2:
                        var DoctorPatient = doctor.AddDoctor(patient);
                        if (DoctorPatient.doctor != null && DoctorPatient.patient != null)
                        {
                            var DoctorPatientRecord = new MedicalRecord(DoctorPatient.doctor, DoctorPatient.patient);
                            record.AddMedicalRecord(DoctorPatientRecord);
                        }
                        break;
                    case 3:
                        patient.DisplayPatient();
                        break;
                    case 4:
                        doctor.DisplayAllDoctor();
                        break;
                    case 5:
                        record.DisplayAllMedicalRecord();
                        break;
                    case 6:
                        patient.DeletePatient();
                        break;
                    case 7:
                        patient.UpdatePatient();
                        break;
                    case 8:
                        doctor.DeleteDoctor();
                        break;
                    case 9:
                        doctor.UpdateDoctor();
                        break;
                    case 10:
                        NoExit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
           
        }
    }
}