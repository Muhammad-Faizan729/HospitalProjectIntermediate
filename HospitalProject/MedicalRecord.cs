using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HospitalProject
{
    public class MedicalRecord
    {
        public int _medicalId;
        public Doctor doctor;
        public Patient patient;
        public readonly List<MedicalRecord> _medicalRecords;

        public MedicalRecord()
        {
            _medicalRecords = new List<MedicalRecord>();
        }

        public MedicalRecord(Patient p)
            : this()
        {
            this.patient = p;
        }

        public MedicalRecord(Doctor d)
            :this()
        {
            this.doctor = d;
        }
        public MedicalRecord(Doctor doctor, Patient patient)
            :this()
        {
            this.doctor = doctor;
            this.patient = patient;
        }

        public void AddMedicalRecord(MedicalRecord r)
        {
            _medicalRecords.Add(r);
            //Console.WriteLine("                     ......Patient and Doctor record was successfully entered in Medical List......                       \n");
            Console.WriteLine("                                         ......Patient assigned to doctor......                       ");
            try
            {
                string path = @"C:\Users\M Faizan Fayyaz\Desktop\File\MedicalRecord.txt";
                using (StreamWriter sw = new StreamWriter(path, append: true))
                {
                    foreach (MedicalRecord m in _medicalRecords)
                    {
                        sw.WriteLine(m.doctor.DoctorId);
                        sw.WriteLine(m.doctor.DoctorName);
                        sw.WriteLine(m.doctor.DoctorSpecialization);
                        sw.Write("\n");
                        sw.WriteLine(m.patient.PatientId);
                        sw.WriteLine(m.patient.PatientName);
                        sw.WriteLine(m.patient.PatientAge);
                        sw.WriteLine(m.patient.PatientDisease);
                    }
                    Console.WriteLine("Doctor Data Written to file successfully!..");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured!..");
            }
        }

        public void DisplayAllMedicalRecord()
        {
            foreach (MedicalRecord m in _medicalRecords)
            {
                int i = 0;

                Console.WriteLine("Record Number : " + i);
                Console.WriteLine($"ID: {m.doctor.DoctorId}, Name: {m.doctor.DoctorName}, Age: {m.doctor.DoctorSpecialization}, Patient affiliated is : PatientID: {m.patient.PatientId}, Patient Name: {m.patient.PatientName}, Patient disease: {m.patient.PatientDisease}");
                Console.WriteLine("\n");

            }
        }
    }
}
