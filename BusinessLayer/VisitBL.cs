using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class VisitBL
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }

        public PatientBL Patient { get; set; }

        public VisitTypeBL VisitType { get; set; }

        internal VisitBL(Visit Visit)
        {
            Translate(Visit);
        }

        public VisitBL()
        {
        }

        internal static List<VisitBL> Translate(List<Visit> visits)
        {
            List<VisitBL> res = new List<VisitBL>();
            foreach (Visit visit in visits)
            {
                res.Add(new VisitBL(visit));
            }

            return res;
        }

        private void Translate(Visit visit)
        {
            Id = visit.Id;
            Date = visit.Date;
            Diagnosis = visit.Diagnosis;
            Patient = new PatientBL(visit.Patient);
            VisitType = new VisitTypeBL(visit.VisitType);
        }

        public static explicit operator Visit(VisitBL visit)
        {
            Visit res = new Visit();

            res.Id = visit.Id;
            res.Date = visit.Date;
            res.Diagnosis = visit.Diagnosis;
            res.PatientId = visit.Patient.Id;
            //res.Patient = (Patient)visit.Patient;
            res.VisitTypeId = visit.VisitType.Id;
            //res.VisitType = (VisitType)visit.VisitType;

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
                    ((Visit)this).Add();
                }
                else
                {
                    ((Visit)this).Update();
                }
            }
            catch (Exception exc)
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

                ((Visit)this).Delete();
            }
            catch (Exception)
            {
                return "Что то пошло не так...";
            }

            return string.Empty;
        }

        public static List<VisitBL> GetAll()
        {
            List<VisitBL> res = new List<VisitBL>();

            List<Visit> all = Visit.GetAll();
            if ((all == null) || (all.Count <= 0))
                return res;

            return Translate(all);
        }
    }
}
