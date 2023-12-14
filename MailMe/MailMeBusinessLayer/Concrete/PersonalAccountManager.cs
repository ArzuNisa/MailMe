using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailMeBusinessLayer.Abstract;
using MailMeDataAccessLayer.Abstract;
using MailMeEntityLayer.Concrete;

namespace MailMeBusinessLayer.Concrete
{
    public class PersonalAccountManager : IPersonalAccountService
    {
        private readonly IPersonalAccountDal _personalAccountDal;

        public PersonalAccountManager(IPersonalAccountDal personalAccountDal)
        {
            _personalAccountDal = personalAccountDal;
        }

        public void TDelete(PersonalAccount t)
        {
            _personalAccountDal.Delete(t);
        }

        public PersonalAccount TGetByID(int id)
        {
            return _personalAccountDal.GetByID(id);
        }

        public List<PersonalAccount> TGetList()
        {
            return _personalAccountDal.GetList();
        }

        public void TInsert(PersonalAccount t)
        {
            _personalAccountDal.Insert(t);
        }

        public void TUpdate(PersonalAccount t)
        {
            _personalAccountDal.Update(t);
        }
    }
}
