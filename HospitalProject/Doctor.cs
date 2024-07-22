using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject
{
    public class Doctor
    {
        private int _doctorId;
        private string _doctorName;
        private string _doctorSpecialization;
        private int patientId ;

        public static readonly List<Doctor> doctors = new List<Doctor>();
        public int DoctorId
        {
            get { return _doctorId; } 
        }
        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }
        public string DoctorSpecialization
        {
            get { return _doctorSpecialization; }
            set { _doctorSpecialization = value; }
        }

        public Doctor()
        {
           
        }

        public Doctor(int patientId,int id, string name, string specialization)
            :this()
        {
            this.patientId = patientId;
            this._doctorId = id;
            this._doctorName = name;
            this._doctorSpecialization = specialization;
        }

        public (Doctor doctor, Patient patient) AddDoctor(Patient patient)
        {
            int patientId;
            int id;
            string name;
            string specialization;

            if (patient.patients.Count <= 0)
            {
                Console.WriteLine("There are no patients in the list, please add a patient first");
                return (null,null);
            }

            Console.WriteLine("                     ......Adding Doctor......                       ");
            Console.WriteLine("Please Enter patient ID to which you are assigned: ");
            patientId = Convert.ToInt32(Console.ReadLine());

            bool patientFound = false;

            foreach (Patient a in patient.patients)
            {
                if (a.PatientId == patientId)
                {
                    patientFound = true;
                    Console.WriteLine("Patient exists!....\n");
                    Console.WriteLine("Enter Doctor ID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Doctor Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter Doctor Specialization : \n Press 1 : Surgery Expert \n Press 2 : Neurology \n Press 3 : Pathology \n Press 4 : Emergency Medicine");
                    specialization = Console.ReadLine();

                    switch (specialization)
                    {
                        case "1":
                            Console.WriteLine("Surgery Expert Selected! \n");
                            specialization = "Surgery Expert";
                            break;
                        case "2":
                            Console.WriteLine("Neurology Selected!");
                            specialization = "Neurology";
                            break;
                        case "3":
                            Console.WriteLine("Pathology Selected!");
                            specialization = "Pathology";
                            break;
                        case "4":
                            Console.WriteLine("Emergency Medicine Selected!");
                            specialization = "Emergency Medicine";
                            break;
                        default:
                            Console.WriteLine("Invalid Input!");
                            break;
                    }
                    Doctor doctor = new Doctor(patientId, id, name, specialization);
                    doctors.Add(doctor);

                    Console.WriteLine("Doctor Added Successfully!..");

                    try
                    {
                        string path = @"C:\Users\M Faizan Fayyaz\Desktop\File\doctor.txt";
                        using (StreamWriter sw = new StreamWriter(path, append: true))
                        {
                            foreach (Doctor d in doctors)
                            {
                                sw.WriteLine(d.DoctorId);
                                sw.WriteLine(d.DoctorName);
                                sw.WriteLine(d.DoctorSpecialization);
                            }
                            Console.WriteLine("Doctor Data Written to file successfully!..");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured!..");
                    }

                    return (doctor,a);
                }
            }

            if (!patientFound)
            {
                Console.WriteLine("Patient does not exist by the entered ID.");
            }
            return (null,null);
        }

        public void DisplayAllDoctor()
        {
            if(doctors.Count <= 0)
            {
                Console.WriteLine("List is empty!..No doctor exist..");
            }
            else
            {
                foreach (Doctor d in doctors)
                {
                    Console.WriteLine($"ID: {d.DoctorId}, Name: {d.DoctorName}, Specialization: {d.DoctorSpecialization}, Patient Linked Id: {d.patientId}");
                }
            }
        }

        public void DeleteDoctor()
        {
            bool DoctorFound = false;
            Console.WriteLine("                     ......Deleting Doctor......                        ");
            Console.WriteLine("Enter Doctor Medical Id that you want to delete : ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (doctors.Count <= 0)
            {
                Console.WriteLine("List is empty!.");
            }
            foreach (Doctor d in doctors)
            {
                if (d.DoctorId == id)
                {
                    DoctorFound = true;
                    doctors.Remove(d);
                    Console.WriteLine($"Doctor with ID : {d.DoctorId}, has been deleted successfully");
                }
                break;
            }
            if (!DoctorFound)
            {
                Console.WriteLine("Doctor not found!..\n");
            }
        }

        public Doctor UpdateDoctor()
        {
            Console.WriteLine("Enter Doctor Id that you want to Update ");
            int Id = Convert.ToInt32(Console.ReadLine());

            bool DoctorFound = false;

            if (doctors.Count <= 0)
            {
                Console.WriteLine("List is empty!.");
                return null;
            }
            foreach (Doctor d in doctors)
            {
                if (d.DoctorId == Id)
                {
                    DoctorFound = true;

                    Console.WriteLine("Enter New Doctor Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter New Doctor Specialization : ");
                    string specialization = Console.ReadLine();

                    d.DoctorName = name;
                    d.DoctorSpecialization = specialization;

                    Console.WriteLine("======Doctor Updated Successfully!======");
                    return d;
                }
            }
            if (!DoctorFound)
            {
                Console.WriteLine("Doctor Not Found!..");
                return null;
            }
            return null;
        }
    }
}
