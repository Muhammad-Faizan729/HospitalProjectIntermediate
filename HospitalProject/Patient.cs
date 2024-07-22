using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject
{
    public class Patient
    {
        private int _patientId;
        private string _patientName;
        private int _patientAge;
        private string _patientDisease;
        public readonly List<Patient> patients;

        public int PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }
        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }
        public int PatientAge
        {
            get { return _patientAge; }
            set { _patientAge = value; }
        }

        public string PatientDisease
        {
            get { return _patientDisease; }
            set { _patientDisease = value; }
        }

        public Patient()
        {
            patients = new List<Patient>();
        }

        public Patient(int id, string name, int age, string disease)
            :this()
        {
            this._patientId = id;
            this._patientName = name;
            this._patientAge = age;
            this._patientDisease = disease;
        }

        public Patient AddPatient()
        {
            Console.WriteLine("                     ......Adding Patient......                      ");
            int id = 0;
            bool patientIdExist = true;
            while (patientIdExist)
            {
                Console.WriteLine("Enter Patient Id : ");
                int iid = Convert.ToInt32(Console.ReadLine());
                patientIdExist = false;
                foreach (Patient p in patients)
                {
                    if (p.PatientId == iid)
                    {
                        Console.WriteLine("Patient already exist. Enter new Id.");
                        patientIdExist = true;
                    }
                }
                if (!patientIdExist)
                {
                    id = iid;
                }
               
            }

            Console.WriteLine("Enter Patient Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Patient Age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Patient Desiese : \n Press 1 : Heart \n Press 2 : Cancer \n Press 3 : Diabetes \n Press 4 : Diarrhea");
            string disease = Console.ReadLine();

            switch (disease)
            {
                case "1":
                    Console.WriteLine("Heart Disease Selected! \n");
                    disease = "Heart Problem";
                    break;
                case "2":
                    Console.WriteLine("Cancer Disease Selected!");
                    disease = "Cancer Problem";
                    break;
                case "3":
                    Console.WriteLine("Diabetes Disease Selected!");
                    disease = "Diabetes Problem";
                    break;
                case "4":
                    Console.WriteLine("Diarrhea Disease Selected!");
                    disease = "Diarrhea Problem";
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }

            Patient patient = new Patient(id,name,age,disease);
            patients.Add(patient);
            Console.WriteLine("======Patient Added Successfully!======");
            try
            {
                string path = @"C:\Users\M Faizan Fayyaz\Desktop\File\patient.txt";
                using (StreamWriter sw = new StreamWriter(path, append: true))
                {
                    foreach (Patient i in patients)
                    {
                        sw.WriteLine(i.PatientId);
                        sw.WriteLine(i.PatientName);
                        sw.WriteLine(i.PatientAge);
                        sw.WriteLine(i.PatientDisease);
                        Console.WriteLine("\n");
                    }
                    Console.WriteLine("Patient Data Written to file successfully!..");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured!..");
            }
            return patient;
        }

        public void DeletePatient()
        {
            bool PatientFound = false;
            Console.WriteLine("                     ......Deleting Patient......                        ");
            Console.WriteLine("Enter Patient Medical Id that you want to delete : ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (patients.Count <= 0)
            {
                Console.WriteLine("List is empty!.");
            }
            foreach (Patient p in patients)
            {
                if(p.PatientId == id)
                {
                    PatientFound = true;
                    patients.Remove(p);
                    Console.WriteLine($"Patient with ID : {p.PatientId}, has been deleted successfully");
                }
                break;
            }
            if (!PatientFound)
            {
                Console.WriteLine("Patient not found!..\n");
            }
            
        }

        public void DisplayPatient()
        {
            if (patients.Count <= 0)
            {
                Console.WriteLine("List is empty!.No patient exist.");
            }
            else
            {
                foreach (Patient p in patients)
                {
                    Console.WriteLine($"ID: {p.PatientId}, Name: {p.PatientName}, Age: {p.PatientAge}, Disease: {p.PatientDisease}");
                }
            }
        }

        public Patient UpdatePatient()
        {
            Console.WriteLine("Enter Patient Id that you want to Update ");
            int Id = Convert.ToInt32(Console.ReadLine());

            bool PatientFound = false;

            if (patients.Count <= 0)
            {
                Console.WriteLine("List is empty!.");
                return null;
            }
            foreach (Patient p in patients)
            {
                if(p.PatientId == Id)
                {
                    PatientFound = true;

                    Console.WriteLine("Enter New Patient Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter New Patient Age : ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter New Patient Disease : ");
                    string disease = Console.ReadLine();

                    p.PatientName = name;
                    p.PatientAge = age;
                    p.PatientDisease = disease;

                    Console.WriteLine("======Patient Updated Successfully!======");

                    return p;
                }
            }
            if (!PatientFound)
            {
                Console.WriteLine("Patient Not Found!..");
                return null;
            }
            return null;
        }
    }
}
