using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataLayer
{
    public class VisitType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Add()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.VisitTypes.Add(this);
                db.SaveChanges();
            }
        }

        public void Update()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.VisitTypes.Update(this);
                db.SaveChanges();
            }
        }

        public void Delete()
        {
            // Добавление
            using (ApplicationContext db = new ApplicationContext())
            {
                db.VisitTypes.Remove(this);
                db.SaveChanges();
            }
        }

        public static VisitType GetById(Guid id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var res = db.VisitTypes.FirstOrDefault(v => v.Id == id);
                return res;
            }
        }

        public static List<VisitType> GetAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var res = db.VisitTypes.ToList();
                return res;
            }
        }
    }
}
