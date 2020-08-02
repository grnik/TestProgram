using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public enum Gender { Man, Woman }

    public class PatientBL
    {
        public Guid Id { get; set; }
        public string FIO { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        internal PatientBL(Patient Patient)
        {
            Translate(Patient);
        }

        public PatientBL()
        {
        }

        internal static List<PatientBL> Translate(List<Patient> patients)
        {
            List<PatientBL> res = new List<PatientBL>();
            foreach (Patient patient in patients)
            {
                res.Add(new PatientBL(patient));
            }

            return res;
        }

        private void Translate(Patient Patient)
        {
            Id = Patient.Id;
            FIO = Patient.FIO;
            Gender = (Gender)Patient.Gender;
            Birth = Patient.Birth;
            Address = Patient.Address;
            Phone = Patient.Phone;
        }

        public static explicit operator Patient(PatientBL Patient)
        {
            Patient res = new Patient();

            res.Id = Patient.Id;
            res.FIO = Patient.FIO;
            res.Gender = (int)Patient.Gender;
            res.Birth = Patient.Birth;
            res.Address = Patient.Address;
            res.Phone = Patient.Phone;

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Возвращает ошибку, если не удалось сохранить данные.</returns>
        public string Save()
        {
            try
            {
                if (Id == Guid.Empty)
                {
                    Id = Guid.NewGuid();
                    ((Patient)this).Add();
                }
                else
                {
                    ((Patient)this).Update();
                }
            }
            catch (Exception)
            {
                return "Что то пошло не так...";
            }

            return string.Empty;
        }

        public string Delete()
        {
            try
            {
                if (Id == Guid.Empty)
                    return string.Empty;

                ((Patient)this).Delete();
            }
            catch (Exception)
            {
                return "Что то пошло не так...";
            }

            return string.Empty;
        }

        public static List<PatientBL> GetAll()
        {
            List<PatientBL> res = new List<PatientBL>();

            List<Patient> all = Patient.GetAll();
            if ((all == null) || (all.Count <= 0))
                return res;

            return Translate(all);
        }
    }
}
