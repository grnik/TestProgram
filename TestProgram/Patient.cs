using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
     public class Patient
    {
        public Guid Id { get; set; }
        public string FIO { get; set; }
        public int Gender { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public void Add()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Patients.Add(this);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Patients.Update(this);
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Patients.Remove(this);
                db.SaveChanges();
            }
        }

        public static Patient GetById(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var res = db.Patients.FirstOrDefault(v => v.Id == id);
                return res;
            }
        }

        public static List<Patient> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var res = db.Patients.ToList();
                return res;
            }
        }
    }
}
