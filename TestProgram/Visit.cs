using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; }

        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid VisitTypeId { get; set; }
        public VisitType VisitType { get; set; }


        public void Add()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Visits.Add(this);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Visits.Update(this);
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Visits.Remove(this);
                db.SaveChanges();
            }
        }

        public static Visit GetById(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var res = db.Visits.Include(p=>p.Patient).Include(vt=>vt.VisitType).FirstOrDefault(v => v.Id == id);
                return res;
            }
        }

        public static List<Visit> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var res = db.Visits.AsNoTracking().Include(p=>p.Patient).Include(t=>t.VisitType).ToList();
                return res;
            }
        }
    }
}
