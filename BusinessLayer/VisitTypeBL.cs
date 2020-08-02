using DataLayer;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class VisitTypeBL
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        internal VisitTypeBL(VisitType visitType)
        {
            Translate(visitType);
        }

        public VisitTypeBL(string name)
        {
            Name = name;
        }

        internal static List<VisitTypeBL> Translate(List<VisitType> visitTypes)
        {
            List<VisitTypeBL> res = new List<VisitTypeBL>();
            foreach(VisitType visit in visitTypes)
            {
                res.Add(new VisitTypeBL(visit));
            }

            return res;
        }

        private void Translate(VisitType visitType)
        {
            Id = visitType.Id;
            Name = visitType.Name;
        }

        public static explicit operator VisitType(VisitTypeBL visitType)
        {
            VisitType res = new VisitType();

            res.Id = visitType.Id;
            res.Name = visitType.Name;

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
                    ((VisitType)this).Add();
                }
                else
                {
                    ((VisitType)this).Update();
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

                ((VisitType)this).Delete();
            }
            catch (Exception)
            {
                return "Что то пошло не так...";
            }

            return string.Empty;
        }

        public static List<VisitTypeBL> GetAll()
        {
            List<VisitTypeBL> res = new List<VisitTypeBL>();

            List<VisitType> all = VisitType.GetAll();
            if ((all == null) || (all.Count <= 0))
                return res;

            return Translate(all);
        }
    }
}
