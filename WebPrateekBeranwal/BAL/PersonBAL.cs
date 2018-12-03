using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class PersonBAL
    {
        public PersonModel GetPersonDetail(int id)
        {
            PersonModel p=null;           
            PersonDAL dal = new PersonDAL();
            DataSet ds = dal.getPersonDetail(id);
            p = ConvertDsintoObject(ds);
            return p;
        }

        public PersonModel ConvertDsintoObject(DataSet ds)
        {
            List<PersonModel> p = null;
            List<PersonNumber> lstNumber = null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                p = ds.Tables[0].AsEnumerable().Select(dataRow => new PersonModel
                {
                    ForeName = dataRow.Field<string>("ForeNameS"),
                    SurName = dataRow.Field<string>("SurName"),
                    Gender = dataRow.Field<string>("Gender"),
                    DOB = dataRow.Field<DateTime>("DateOfBirth"),
                    PersonId = dataRow.Field<int>("Personid")
                }).ToList<PersonModel>();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                lstNumber = ds.Tables[1].AsEnumerable().Select(dataRow => new PersonNumber
                {
                    Type = dataRow.Field<string>("Type"),
                    Number = dataRow.Field<string>("Number")                   
                }).ToList<PersonNumber>();
                p.FirstOrDefault().Number = lstNumber;
                while (lstNumber.Count <3)
                {
                    PersonNumber pn = new PersonNumber();
                    lstNumber.Add(pn);
                }
            }

                return p.FirstOrDefault();
        }

        public int SavePerson(PersonModel person)
        {
            int personId = 0;
            PersonDAL dal = new PersonDAL();
            personId = dal.SavePerson(person);
            return personId;

        }
    }
  
}
